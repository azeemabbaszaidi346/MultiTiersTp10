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
    }
}
