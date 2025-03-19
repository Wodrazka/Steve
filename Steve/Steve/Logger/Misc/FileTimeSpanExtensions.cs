namespace Steve.Logger.Misc;

using System.Globalization;

public static class FileTimeSpanExtensions
{

    public static string GetDateTimeString(this FileTimeSpan fileTimeSpan)
    {
        var date = DateTime.Now;

        return fileTimeSpan switch
        {
            FileTimeSpan.DAY => date.ToString("dd_MM_yyyy", CultureInfo.InvariantCulture),
            FileTimeSpan.WEEK => $"{CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday)}_{date:yyyy}",
            FileTimeSpan.MONTH => date.ToString("MM_yyyy", CultureInfo.InvariantCulture),
            FileTimeSpan.YEAR => date.ToString("yyyy", CultureInfo.InvariantCulture),
            FileTimeSpan.INFINITY => "",
            _ => "",
        };
    }

}
