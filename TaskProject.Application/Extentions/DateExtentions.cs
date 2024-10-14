using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Application.Extentions
{
    public static class DateExtentions
    {
        public static string Toshamsi(this DateTime date)
        {
            var persianCalender = new PersianCalendar();
            return $"{persianCalender.GetYear(date)}/{persianCalender.GetMonth(date).ToString("00")}/{persianCalender.GetDayOfMonth(date).ToString("00")}";
        }

        public static DateTime ToMiladi(this string date)
        {
            var splitDate = date.Split('/');
            var year = Convert.ToInt32(splitDate[0]);
            var month = Convert.ToInt32(splitDate[1]);
            var day = Convert.ToInt32(splitDate[2]);

            return new DateTime(year, month, day, new PersianCalendar());

        }

    }
}
