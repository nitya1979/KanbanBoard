    function Project() {
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
        this.height = "";
    }

    function DnpTask() {
        this.TaskID = 0;
        this.StageID = 0 ;
        this.Priority = 0;
        this.ShortDescription = "";
        this.LongDescription = "";
    }