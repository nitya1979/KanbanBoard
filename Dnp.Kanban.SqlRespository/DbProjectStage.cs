using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.SqlRepository
{
    [Table("tblProjectStage")]
    public class DbProjectStage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int ProjectID { get; set; }

        [Required]
        [MaxLength(150)]
        public string StageName { get; set; }

        public virtual DbProject Project { get; set; }
    }
}
