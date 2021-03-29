using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Time
{
    class Time
    {
        public int Ore { get; set; }
        public int Minute { get; set; }
        public int Secunde { get; set; }
        public int Sutimi { get; set; }
        public Time(int ore, int Minute)
        {
            this.Ore = Ore;
            this.Minute = Minute;
        }
        public Time(int Ore, int Minute, int Secunde)
        {
            this.Ore = Ore;
            this.Minute = Minute;
            this.Secunde = Secunde;
        }
        public Time(int Ore, int Minute, int Secunde, int Sutimi)
        {
            this.Ore = Ore;
            this.Minute = Minute;
            this.Secunde = Secunde;
            this.Sutimi = Sutimi;
                
        }
        public Time(string time)
        {
            try
            {
                var values = time.Split(':').Select(Int32.Parse).ToList();
                Ore = values[0];
                Minute = values[1];
                Secunde = values[2];
                Sutimi= values[3];
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid format");
            }
        }
        public static int SutimiinMilisecunde(int sutimi)
        {
            return sutimi * 10;
        }
        public static int SecundeinMilisecunde(int secunde)
        {
            int secundeinSutimi = secunde * 100;
            return SutimiinMilisecunde(secundeinSutimi);
        }
        public static int MinuteinMilisecunde(int minute)
        {
            int minuteinSecunde = minute * 60;
            return SecundeinMilisecunde(minuteinSecunde);
        }
        public static int OrinoMilisecunde(int ore)
        {
            int oreinMinute = ore * 60;
            return MinuteinMilisecunde(oreinMinute);
        }
        public static int TimpinMilisecunde(Time timp)
        {
            return OrinoMilisecunde(timp.Ore) +
                   MinuteinMilisecunde(timp.Minute) +
                   SecundeinMilisecunde(timp.Secunde) +
                   SutimiinMilisecunde(timp.Sutimi);
        }
        public static Time MilisecundesinTimp(int n)
        {
            n /= 10;
            int sutimi = n % 100;
            n /= 100;
            int secunde = n % 60;
            n /= 60;
            int minute = n % 60;
            n /= 60;
            int ore = n;
            return new Time(ore, minute, secunde, sutimi);
        }
        public static Time operator +(Time t1, Time t2)
        {
            int totalMilisecunde = TimpinMilisecunde(t1) + TimpinMilisecunde(t2);
            return MilisecundesinTimp(totalMilisecunde);
        }
        public static Time operator -(Time t1, Time t2)
        {
            int totalMillisecunde = TimpinMilisecunde(t1) - TimpinMilisecunde(t2);
            return MilisecundesinTimp(totalMillisecunde);
        }

        public static bool operator ==(Time t1, Time t2)
        {
            return TimpinMilisecunde(t1) == TimpinMilisecunde(t2);
        }
        public static bool operator !=(Time t1, Time t2)
        {
            return TimpinMilisecunde(t1) != TimpinMilisecunde(t2);
        }
        public static bool operator >(Time t1, Time t2)
        {
            return TimpinMilisecunde(t1) > TimpinMilisecunde(t2);
        }
        public static bool operator <(Time t1, Time t2)
        {
            return TimpinMilisecunde(t1) < TimpinMilisecunde(t2);
        }
        public static bool operator >=(Time t1, Time t2)
        {
            return TimpinMilisecunde(t1) >= TimpinMilisecunde(t2);
        }
        public static bool operator <=(Time t1, Time t2)
        {
            return TimpinMilisecunde(t1) <= TimpinMilisecunde(t2);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Time a = new Time("10:30:25:75");
            Time b = new Time("47:50:40:60");
            Time c = a + b;
            Console.WriteLine("" + c.Ore + " " + c.Minute + " " + c.Secunde + " " + c.Sutimi);
            Console.ReadKey();
        }
    }
}