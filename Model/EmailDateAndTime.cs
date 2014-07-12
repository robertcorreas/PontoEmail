using System;

namespace Model
{
    public class EmailDateAndTime
    {
        public DateTime StartHour { get; private set; }

        public DateTime EndHour { get; private set; }

        public DateTime Day { get; private set; }

        public EmailDateAndTime(DateTime day, DateTime startHour, DateTime endHour)
        {
            Day = day;
            StartHour = startHour;
            EndHour = endHour;
        }

        public DateTime GetStartEmailDateTime()
        {
            var r = new Random();

            var newStartHour = Day.AddHours(StartHour.Hour);
            var newStartMinute = Day.AddMinutes(StartHour.Minute + r.Next(-5, 5));

            return Day.AddHours(newStartHour.Hour).AddMinutes(newStartMinute.Minute);
        }

        public DateTime GetEndEmailDateTime()
        {
            var r = new Random();
            var newEndHour = Day.AddHours(EndHour.Hour);
            var newEndMinute = Day.AddMinutes(EndHour.Minute + r.Next(-5, 5));

            return Day.AddHours(newEndHour.Hour).AddMinutes(newEndMinute.Minute);
        }
    }
}