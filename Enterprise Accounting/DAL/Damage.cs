using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class Damage : MyBase,IDatabase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime DateTime { get; set; }
        public double Quentity { get; set; }
        public string Remark { get; set; }
        public int EmployeeId { get; set; } 


        public  bool Insert()
        {
            Command = CommandBuilder("insert into Damage ( productId, dateTime, qty, remarks, employeeId) values( @productId, @dateTime, @qty, @remarks, @employeeId)");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@dateTime", DateTime);
            Command.Parameters.AddWithValue("@qty", Quentity);
            Command.Parameters.AddWithValue("@remarks", Remark);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            return ExecuteNQ(Command);
        }

        public  bool Update()
        {
            Command = CommandBuilder("update Damage set productId=@productId, dateTime=@dateTime, qty=@qty, remarks=@remarks, employeeId=@employeeId where id=@id");
            Command.Parameters.AddWithValue("@productId", ProductId);
            Command.Parameters.AddWithValue("@dateTime", DateTime);
            Command.Parameters.AddWithValue("@qty", Quentity);
            Command.Parameters.AddWithValue("@remarks", Remark);
            Command.Parameters.AddWithValue("@employeeId", EmployeeId);
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public  bool Delete()
        {
            Command = CommandBuilder("delete from Damage where id=@id");
            Command.Parameters.AddWithValue("@id", Id);
            return ExecuteNQ(Command);
        }
        public  bool SelectById()
        {
            Command = CommandBuilder("select id, productId, dateTime, qty, remarks, employeeId from Damage where id=@id");
            Command.Parameters.AddWithValue("@id", Id);

            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                ProductId = Convert.ToInt32(Reader["productId"]);
                DateTime = (DateTime)Reader["dateTime"];
                Quentity = Convert.ToDouble(Reader["qty"]);
                Remark = Reader["remarks"].ToString();
                EmployeeId = Convert.ToInt32(Reader["employeeId"]);
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = CommandBuilder(@"select d.id, p.id, p.name as product , d.qty,d.datetime, d.remarks,
                              l.name as employee from Damage as d
                              left join Product as p on d.productId=p.id
                              left join Ledger as l on d.employeeId=l.id where d.id>0");

            if (!string.IsNullOrEmpty(Search))
            {
                Command.CommandText += " and (d.qty like @search or d.remarks like @search)";
                Command.Parameters.AddWithValue("@search", "%" + Search + "%");
            }

            if (ProductId > 0)
            {
                Command.CommandText += " and p.id like @search";
                Command.Parameters.AddWithValue("@search", "%" + ProductId + "%");
            }

          return  ExecuteDS(Command);
        }
        public bool Table()
        {
            Command = CommandBuilder(@"create table Damage(Id int identity primary key,productId int,
                                    dateTime datetime, qty float, remarks varchar(2000), employeeId int,
                                  foreign key (productId) references Product(id),
                                  foreign key (employeeId) references Ledger(id),)");
            return ExecuteNQ(Command);
        }
    }
}
