using System;
using System.Collections.Generic;
using System.Linq;
using PowerplantChallenge.Domain;

namespace PowerplantChallenge.Application.Extensions
{
    public static class Extensions
    {
        public static IOrderedEnumerable<PowerPlant> OrderPowerPlants(this IEnumerable<PowerPlant> powerPlants)
        {
            return powerPlants
                .OrderByDescending(i => i.Efficiency)
                .ThenBy(i => i.FuelCost)
                .ThenByDescending(i => i.ActualPMax);
        }

        public static IEnumerable<object> ReportPlanLoad(this IEnumerable<PowerPlant> powerPlants, decimal planLoad)
        {
            var ret = new List<object>();
            var load = planLoad;
            powerPlants
                .ToList()
                .ForEach(p =>
                {
                    if (p.ActualPMax == 0)
                    {
                        ret.Add(new
                        {
                            name = p.Name,
                            p = 0
                        });
                        return;
                    }

                    if (load <= p.ActualPMax)
                    {
                        ret.Add(new
                        {
                            name = p.Name,
                            p = (int) Math.Ceiling(load)
                        });
                        load = 0;
                        return;
                    }

                    ret.Add(new
                    {
                        name = p.Name,
                        p = (int) Math.Ceiling(p.PMax)
                    });
                    load -= p.ActualPMax;
                });
            return ret;
        }

        public static IEnumerable<PowerPlant> CalculateCostAndActualPower(this IEnumerable<PowerPlant> powerPlants,
            Fuel fuel)
        {
            return powerPlants.ToList()
                .Select(plant => new PowerPlant
                {
                    Name = plant.Name,
                    Type = plant.Type,
                    Efficiency = plant.Efficiency,
                    PMax = plant.PMax,
                    PMin = plant.PMin,
                    ActualPMax = plant.GetActualPMax(fuel),
                    FuelCost = plant.GetFuelCost(fuel),
                    EmissionCost = plant.GetEmissionCost(fuel)
                });
        }

        private static decimal GetFuelCost(this PowerPlant powerPlant, Fuel fuel)
        {
            if (powerPlant.Type == PowerPlantType.WindTurbine)
                return 0.0M;

            if (powerPlant.Type == PowerPlantType.GasFired)
                return fuel.Gas / powerPlant.Efficiency;

            return fuel.Kerosene / powerPlant.Efficiency;
        }

        //Not sure if I'm doing this is right, therefore I won't take optional emission cost in this count
        private static decimal GetEmissionCost(this PowerPlant powerPlant, Fuel fuel)
        {
            if (powerPlant.Type == PowerPlantType.WindTurbine)
                return 0.0M;

            return fuel.Gas / powerPlant.Efficiency * 0.3M * fuel.Co2;
        }

        private static decimal GetActualPMax(this PowerPlant powerPlant, Fuel fuel)
        {
            if (powerPlant.Type != PowerPlantType.WindTurbine)
                return powerPlant.PMax;
            return powerPlant.PMax / 100.0M * fuel.Wind;
        }
    }
}