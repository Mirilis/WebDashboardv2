using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace WebDashboardv2.Model
{
    [Table("ProductionWithBHNByPartAndDay")]
    public class ProductionHardness
    {
        [Key]
        public int ID { get; set; }
        public string Product { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public int? BHNCount { get; set; }
        public double? Minimum { get; set; }
        public double? Max { get; set; }
        public string HTCode { get; set; }
        public double? RangeLow { get; set; }
        public double? RangeHigh { get; set; }
        public string DateCode { get; set; }
        [NotMapped]
        public int RecordCount
        {
            get
            {
                if (BHNCount.HasValue)
                {
                    return BHNCount.Value;
                }
                else
                {
                    return 0;
                }
            }
        }
        [NotMapped]
        public double MinReading
        {
            get
            {
                if (Minimum.HasValue)
                {
                    return Minimum.Value;
                }
                else
                {
                    return 0;
                }
            }
        }
        [NotMapped]
        public double MaxReading
        {
            get
            {
                if (Max.HasValue)
                {
                    return Max.Value;
                }
                else
                {
                    return 0;
                }
            }
        }
        [NotMapped]
        public double MaxAllowable
        {
            get
            {
                if (RangeHigh.HasValue)
                {
                    return RangeHigh.Value;
                }
                else
                {
                    return 0;
                }
            }
        }
        [NotMapped]
        public double MinAllowable
        {
            get
            {
                if (RangeLow.HasValue)
                {
                    return RangeLow.Value;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}