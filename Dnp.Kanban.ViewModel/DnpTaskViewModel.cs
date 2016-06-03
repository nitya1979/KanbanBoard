using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.ViewModel
{
    class DnpTaskViewModel
    {
        public int TaskID { get; set; }

        [Required(ErrorMessage = "StageID Required")]
        public int StageID { get; set; }

        [Required(ErrorMessage = "Priority Required")]
        public int Priority { get; set; }

        [Required(ErrorMessage ="Short Description is required.")]
        [MaxLength(255)]
        public string ShortDescription { get; set; }

        [MaxLength(400)]
        public string LongDescription { get; set; }
    }
}
