using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    // Modelo que representa un empleado
    public class Employee
    {
        // Identificador único del empleado
        public int Id { get; set; }

        // Nombre completo del empleado, requerido y con longitud máxima de 100 caracteres
        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; }

        // Cargo del empleado, requerido y con longitud máxima de 100 caracteres
        [Required]
        [StringLength(100, ErrorMessage = "El cargo no puede exceder los 100 caracteres.")]
        public string Position { get; set; }

        // Oficina del empleado, requerido y con longitud máxima de 100 caracteres
        [Required]
        [StringLength(100, ErrorMessage = "La oficina no puede exceder los 100 caracteres.")]
        public string Office { get; set; }

        // Salario del empleado, requerido y debe ser un valor positivo
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un valor positivo.")]
        public decimal Salary { get; set; }
    }
}