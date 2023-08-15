using System.Globalization;

namespace SchemeServe;

public static class Utilities
{
    public static DateTime StringToDate(string dateAsString)
    {
        DateTime dateTime;
        if (DateTime.TryParseExact(dateAsString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out dateTime))

        {
            return dateTime;
        }

        else
        {
            throw new ArgumentException("Invalid date format.");
        }
    }

    public static string DateToString(DateTime dateTime)
    {
        string dateAsString = dateTime.ToString("yyyy-MM-dd");
        return dateAsString;
    }

}

