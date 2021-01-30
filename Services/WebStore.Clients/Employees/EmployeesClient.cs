using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebStore.Clients.Base;
using WebStore.Domain.Models;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        private readonly ILogger<EmployeesClient> logger;

        public EmployeesClient(IConfiguration configuration, ILogger<EmployeesClient> logger) 
            : base(configuration, WebAPI.Employees)
        {
            this.logger = logger;
        }

        public IEnumerable<Employee> Get() => Get<IEnumerable<Employee>>(Address);

        public Employee Get(int id) => Get<Employee>($"{Address}/{id}");

        public int Add(Employee employee) => Post(Address, employee).Content.ReadAsAsync<int>().Result;

        public void Update(Employee employee)
        {
            logger.LogInformation($"Редактирование сотрудника с id:{employee.Id}");
            Put(Address, employee);
        }

        public bool Delete(int id) => Delete($"{Address}/{id}").IsSuccessStatusCode;
    }
}