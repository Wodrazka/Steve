using System.Globalization;

namespace Steve.Logger.Misc
{
    public static class FileTimeSpanExtensions
    {

        public static string GetDateTimeString(this FileTimeSpan fileTimeSpan)
        {
            var date = DateTime.Now;

            return fileTimeSpan switch
            {
                FileTimeSpan.DAY => date.ToString("dd_MM_yyyy"),
                FileTimeSpan.WEEK => $"{CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday)}_{date:yyyy}",
                FileTimeSpan.MONTH => date.ToString("MM_yyyy"),
                FileTimeSpan.YEAR => date.ToString("yyyy"),
                FileTimeSpan.INFINITY => "",
                _ => "",
            };
        }

    }
}
