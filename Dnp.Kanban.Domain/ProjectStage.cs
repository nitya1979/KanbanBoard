using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public class ProjectStage
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public string StageName { get; set; }

        public bool IsCurrent { get; set; }

    }
}
