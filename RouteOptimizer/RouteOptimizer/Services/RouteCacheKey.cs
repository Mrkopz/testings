using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteOptimizer.Services
{
    /// <summary>
    /// Model for use as cache key.
    /// </summary>
    public class RouteCacheKey
    {
        public string From { get; set; }

        public string To { get; set; }

        public DateTime Date { get; set; }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + From.GetHashCode();
            hash = (hash * 7) + To.GetHashCode();
            hash = (hash * 7) + Date.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as RouteCacheKey;

            if (other != null)
            {
                return this.From == other.From
                    && this.To == other.To
                    && this.Date == other.Date;
            }

            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{From}:{To}:{Date.ToString("yyyyMMdd")}";
        }
    }
}
