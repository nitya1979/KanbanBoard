﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dnp.Kanban.Domain
{
    public class Project
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
