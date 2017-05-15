using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using SkiaSharp;



namespace WebDashboardv2.Model
{
    public class DbInitializer
    {
            public static void Initialize(ProcessCardContext context)
            {
                context.Database.EnsureCreated();
            
            
     

            // Look for any students.
            if (context.ProcessCards.Any())
                {
                    return;   // DB has been seeded
                }

            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProductName", ProcessCardClass = ProcessCardClass.CoremakeCB22 });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "Customer", ProcessCardClass = ProcessCardClass.CoremakeCB22 });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "GasTime", ProcessCardClass = ProcessCardClass.CoremakeCB22 });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "GasPressure", ProcessCardClass = ProcessCardClass.CoremakeCB22 });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "BlowTime", ProcessCardClass = ProcessCardClass.CoremakeCB22 });

            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProductName", ProcessCardClass = ProcessCardClass.CoremakeLaempe });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "Customer", ProcessCardClass = ProcessCardClass.CoremakeLaempe });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "GasTime", ProcessCardClass = ProcessCardClass.CoremakeLaempe });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "GasPressure", ProcessCardClass = ProcessCardClass.CoremakeLaempe });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "BlowTime", ProcessCardClass = ProcessCardClass.CoremakeLaempe });

            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProductName", ProcessCardClass = ProcessCardClass.MoldingOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "Customer", ProcessCardClass = ProcessCardClass.MoldingOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "PatternLocation", ProcessCardClass = ProcessCardClass.MoldingOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "SqueezePressure", ProcessCardClass = ProcessCardClass.MoldingOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "FilterRequirements", ProcessCardClass = ProcessCardClass.MoldingOsborn });

            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProductName", ProcessCardClass = ProcessCardClass.MeltingOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "Customer", ProcessCardClass = ProcessCardClass.MeltingOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "PourTime", ProcessCardClass = ProcessCardClass.MeltingOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "MetalGrade", ProcessCardClass = ProcessCardClass.MeltingOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoarseTime", ProcessCardClass = ProcessCardClass.MeltingOsborn });

            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProductName", ProcessCardClass = ProcessCardClass.CleaningOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "Customer", ProcessCardClass = ProcessCardClass.CleaningOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "BatterSpecification", ProcessCardClass = ProcessCardClass.CleaningOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "InclusionSpecification", ProcessCardClass = ProcessCardClass.CleaningOsborn });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "MillTime", ProcessCardClass = ProcessCardClass.CleaningOsborn });

            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProductName", ProcessCardClass = ProcessCardClass.Finishing });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "Customer", ProcessCardClass = ProcessCardClass.Finishing });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "BatterSpecification", ProcessCardClass = ProcessCardClass.Finishing });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "InclusionSpecification", ProcessCardClass = ProcessCardClass.Finishing });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "PackSize", ProcessCardClass = ProcessCardClass.Finishing });

            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProductName", ProcessCardClass = ProcessCardClass.CoreAssembly });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "Customer", ProcessCardClass = ProcessCardClass.CoreAssembly });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "RequiredMaterial1", ProcessCardClass = ProcessCardClass.CoreAssembly });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "RequiredMaterial2", ProcessCardClass = ProcessCardClass.CoreAssembly });
            context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "RequiredMaterial3", ProcessCardClass = ProcessCardClass.CoreAssembly });

            context.ProcessCards.Add(new ProcessCard() { ProductName = "TEST1.1A.CB22", ProcessCardClass = ProcessCardClass.CoremakeCB22 });
            context.ProcessCards.Add(new ProcessCard() { ProductName = "TEST1.2A.LAEMPE", ProcessCardClass = ProcessCardClass.CoremakeLaempe });
            context.ProcessCards.Add(new ProcessCard() { ProductName = "TEST1.P01.OSBORN", ProcessCardClass = ProcessCardClass.MoldingOsborn });
            context.ProcessCards.Add(new ProcessCard() { ProductName = "TEST1.PP1", ProcessCardClass = ProcessCardClass.MeltingOsborn });
            context.ProcessCards.Add(new ProcessCard() { ProductName = "TEST1.L1INSPECT", ProcessCardClass = ProcessCardClass.CleaningOsborn });
            context.ProcessCards.Add(new ProcessCard() { ProductName = "TEST1.FINISHING", ProcessCardClass = ProcessCardClass.Finishing });
            context.ProcessCards.Add(new ProcessCard() { ProductName = "TEST1.ASSEMBLY", ProcessCardClass = ProcessCardClass.CoreAssembly });

            SaveChanges(context);

            context.Approvers.Add(new Approver() { Email = "ahoover@grede.com", Name = "Adam Hoover", Title = "Industrial Engineer", WindowsName = @"MirilisPC\Mirilis" });
            var defaultApprover = new Approver() { Email = "blank", Name = "System", Title = "System Process", WindowsName = "blank" };

            context.Approvers.Add(defaultApprover);

                   foreach (var item in context.ProcessCards)
            {
                foreach (var RequiredKeys in context.ProcessCardKeys.Where(x => x.ProcessCardClass == item.ProcessCardClass))
                {
                    item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = context.Approvers.Where(x=>x.Name== "System").First(), Value = "blank", ApprovedDate = DateTime.Now, });
                }
            }

            SaveChanges(context);

        }
        private static void SaveChanges(DbContext context)
        {
                context.SaveChanges();
        }
    }
}
