using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        List<Employee> employeeList = new List<Employee>() {
            new Employee {
                Id = 1,
                Name = "John",
                Salary = 12000,
                Department = new Department {
                    Id = 1,
                    Name = "HR"
                },
                Skills = new List<Skill>() {
                    new Skill {
                        Id = 1,
                        Name = "English"
                    },
                    new Skill {
                        Id = 2,
                        Name = "Management"
                    }
                },
                DateOfBirth = DateTime.Parse("10/10/2019")
            },
            new Employee {
                Id = 2,
                Name = "Mark",
                Salary = 12000,
                Department = new Department {
                    Id = 2,
                    Name = "Developer"
                },
                Skills = new List<Skill>() {
                    new Skill {
                        Id = 1,
                        Name = "English"
                    },
                    new Skill {
                        Id = 3,
                        Name = "FullStack"
                    }
                },
                DateOfBirth = DateTime.Parse("10/5/2019")
            },
            new Employee {
                Id = 3,
                Name = "Ryan",
                Salary = 15000,
                Department = new Department {
                    Id = 3,
                    Name = "Manager"
                },
                Skills = new List<Skill>() {
                    new Skill {
                        Id = 1,
                        Name = "English"
                    },
                    new Skill {
                        Id = 2,
                        Name = "Management"
                    }
                },
                DateOfBirth = DateTime.Parse("12/9/2019")
            }
        };

        List<Employee> GetStandardEmployeeList() {
            return employeeList;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get() {
            return GetStandardEmployeeList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id) {
            List<Employee> employees = GetStandardEmployeeList();
            var employee = employees.FirstOrDefault(emp => emp.Id == id);
            if (employee != null) return employee;
            else return null ;
            
        }

        
        [HttpGet("{name}")]
        public Employee GetEmployeeName(string name) {
            List<Employee> employees = GetStandardEmployeeList();
            var employee = employees.FirstOrDefault(emp => emp.Name == name);
            if (employee != null) return employee;
            else return null;

        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee) {
            return Ok(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employeeChange) {
            List<Employee> employees = GetStandardEmployeeList();
            var employee = employees.FirstOrDefault(emp => emp.Id == id);
            if (employee != null) return Ok(employeeChange);
            else return BadRequest(employeeChange);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            List<Employee> employees = GetStandardEmployeeList();
            var employee = employees.FirstOrDefault(emp => emp.Id == id);
            if (employee != null) return Ok(employee);
            else return BadRequest(employee);
        }
    }
}
