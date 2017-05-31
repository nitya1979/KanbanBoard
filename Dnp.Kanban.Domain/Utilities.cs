using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.Domain
{
    public class Utilities
    {
        public static DateTime GetWeekendDate(DateTime date)
        {
            
            int daysToWeekend = 5 - (int)date.DayOfWeek;

            return date.AddDays(daysToWeekend);
        }
    }
}
