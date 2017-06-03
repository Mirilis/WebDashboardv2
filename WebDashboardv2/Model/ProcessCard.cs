using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebDashboardv2.Model
{
    public class ProcessCard
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public ProcessCardClass ProcessCardClass { get; set; }

        [NotMapped]
        public string ProcessCardType { get => this.ProcessCardClass.ToString().ToSentenceCase(); }

        public virtual ICollection<DataPoint> DataPoints { get; set; }

        private int dataPointCount;
        [NotMapped]
        public ICollection<DataPoint> CurrentRevision {
            get
            {
                if (currentRevision == null || dataPointCount != DataPoints.Count())
                {
                    var p = DataPoints.OrderByDescending(x => x.ApprovedDate);
                    var a = DataPoints.Select(x => x.Key).Distinct();
                    var result = new List<DataPoint>();
                    foreach (var item in a)
                    {
                        result.Add(p.First(x => x.Key == item));
                    }

                    currentRevision = result.OrderByDescending(x => x.Type).ThenBy(y => y.Key).ToList();
                    dataPointCount = DataPoints.Count();
                }
                return currentRevision;
            }
        }
        private List<DataPoint> currentRevision;
        public ProcessCard()
        {
            DataPoints = new List<DataPoint>();
        }
    }
  
}
