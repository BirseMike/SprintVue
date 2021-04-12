namespace SprintVue.Services
{
    public interface ISprintService
    {
        SprintItem[] GetSprintItems(string sprint);
       
        //TODO - GetSprints
        //TODO - GetStatistics
        //GetBurnCharts
        //TODO -GetReport
    }
}