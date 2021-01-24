using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public DateModifier(string date)
        {
            this.Date = date;
        }
        public string Date { get; set; }
        public static string Difference(string firstDate,string secondDate)
        {
            var dateFirst = firstDate.Split(" ");
            var secondFirst = secondDate.Split(" ");
            var first = new DateTime(int.Parse(dateFirst[0]), int.Parse(dateFirst[1]), int.Parse(dateFirst[2]));
            var second = new DateTime(int.Parse(secondFirst[0]), int.Parse(secondFirst[1]), int.Parse(secondFirst[2]));
            string difference = Math.Abs((second - first).TotalDays).ToString();
            return difference;           
        }
    }
}
