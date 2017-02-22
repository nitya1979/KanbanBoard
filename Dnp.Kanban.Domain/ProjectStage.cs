using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public class ProjectStage
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        [Required(ErrorMessage = "Please enter project Name.")]
        [MaxLength(150)]
        public string StageName { get; set; }

        public short Order { get; set; }

        public bool IsCurrent { get; set; }

    }
}
