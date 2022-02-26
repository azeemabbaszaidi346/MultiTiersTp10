using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;
namespace DataAccesslayer
{
    public class EmployeeDataAccessdb
    {
        private DbConnection db = new DbConnection();

        public List<Employees>  GetEmployees()
        {
            string query = "select * from Employees";
            SqlCommand command = new SqlCommand();
            command.Connection = db.Cnn;
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            while (reader.Read())
            {
                Employees emp = new Employees();
                emp.Id = (int)reader["id"];
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString(); 
                emp.Phone = reader["Phone"].ToString();
                emp.Gender = reader["Gender"].ToString();
                employees.Add(emp);
            }
            db.Cnn.Close();
            return employees;
        }
    }
}
