using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.ViewModel
{
    public class DnpTaskViewModel
    {
        public int TaskID { get; set; }

        [Display(Description ="Current Stage")]
        public int StageID { get; set; }

        [Required(ErrorMessage = "Priority Required")]
        [Display(Description = "Priority", Name = "Priority")]
        public int Priority { get; set; }

        [Required(ErrorMessage ="Short Description is required.")]
        [MaxLength(255)]
        [Display(Description = "Summary", Name ="Summary")]
        public string ShortDescription { get; set; }

        [MaxLength(400)]
        [Display(Name = "Detailed Description", Description ="Detailed Description")]
        public string LongDescription { get; set; }
    }
}
