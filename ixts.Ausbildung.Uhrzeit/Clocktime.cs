using System;

namespace ixts.Ausbildung.Uhrzeit
{
    public class Clocktime
    {
        private readonly int hour;
        private readonly int minute;
        private readonly int second;

        public int Seconds
        {
            get { return second; }
        }

        public int Minutes
        {
            get { return minute; }
        }

        public int Hours
        {
            get { return hour; }
        }

        public Clocktime()
        {
            hour = 0;
            minute = 0;
            second = 0;
        }

        public Clocktime(int h)
        {
            if (h > 0)
            {
                hour = h%24;
            }
            else
            {
                hour = 24 - (Math.Abs(h)%24);
                if (hour == 24)
                {
                    hour = 0;
                }
            }
            
        }

        public Clocktime(int h,int m)
        {
            if (h > 0)
            {
                hour = h % 24;
            }
            else
            {
                hour = 24 - (Math.Abs(h) % 24);
                if (hour == 24)
                {
                    hour = 0;
                }
            }

            if (minute > 0)
            {
                minute = m%60;
                hour += (m -minute)/60;
            }
            else
            {
                minute = 60 - (Math.Abs(h)%60);
                hour -= (Math.Abs(m) - minute)/60;

                if (minute == 60)
                {
                    minute = 0;
                }
            }
        }

        public Clocktime(int h,int m, int s)
        {
            if (h > 0)
            {
                hour = h % 24;
            }
            else
            {
                hour = 24 - (Math.Abs(h) % 24);
                if (hour == 24)
                {
                    hour = 0;
                }
            }
            minute = 0;

            if (s > 0)
            {
                second = s % 60;
                minute += (s - second) / 60;
            }
            else
            {
                second = 60 - (Math.Abs(s) % 60);
                minute -= (Math.Abs(s) - second) / 60;

                if (second == 60)
                {
                    second = 0;
                }
            }

            if (m > 0)
            {
                minute = m % 60;
                hour += (m - minute) / 60;
            }
            else
            {
                minute = 60 - (Math.Abs(m) % 60);

                if (minute == 60)
                {
                    minute = 0;
                }

                hour -= (Math.Abs(m) - minute) / 60;//hier ist der bruch


            }
        }

        public Clocktime(Clocktime ct)
        {
            hour = ct.Hours;
            minute = ct.Minutes;
            second = ct.Seconds;
        }

        public override String ToString()
        {
            return String.Format("{0:00}:{1:00}:{2:00}",hour,minute,second);
        }

        public Boolean Equals(Clocktime ct)
        {
            return second == ct.Seconds && minute == ct.Minutes && hour == ct.Seconds;
        }

        public int HashCode()
        {
            var hashString = String.Format("{0:00}{1:00}{2:00}", hour, minute, second);
            return int.Parse(hashString);
        }

        public Clocktime Add(int s)
        {
            var ss = second;
            var m = minute;
            var h = hour;

            ss += s;
            if (ss > 60)
            {
                var overflow = ss-(ss%60);
                ss = ss%60;
                m += overflow/60;
            }

            if (ss < 0)
            {
                var overflow = ss;
                ss = 60 - Math.Abs(ss%60);
                overflow = Math.Abs(overflow);
                while (overflow > 0)
                {
                    m -= 1;
                    overflow -= 60;
                }
            }

            if (m > 60)
            {
                var overflow = m - (m - (m % 60));
                m = m % 60;
                h = overflow / 60;
            }

            if (m < 0)
            {
                var overflow = m;
                m = 60 - Math.Abs(m % 60);
                overflow = Math.Abs(overflow);
                while (overflow > 0)
                {
                    h -= 1;
                    overflow -= 60;
                }
            }

            if (h >= 24)
            {
                h = h%24;
            }

            if (h < 0)
            {
                h = 24 - (Math.Abs(h) % 24);
                if (h == 24)
                {
                    h = 0;
                }
            }
            return new Clocktime(h,m,ss);
        }

        public int Diff(Clocktime ct)//gibt differenz zwischen beiden zeiten in sekunden zurück
        {
            var seconds = hour*3600 + minute*60 + second;
            var ctseconds = ct.Hours*3600 + ct.Minutes*60 + ct.Seconds;

            var diff = ctseconds - seconds;

            if (diff < 0)
            {
                diff = 86400 + diff;
            }
            return diff;
        }
    }
}
