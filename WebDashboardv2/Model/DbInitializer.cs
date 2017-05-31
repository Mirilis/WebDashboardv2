using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace WebDashboardv2.Model
{
    public class DbInitializer
    {
        #region Public Methods

        public static void Initialize(ProcessCardContext context)
        {
            context.Database.EnsureCreated();

            if (!context.BlisProductsView.Any())
            {
                context.Add(new BlisProductsView() { Product = "T1", CastingWeight = "12", Description = "TEST1", Impressions = "2", MoldCenter = "Osborn", PourWeight = "60" });
                context.Add(new BlisProductsView() { Product = "T1", CastingWeight = "12", Description = "TEST1", Impressions = "2", MoldCenter = "Sinto", PourWeight = "60" });
            }

            // Look for any students.
            if (!context.ProcessCardKeys.Any())
            {
                foreach (ProcessCardClass item in Enum.GetValues(typeof(ProcessCardClass)))
                {
                    context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProductName", ProcessCardClass = item });
                    context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "Description", ProcessCardClass = item });
                    context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "Impressions", ProcessCardClass = item });
                    context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "PourWeight", ProcessCardClass = item });
                    context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CastingWeight", ProcessCardClass = item });
                }

                SaveChanges(context);
            }

            var updatekeys = false;
            if (context.ProcessCardKeys.Where(x => x.ProcessCardClass == ProcessCardClass.MeltingOsborn).Count() < 10)
            {
                updatekeys = true;
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "DragImage", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CriticalInstructions", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoresetOrder", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "VentRequirements", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "InMoldInnoculant", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "FilterRequirements", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CorsetFixture", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "PatternLocation", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "DateCodeType", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ShiftCode", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "HourCode", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "SleeveRequirements", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ChapletRequirements", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "VentLocationImage", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "SqueezePressure", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ReamerSize", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "AdditionalInformation", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "North", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "South", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "SprueDrillPreset", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ReleaseButtonRequired", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep1", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep2", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "SpecialInstructions", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep3", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep4", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep5", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep6", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep7", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage2", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage3", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage4", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage5", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage6", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CopeImage", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage1", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "FinalProductImage", ProcessCardClass = ProcessCardClass.MoldingOsborn });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "DragImage", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CriticalInstructions", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoresetOrder", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "VentRequirements", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "InMoldInnoculant", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "FilterRequirements", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CorsetFixture", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "PatternLocation", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "DateCodeType", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ShiftCode", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "HourCode", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "SleeveRequirements", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ChapletRequirements", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "VentLocationImage", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "SqueezePressure", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ReamerSize", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "AdditionalInformation", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "North", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "South", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "SprueDrillPreset", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ReleaseButtonRequired", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep1", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep2", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "SpecialInstructions", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep3", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep4", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep5", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep6", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "ProcessStep7", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage2", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage3", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage4", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage5", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage6", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CopeImage", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "CoreImage1", ProcessCardClass = ProcessCardClass.MoldingSinto });
                context.ProcessCardKeys.Add(new ProcessCardKey() { Key = "FinalProductImage", ProcessCardClass = ProcessCardClass.MoldingSinto });
            }

            if (!context.ProcessCards.Any())
            {
                foreach (var product in context.BlisProductsView)
                {
                    context.ProcessCards.Add(new ProcessCard() { ProductName = product.Product, ProcessCardClass = ProcessCardClass.Finishing });
                    if (product.MoldCenter == "Sinto")
                    {
                        context.ProcessCards.Add(new ProcessCard() { ProductName = product.Product, ProcessCardClass = ProcessCardClass.CleaningSinto });
                        context.ProcessCards.Add(new ProcessCard() { ProductName = product.Product, ProcessCardClass = ProcessCardClass.MoldingSinto });
                        context.ProcessCards.Add(new ProcessCard() { ProductName = product.Product, ProcessCardClass = ProcessCardClass.MeltingSinto });
                    }
                    else
                    {
                        context.ProcessCards.Add(new ProcessCard() { ProductName = product.Product, ProcessCardClass = ProcessCardClass.MoldingOsborn });
                        context.ProcessCards.Add(new ProcessCard() { ProductName = product.Product, ProcessCardClass = ProcessCardClass.MeltingOsborn });
                        context.ProcessCards.Add(new ProcessCard() { ProductName = product.Product, ProcessCardClass = ProcessCardClass.CleaningOsborn });
                    }
                }

                SaveChanges(context);
            }

            if (!context.Approvers.Any())
            {
                var s = "11111111111";
                var i = Convert.ToInt32(s, 2);
                context.Approvers.Add(new Approver() { Email = "ahoover@grede.com", Name = "Adam Hoover", Title = "Industrial Engineer", WindowsName = @"GREDEW2K\AHOOVER", ValidAccess = (ApproverAccess)i });
                context.Approvers.Add(new Approver() { Email = "ahoover@grede.com", Name = "Adam Hoover", Title = "Industrial Engineer", WindowsName = @"MIRILISPC\MIRILIS", ValidAccess = (ApproverAccess)i });
                var defaultApprover = new Approver() { Email = "blank", Name = "System", Title = "System Process", WindowsName = "blank" };

                context.Approvers.Add(defaultApprover);

                SaveChanges(context);
            }

            if (!context.DataPoints.Any())
            {
                var ali = context.BlisProductsView.ToList();
                var p = context.ProcessCards.ToList();
                foreach (var item in p)
                {
                    var b = context.Approvers.Where(x => x.Name == "System").First();
                    var a = ali.Where(x => x.Product == item.ProductName).First();
                    var i = context.ProcessCardKeys.Where(x => x.ProcessCardClass == item.ProcessCardClass).ToList();
                    foreach (var RequiredKeys in i)
                    {
                        switch (RequiredKeys.Key)
                        {
                            case "ProductName":
                                item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = b, Value = a.Product, Type = "string", ApprovedDate = DateTime.Now, });
                                break;

                            case "Description":
                                item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = b, Value = a.Description, Type = "string", ApprovedDate = DateTime.Now, });
                                break;

                            case "Impressions":
                                if (item.ProcessCardClass == ProcessCardClass.MoldingOsborn || item.ProcessCardClass == ProcessCardClass.MoldingSinto)
                                {
                                    item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = b, Value = a.Impressions, Type = "string", ApprovedDate = DateTime.Now, });
                                }
                                break;

                            case "PourWeight":
                                if (item.ProcessCardClass == ProcessCardClass.MeltingOsborn || item.ProcessCardClass == ProcessCardClass.MeltingSinto)
                                {
                                    item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = b, Value = a.PourWeight, Type = "string", ApprovedDate = DateTime.Now, });
                                }
                                break;

                            case "CastingWeight":
                                if (item.ProcessCardClass == ProcessCardClass.CleaningOsborn || item.ProcessCardClass == ProcessCardClass.CleaningSinto || item.ProcessCardClass == ProcessCardClass.Finishing)
                                {
                                    item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = b, Value = a.CastingWeight, Type = "string", ApprovedDate = DateTime.Now, });
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    item.DataPoints.Add(new DataPoint() { Key = "Logo", Approver = b, ApprovedDate = DateTime.Now, Type = "image", Value = "blank" });
                    SaveChanges(context);
                }
                
            }
            //if (updatekeys)
            //{
            //    var ali = context.BlisProductsView.ToList();
            //    var p = context.ProcessCards.ToList();
            //    var b = context.Approvers.Where(x => x.Name == "System").First();
            //    foreach (var item in p)
            //    {
                   
            //        var a = ali.Where(x => x.Product == item.ProductName).First();
            //        var i = context.ProcessCardKeys.Where(x => x.ProcessCardClass == item.ProcessCardClass).ToList();
            //        foreach (var RequiredKeys in i)
            //        {
            //            if (RequiredKeys.Key != "ProductName" || RequiredKeys.Key != "Description" || RequiredKeys.Key != "Impressions" || RequiredKeys.Key != "PourWeight" || RequiredKeys.Key != "CastingWeight")
            //            {
            //                if (RequiredKeys.Key.Contains("Image"))
            //                {
            //                    item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = b, ApprovedDate = DateTime.Now, Type = "image", Value = "blank" });
            //                }
            //                else
            //                {
            //                    item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = b, ApprovedDate = DateTime.Now, Type = "string", Value = "blank" });
            //                }
                        
                            


            //            }
            //        }
                    
            //        SaveChanges(context);
            //    }
            //}
            }

        #endregion Public Methods

        #region Private Methods

        private static void SaveChanges(DbContext context)
        {
            context.SaveChanges();
        }

        #endregion Private Methods
    }
}