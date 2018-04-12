using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlappedDate
{
    class Program
    {
        private const string _formatDate = "yyyyMMdd";

        static void Main(string[] args)
        {
            var isOverlap = IsOverlapped("20180401", "20180412", "20180409", "20180420");

            Console.WriteLine(isOverlap);
            Console.ReadLine();
        }

        private static bool IsOverlapped(string start1, string end1, string start2, string end2)
        {
            var startDate1 = DateTime.ParseExact(start1, _formatDate, CultureInfo.InvariantCulture);
            var endDate1 = DateTime.ParseExact(end1, _formatDate, CultureInfo.InvariantCulture);
            var startDate2 = DateTime.ParseExact(start2, _formatDate, CultureInfo.InvariantCulture);
            var endDate2 = DateTime.ParseExact(end2, _formatDate, CultureInfo.InvariantCulture);

            return startDate1 < endDate2 && startDate2 < endDate1;
        }
    }
}
