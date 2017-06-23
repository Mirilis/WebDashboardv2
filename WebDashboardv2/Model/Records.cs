using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDashboardv2.Model
{
    [Table("ValidRecords")]
    public class Record
    {
        [Key]
        public int ID { get; set; }
        public string Product { get; set; }
        public string CastDateString { get; set; }
        public DateTime? CastDate { get; set; }
        public DateTime? ReadingDate { get; set; }
        public double Reading { get; set; }
        public string Customer { get; set; }
        public string Range { get; set; }
        public string Specification { get; set; }
        public string HeatTreated { get; set; }
        public string CavityNumber { get; set; }
        public string ShiftAmount { get; set; }
        public string Comment { get; set; }


        static public implicit operator Record(SuspectRecord s)
        {
            return new Record()
            {
                CastDate = s.CastDate,
                CastDateString = s.CastDateString,
                CavityNumber = s.CavityNumber,
                Comment = s.Comment,
                ShiftAmount = s.ShiftAmount,
                Customer = s.Customer,
                Specification = s.Specification,
                HeatTreated = s.HeatTreated,
                Product = s.Product,
                Range = s.Range,
                Reading = s.Reading,
                ReadingDate = s.ReadingDate
            };

        }
    }

    public class SuspectRecord
    {
        [Key]
        public int ID { get; set; }
        public string Product { get; set; } = string.Empty;
        public string CastDateString { get; set; } = string.Empty;
        public DateTime? CastDate { get; set; }
        public DateTime? ReadingDate { get; set; }
        public double Reading { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Range { get; set; } = string.Empty;
        public string Specification { get; set; } = string.Empty;
        public string HeatTreated { get; set; } = string.Empty;
        public string CavityNumber { get; set; } = string.Empty;
        public string ShiftAmount { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        [NotMapped]
        public double HighWarn { get; set; }
        [NotMapped]
        public double LowWarn { get; set; }
        [NotMapped]
        public double LowTol { get; set; }
        [NotMapped]
        public double HighTol { get; set; }
        static public implicit operator SuspectRecord(HistoricalRecord s)
        {
            return new SuspectRecord()
            {
                CastDate = s.CastDate,
                CastDateString = s.CastDateString,
                CavityNumber = s.CavityNumber,
                Comment = s.Comment,
                ShiftAmount = s.ShiftAmount,
                Customer = s.Customer,
                Specification = s.Specification,
                HeatTreated = s.HeatTreated,
                Product = s.Product,
                Range = s.Range,
                Reading = s.Reading,
                ReadingDate = s.ReadingDate
            };

        }
    }

    public class HistoricalRecord
    {
        [Key]
        public int ID { get; set; }
        public string Product { get; set; }
        public string CastDateString { get; set; }
        public DateTime? CastDate { get; set; }
        public DateTime? ReadingDate { get; set; }
        public double Reading { get; set; }
        public string Customer { get; set; }
        public string Range { get; set; }
        public string Specification { get; set; }
        public string HeatTreated { get; set; }
        public string CavityNumber { get; set; }
        public string Comment { get; set; }
        public string ShiftAmount { get; set; }

        static public implicit operator HistoricalRecord(SuspectRecord s)
        {
            return new HistoricalRecord()
            {
                CastDate = s.CastDate,
                CastDateString = s.CastDateString,
                CavityNumber = s.CavityNumber,
                Comment = s.Comment,
                ShiftAmount = s.ShiftAmount,
                Customer = s.Customer,
                Specification = s.Specification,
                HeatTreated = s.HeatTreated,
                Product = s.Product,
                Range = s.Range,
                Reading = s.Reading,
                ReadingDate = s.ReadingDate
            };

        }
    }

    [Table("BossRangeData")]
    public class RangeData
    {
        [Key]
        public int ID { get; set; }
        public string Product { get; set; }
        public string Specification { get; set; }
        public double? RangeLow { get; set; }
        public double? RangeHigh { get; set; }
        public double? LowWarn { get; set; }
        public double? HighWarn { get; set; }
        
    }

    public class FileManagerHistory
    {
        [Key]
        public int ID { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
        public string FileData { get; set; }
    }
}