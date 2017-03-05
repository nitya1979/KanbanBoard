using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.ViewModel
{
    public class ProjectStageViewModel
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        [Required(ErrorMessage = "Please enter project Name.")]
        [MaxLength(150)]
        public string StageName { get; set; }

        [Required(ErrorMessage = "Please select Order of the stage.")]
        public short Order { get; set; }  

    }
}
