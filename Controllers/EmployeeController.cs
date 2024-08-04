using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // Lista estática para simular una base de datos
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Daniel Delgado", Position = "Front-end", Office = "Medellin", Salary = 2500000 },
            new Employee { Id = 2, Name = "Deyber Garzon", Position = "Full-Stack", Office = "Cartagena", Salary = 12500000},
            new Employee { Id = 3, Name = "Diego Porras", Position = "Backend", Office = "Cali", Salary = 32500000},
            new Employee { Id = 3, Name = "Luis Diaz", Position = "QA", Office = "Bogota", Salary = 3000000},
            new Employee { Id = 3, Name = "Susana Suarez", Position = "Support Aplication", Office = "Pasto", Salary = 5000000},
        };  

        // Acción para mostrar la vista principal
        public ActionResult Index()
        {
            return View();
        }

        // Acción para obtener la lista de empleados en formato JSON
        [HttpGet]
        public JsonResult GetEmployees()
        {
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        // Acción para obtener un empleado por su Id en formato JSON
        [HttpGet]
        public JsonResult GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                return Json(employee, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        // Acción para agregar un nuevo empleado
        [HttpPost]
        public JsonResult AddEmployee(Employee employee)
        {
            // Asigna un nuevo Id al empleado
            employee.Id = employees.Count + 1;
            // Agrega el empleado a la lista
            employees.Add(employee);
            // Devuelve el empleado agregado en formato JSON
            return Json(employee);
        }

        // Acción para actualizar la información de un empleado existente
        [HttpPost]
        public JsonResult UpdateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = employees.FirstOrDefault(e => e.Id == employee.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name;
                    existingEmployee.Position = employee.Position;
                    existingEmployee.Office = employee.Office;
                    existingEmployee.Salary = employee.Salary;
                    return Json(existingEmployee);
                }
            }
            return Json(new { success = false, message = "Datos inválidos" });
        }

        // Acción para eliminar un empleado
        [HttpPost]
        public JsonResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Empleado no encontrado" });
        }
    }
}