namespace PortugalSalarySimulator.Features;

public static class DateExtensions
{
    public static DateTime StartOfMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1, 0, 0, 0);
    }

    public static DateTime EndOfMonth(this DateTime date)
    {
        return date.StartOfMonth().AddMonths(1).AddSeconds(-1);
    }
    public static IEnumerable<DateTime> DaysBetween(DateTime start, DateTime end)
    {
        var current = start;
        if (current != current.Date) //handle the case where the date isn't already midnight
            current = current.AddDays(1).Date;
        while (current < end)
        {
            yield return current;
            current = current.AddDays(1);
        }
    }
    public static IEnumerable<DateTime> WorkDayBetween(DateTime start, DateTime end)
    {
        return DaysBetween(start, end)
            .Where(IsWorkDay);
    }

//feel free to use alternate logic here, or to account for holidays, etc.
    private static bool IsWorkDay(DateTime date)
    {
        return date.DayOfWeek != DayOfWeek.Saturday
               && date.DayOfWeek != DayOfWeek.Sunday;
    }
}