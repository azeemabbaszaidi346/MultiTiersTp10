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

        public List<Employees> GetEmployees()
        {
            string query = "select * from Employees";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.Cnn; 
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
        public Employees GetEmployeesbyId(int id)
        {
            string query = "select * from Employees where id=" +id+ "";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.Cnn;
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Employees emp = new Employees();
            emp.Id = (int)reader["id"];
            emp.Name = reader["Name"].ToString();
            emp.Email = reader["Email"].ToString();
            emp.Phone = reader["Phone"].ToString();
            emp.Gender = reader["Gender"].ToString();

            db.Cnn.Close();
            return emp;
        }

        public bool CreateEmployee(Employees employee)
        {

            string query = "insert into Employees values('" + employee.Name + "','" + employee.Email + "', '" + employee.Phone + "','" + employee.Gender + "')";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }
        public bool DeleteEmployee(int id)
        {

            string query = "Delete from Employees Where id=" + id + "";

            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }
        public bool UpdateEmployee(Employees employee)
        {

            string query = "Update Employees set Name='" + employee.Name + "', Email='" + employee.Email + "',Phone='" + employee.Phone + "',Gender='" + employee.Gender + "'where id =" + employee.Id + "";

            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }
    }
}
