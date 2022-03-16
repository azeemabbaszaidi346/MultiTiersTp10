using CommanLayer.Models;
using DataAccesslayer;
using System;
using System.Collections.Generic;

namespace BusinessAccessLayer
{
    public class BLEmployeesBusiness
    {
        private EmployeeDataAccessdb employeeData;
        public BLEmployeesBusiness()
        {

            employeeData = new EmployeeDataAccessdb();
        }
        public List<Employees> GetEmployees()
        {
            return employeeData.GetEmployees();
        }
        public Employees GetEmployeesbyId(int id)
        {
            return employeeData.GetEmployeesbyId(id);
        }
        public bool DeleteEmployee(int id)
        {
            return employeeData.DeleteEmployee(id);
        }
        public bool createEmployees(Employees emp)
        {
            return employeeData.CreateEmployee(emp);
        }
        public bool UpdateeEmployees(Employees emp)
        {
            return employeeData.UpdateEmployee(emp);
        }
    }
}
