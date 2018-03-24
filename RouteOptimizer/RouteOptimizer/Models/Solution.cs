using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteOptimizer.Models
{
    /// <summary>
    /// For store solution result.
    /// </summary>
    public class Solution
    {
        public TimeSpan TotalInterval
        {
            get
            {
                return TimeSpan.FromSeconds(Sequence
                    .Sum(x => x.TransitInterval.TotalSeconds))
                    + TimeSpan.FromSeconds(Sequence
                    .Sum(x => x.WaitingInterval.TotalSeconds));
            }
        }

        public TimeSpan TotalTransitInterval
        {
            get
            {
                return TimeSpan.FromSeconds(Sequence
                    .Sum(x => x.TransitInterval.TotalSeconds));
            }
        }

        public TimeSpan TotalWaitingInterval
        {
            get
            {
                return TimeSpan.FromSeconds(Sequence
                    .Sum(x => x.WaitingInterval.TotalSeconds));
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return Sequence.Sum(s => s.Price);
            }
        }

        public List<Route> Sequence { get; set; }

        public string Currency { get; set; }

        public Solution()
        {
            Sequence = new List<Route>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine($"Total interval : {TotalInterval}");
            sb.AppendLine($"Total transit interval : {TotalTransitInterval}");
            sb.AppendLine($"Total waiting interval : {TotalWaitingInterval}");
            sb.AppendLine($"Total price : {TotalPrice.ToString("N2")} {Currency}");
            
            foreach(var item in Sequence)
            {
                
                sb.AppendLine($"{item.From} -> {item.To}");
                sb.AppendLine($"\t{string.Join(" -> ", item.Flights)}");
                sb.AppendLine($"\t{item.DepartDateTime} -> {item.ArriveDateTime}");
                sb.AppendLine($"\t\tWaiting interval {item.WaitingInterval}\tTransit interval {item.TransitInterval}");
                sb.AppendLine($"\t{item.Price.ToString("N2")} {Currency}");
            }

            sb.AppendLine();

            return sb.ToString();
        }
    }
}
