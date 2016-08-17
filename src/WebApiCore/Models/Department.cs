using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApiCore.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }

    }
}
