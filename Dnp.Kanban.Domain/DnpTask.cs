﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public class DnpTask
    {
        public int TaskID { get; set; }

        public int ProjectStageID { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public Priority Priority { get; set; }

    }
}
