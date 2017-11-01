using EmployeeModule.Models;
using EmployeeModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModule.ViewModels
{
    public class EmployeeListViewModel
    {
        public Employees Employees { get; set; }

        public EmployeeListViewModel(IEmployeeDataService employeeService)
        {
            Employees = employeeService.GetEmployees();
        }
    }
}
