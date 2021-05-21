using SprintVue.Models;
using System.Collections.Generic;

namespace SprintVue.Services
{
    public interface ISprintService
    {
        IEnumerable<Sprint> GetSprints();
        IList<SprintItem> GetFullBackLog();
        IList<SprintItem> GetAllBackLogItems();
        IEnumerable<SprintItem> GetSprintItems(string sprintId);
        SprintReport GetSprintReport(string sprintId);
        BurnUpData GetSprintBurnUp(string sprintId);
    }

    public interface IJiraLogger
    {
        void Log(string logMessage);
    }
}
