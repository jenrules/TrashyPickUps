using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Trash.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage ="Must start with a capital letter.")]
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage ="Must start with a capital letter.")]
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
        [RegularExpression(@"^[0-9]+[a-zA-Z''-'\s]*$", ErrorMessage ="Must start with the house number.")]
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage ="Write any day of the week. Must start with a capital letter.")]
        public string Weekday { get; set; }
        [Display(Name = "How Often")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage ="Must start with a capital letter.")]
        public string HowOften { get; set; }
        
    }
    public class CustomerDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Trash.Models.Collector> Collectors { get; set; }
    }
}