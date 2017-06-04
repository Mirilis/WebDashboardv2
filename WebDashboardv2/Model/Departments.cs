using System.ComponentModel.DataAnnotations;
using System;

namespace WebDashboardv2.Model
{
    [Flags]
    public enum Departments
    {
        Core=1,
        Mold=2,
        Melt=4,
        Cleaning=8,
        Finishing=16,
        Maintenance=32,
        IndustrialEngineering=64,
        Technical=128,
        Quality=256,
        FoundryEngineering=512,
        PlantEngineering=1024,
        Environmental=2048,
        ProductionControl=4096,
        HumanResources=8192,
        Safety=16384,
        Training=32768
    }
  
}
