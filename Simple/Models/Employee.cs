using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple.Models
{
    public class Employee
    {
        public Employee() { }

        public Employee(Employee gEmployee)
        {
            this.Employee_ID = gEmployee.Employee_ID;
            this.Employee_Name = gEmployee.Employee_Name;
            this.Employee_Age = gEmployee.Employee_Age;
            this.Comapny_Id = gEmployee.Comapny_Id;
        }

        [Key]
        public int Employee_ID { get; set; }

        public string? Employee_Name { get; set; }

        public int Employee_Age { get; set; }

        [ForeignKey("Company")]
        public int Comapny_Id { get; set; }

        public Company? Company { get; set; }
    }
}
