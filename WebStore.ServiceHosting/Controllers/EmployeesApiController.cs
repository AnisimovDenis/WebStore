using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Models;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData EmployeesData;

        public EmployeesApiController(IEmployeesData EmployeesData) => this.EmployeesData = EmployeesData;

        [HttpPost]
        public int Add(Employee employee) => EmployeesData.Add(employee);

        [HttpDelete("{id}")]
        public bool Delete(int id) => EmployeesData.Delete(id);

        [HttpGet]
        public IEnumerable<Employee> Get() => EmployeesData.Get();

        [HttpGet("{id}")]
        public Employee Get(int id) => EmployeesData.Get(id);

        [HttpPut]
        public void Update(Employee employee) => EmployeesData.Update(employee);
    }
}
