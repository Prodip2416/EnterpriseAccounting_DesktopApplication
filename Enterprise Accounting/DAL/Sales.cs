﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
   public class Sales : MyBase,IDatabase
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DateTime { get; set; }  
        public int EmployeeId { get; set; }
        public int LedgerId { get; set; }
        public double Total { get; set; }
        public double Addition { get; set; }
        public double Deduction { get; set; }
        public string Remarks { get; set; } 


        public bool Insert()
        {
            Command = CommandBuilder(@"insert into Sales ( number, date, employeeId, ledgerId, total, addition, deduction, remarks)
                                values ( @number, @date, @employeeId, @ledgerId, @total, @addition, @deduction, @remarks)");

            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@date", DateTime);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            Command.Parameters.AddWithValue("@ledgerId", LedgerId);
            Command.Parameters.AddWithValue("@total", Total);
            Command.Parameters.AddWithValue("@addition", Addition);
            Command.Parameters.AddWithValue("@deduction", Deduction);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNQ(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder(@"update Sales set number=@number, date=@date, employeeId=@employeeId, ledgerId=@ledgerId,
                                    total=@total, addition=@addition, deduction=@deduction, remarks=@remarks  where id=@id");


            Command.Parameters.AddWithValue("@number", Number);
            Command.Parameters.AddWithValue("@date", DateTime);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            Command.Parameters.AddWithValue("@ledgerId", LedgerId);
            Command.Parameters.AddWithValue("@total", Total);
            Command.Parameters.AddWithValue("@addition", Addition);
            Command.Parameters.AddWithValue("@deduction", Deduction);
            Command.Parameters.AddWithValue("@remarks", Remarks);
            Command.Parameters.AddWithValue("@Id", Id);
            return ExecuteNQ(Command);
        }
        public bool Delete()
        {
            Command = CommandBuilder("delete from Sales where id=@id");
            Command.Parameters.AddWithValue("@Id", Id);
            return ExecuteNQ(Command);
        }
        public bool SelectById()
        {
            Command = CommandBuilder(@"select id, number, date, employeeId, ledgerId, total, addition, deduction,
                                       remarks from Sales where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                Number = Convert.ToInt32(Reader["number"]);
                DateTime = Convert.ToDateTime(Reader["date"]);
                EmployeeId = Convert.ToInt32(Reader["employeeId"]);
                LedgerId = Convert.ToInt32(Reader["ledgerId"]);
                Total = Convert.ToDouble(Reader["total"]);
                Addition = Convert.ToDouble(Reader["addition"]);
                Deduction = Convert.ToDouble(Reader["deduction"]);
                Remarks = Reader["remarks"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder(@"select S.id, S.number, S.date, L.name as employee,L1.name as Ledger, S.total,
                              S.addition, S.deduction, S.remarks
                              from Sales as S
                              left join Ledger L on S.EmployeeId = L.id
                              left join Ledger L1 on S.LedgerId = L1.id where S.id > 0" );


            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += " and (S.number like @search or S.total like @search" +
                                       " or S.addition like @search or S.deduction like @search or S.remarks like @search)";

                Command.Parameters.AddWithValue("@search", "%" + Search + "%");
            }

            if (LedgerId > 0)
            {
                Command.CommandText += @" and  (L.id like @ledger)";
                Command.Parameters.AddWithValue("@ledger", "%" + LedgerId + "%");
            }
            return  ExecuteDS(Command);
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Sales(id int identity primary key, number int,date datetime,
                                        employeeId int, ledgerId int, total float, addition float, deduction float, remarks varchar(2000),
                                        foreign key(EmployeeId) references Ledger(id),
                                        foreign key(LedgerId) references Ledger(id))");
            return ExecuteNQ(Command);
        }
    }
}
