using System.Collections.Generic;
using PowerplantChallenge.Application.Extensions;
using PowerplantChallenge.Application.Interfaces;
using PowerplantChallenge.Domain;

namespace PowerplantChallenge.Application.Services
{
    public class ProductionPlanService : IProductionPlanService
    {
        public IEnumerable<object> GetProductionPlan(Plan plan)
        {
            return plan.Powerplants
                .CalculateCostAndActualPower(plan.Fuels)
                .OrderPowerPlants()
                .ReportPlanLoad(plan.Load);
        }
    }
}