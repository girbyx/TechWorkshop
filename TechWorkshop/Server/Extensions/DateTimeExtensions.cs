using System;

namespace TechWorkshop.Server.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsItWeekend(this DateTime originalDate)
        {
            return originalDate.DayOfWeek == DayOfWeek.Saturday || originalDate.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime NextDayOfWeek(this DateTime originalDate)
        {
            var startDate = DateTime.Now > originalDate ? DateTime.Now : originalDate;
            var timePassed = startDate.TimeOfDay > originalDate.TimeOfDay;
            var addDays = timePassed ? 1 : 0;
            do
            {
                var nextDate = startDate.AddDays(addDays);
                if (originalDate.DayOfWeek == nextDate.DayOfWeek)
                    return new DateTime(nextDate.Year, nextDate.Month, nextDate.Day, originalDate.Hour,
                        originalDate.Minute, originalDate.Second, originalDate.Millisecond);
                addDays++;
            } while (true);
        }
    }
}