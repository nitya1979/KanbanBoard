using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public class DnpTask
    {
        public int TaskID { get; set; }

        public string ProjectName { get; set; }
        
        public int ProjectStageID { get; set; }

        public int ProjectID { get; set; }

        public string StageName { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public DateTime? DueDate { get; set; }

        public Priority Priority { get; set; }

        public bool IsCompleted { get; set; }

        public string UserID { get; set; }

    }
}
