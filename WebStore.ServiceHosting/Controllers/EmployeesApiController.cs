using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Models;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData EmployeesData;
        private readonly ILogger<EmployeesApiController> logger;

        public EmployeesApiController(IEmployeesData EmployeesData, ILogger<EmployeesApiController> logger)
        {
            this.EmployeesData = EmployeesData;
            this.logger = logger;
        }

        [HttpPost]
        public int Add(Employee employee)
        {
            logger.LogInformation($"Добавление сотрудника {employee.LastName} {employee.FirstName} {employee.Patronymic}");

            var id = EmployeesData.Add(employee);

            if (id > 0)
                logger.LogInformation($"Cотрудник  [id:{employee.Id}] {employee.LastName} {employee.FirstName} {employee.Patronymic} успешно добавлен");
            else
                logger.LogError("Ошибка при добавлении");

            return id;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            logger.LogInformation($"Удаление сотрудника [id:{id}]");

            var deleteResult = EmployeesData.Delete(id);

            if (deleteResult == true)
                logger.LogInformation($"Сотрудник [id:{id}] успешно удален");
            else
                logger.LogInformation($"Ошибка при удалении");

            return deleteResult;
        }

        [HttpGet]
        public IEnumerable<Employee> Get() => EmployeesData.Get();

        [HttpGet("{id}")]
        public Employee Get(int id) => EmployeesData.Get(id);

        [HttpPut]
        public void Update(Employee employee)
        {
            logger.LogInformation($"Редактирование сотрудника {employee.LastName} {employee.FirstName} {employee.Patronymic}");

            EmployeesData.Update(employee);

            if (employee.Id > 0)
                logger.LogInformation($"Cотрудник  [id:{employee.Id}] {employee.LastName} {employee.FirstName} {employee.Patronymic} успешно изменен");
            else
                logger.LogError("Ошибка при редактировании");
        }
    }
}
