using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public class DnpTask
    {
        public int ID { get; set; }

        [Display(Description ="Task")]
        [Required(ErrorMessage = "Please enter task name.")]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(500)]
        [Display(Description = "Description")]
        public string Description { get; set; }

        public int StageID { get; set; }

    }
}
