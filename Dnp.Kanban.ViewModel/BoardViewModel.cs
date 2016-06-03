using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.ViewModel
{
    public class BoardViewModel
    {
        public ProjectViewModel ProjectDetail { get; set; }

        public List<ProjectStageViewModel> ProjectStages { get; set; }


    }
}
