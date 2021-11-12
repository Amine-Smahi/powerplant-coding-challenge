using System.Collections.Generic;
using PowerplantChallenge.Domain;

namespace PowerplantChallenge.Application.Interfaces
{
    public interface IProductionPlanService
    {
        IEnumerable<object> GetProductionPlan(Plan plan);
    }
}