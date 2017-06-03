using System;

namespace WebDashboardv2.Model
{
    [Flags]
    public enum ApproverAccess
    {
        CoremakeCB22 = 1,
        Coremake321 = 2 ,
        CoremakeLaempe = 4,
        Coremake106 =8,
        CoreAssembly = 16,
        MoldingOsborn = 32,
        MoldingSinto = 64,
        MeltingOsborn = 128,
        MeltingSinto = 256,
        CleaningOsborn = 512,
        CleaningSinto = 1024,
        Finishing = 2048
    }
  
}
