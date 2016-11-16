using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.SqlRepository
{
    [Table("tblTask")]
    public class DbTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }

        public int StageID { get; set; }

        [MaxLength(255)]
        [Required]
        public string ShortDescription { get; set; }
        
        [MaxLength(400)]
        public string LongDescription { get; set; }

        public int Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public virtual DbProjectStage ProjectStage { get; set; }

    }
}
