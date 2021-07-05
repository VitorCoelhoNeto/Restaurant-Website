using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labb.Models
{
    public class Time
    {
        public int Hour { get; }
        public int Minute { get; }
        public Time()
        {
            Hour = 0;
            Minute = 0;
        }
        public Time(int hour, int minute)
        {
            if(hour < 24)
            {
                this.Hour = hour;
            }
            else
            {
                this.Hour = 0;
            }
            if(minute < 60)
            {
                this.Minute = minute;
            }
            else
            {
                this.Minute = 0;
            }
        }
        public Time(Time copy)
        {
            this.Hour = copy.Hour;
            this.Minute = copy.Minute;
        }
        public static Time Parse(string parsestring)
        {
            Regex timeregex = new Regex(@"(([0-9]{1,2}):([0-9]{1,2}))[ ]?(AM|PM|am|pm)?");
            if (timeregex.IsMatch(parsestring))
            {
                Match times = timeregex.Match(parsestring);
                int hour = 0;
                int minutes = 0;
                try
                {
                    if (int.Parse(times.Groups[2].Value) < 24)
                    {
                        if(!string.IsNullOrEmpty(times.Groups[4].Value) && times.Groups[4].Value.ToLower() == "pm")
                        {

                            hour = int.Parse(times.Groups[2].Value) + 12;
                            if(hour > 24)
                            {
                                return null;
                            }
                        }
                        else
                        {
                            hour = int.Parse(times.Groups[2].Value);
                        }
                    }
                    else
                    {
                        return null;
                    }
                    if(int.Parse(times.Groups[3].Value) < 60)
                    {
                        minutes = int.Parse(times.Groups[3].Value);
                    }
                    else
                    {
                        return null;
                    }
                    Time final = new Time(hour, minutes);
                    return final;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public override string ToString()
        {
            string hour = this.Hour.ToString();
            if(this.Hour < 10)
            {
                hour = "0" + hour;
            }
            string minute = this.Minute.ToString();
            if(this.Minute < 10)
            {
                minute = "0" + minute;
            }
            return $"{hour}:{minute}";
        }
    }
}
