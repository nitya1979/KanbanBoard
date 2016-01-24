using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.SqlRepository
{
    [Table("tblProject")]
    public class DbProject
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EstimatedDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

    }
}
