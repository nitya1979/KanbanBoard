using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public class Project
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter name of the project.")]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        [DataType(DataType.Date, ErrorMessage ="Invalid start date")]
        [Required(ErrorMessage ="Please enter start date.")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage ="Invalid projected end date.")]
        [Required(ErrorMessage = "Please enter projected end date.")]
        public DateTime EstimatedDate { get; set; }

        [DataType(DataType.Date, ErrorMessage ="Invalid end date.")]
        public DateTime EndDate { get; set; }

    }
}
