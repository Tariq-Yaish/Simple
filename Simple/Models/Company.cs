using System.ComponentModel.DataAnnotations;

namespace Simple.Models
{
    public class Company
    {
        public Company() { }

        public Company(Company gCompany)
        {
            this.Company_ID = gCompany.Company_ID;
            this.Company_Name = gCompany.Company_Name;
            this.Location = gCompany.Location;
        }

        [Key]
        public int Company_ID { get; set; }

        public string? Company_Name { get; set; }

        public string? Location { get; set; }

        public ICollection<Employee>? emploees { get; set; }
    }
}
