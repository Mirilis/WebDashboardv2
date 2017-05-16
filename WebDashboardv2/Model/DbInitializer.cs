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
            { var s = "11111111111";
                var i = Convert.ToInt32(s, 2);
                context.Approvers.Add(new Approver() { Email = "ahoover@grede.com", Name = "Adam Hoover", Title = "Industrial Engineer", WindowsName = @"GREDEW2K\AHOOVER", ValidAccess = (ApproverAccess)i });
                context.Approvers.Add(new Approver() { Email = "ahoover@grede.com", Name = "Adam Hoover", Title = "Industrial Engineer", WindowsName = @"MIRILISPC\MIRILIS", ValidAccess= (ApproverAccess)i });
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
                                item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = b, Value = a.Impressions, Type = "string", ApprovedDate = DateTime.Now, });
                                break;

                            case "PourWeight":

                                item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = b, Value = a.PourWeight, Type = "string", ApprovedDate = DateTime.Now, });
                                break;

                            case "CastingWeight":

                                item.DataPoints.Add(new DataPoint() { Key = RequiredKeys.Key, Approver = b, Value = a.CastingWeight, Type="string", ApprovedDate = DateTime.Now, });
                                break;

                            default:
                                break;
                        }
                    }
                    item.DataPoints.Add(new DataPoint() { Key = "Logo", Approver = b, ApprovedDate = DateTime.Now, Type = "image", Value = "blank" });
                    SaveChanges(context);
                }
            }
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