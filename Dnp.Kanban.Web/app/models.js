﻿    function Project() {
        this.ID = 0;
        this.Name = "New Project";
        this.Description = "";
        this.StartDate = new Date();
        this.EndDate = new Date();
    }

    function ProjectStage() {
        this.ID = 0;
        this.ProjectID = 0;
        this.StageName = "";
        this.className = "";
    }