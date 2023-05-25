using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheatherApp
{
    internal class Program
    {
        private static string city = string.Empty;

        private static void Main(string[] args)
        {
            while (true)
                ShowWeather(null);
        }

        private static void ShowWeather(dynamic weather)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------");
            Console.WriteLine("| Weather App |");
            Console.WriteLine("---------------");

            Console.ForegroundColor = ConsoleColor.Blue;
            if (weather == null)
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("| No data to display the weather! |");
                Console.WriteLine("---------------------------------");
            }
            else
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine($"Current weather in [");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(city);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("]");

                foreach (var day in weather.days)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Date -> {day.datetime}:");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine($"    *Conditions -> {day.conditions}");
                    Console.WriteLine($"    *Average temperature of day -> {ToCelsius(day.temp)} C");
                    Console.WriteLine($"    *Min temperature of day -> {ToCelsius(day.tempmin)} C");
                    Console.WriteLine($"    *Max temperature of day -> {ToCelsius(day.tempmax)} C");
                    Console.WriteLine($"    *Humidity -> {day.humidity} %");
                    Console.WriteLine($"    *Description -> {day.description}");
                    Console.WriteLine($"    *Wind speed -> {day.windspeed} Km/h");
                    Console.WriteLine($"    *Wind direction -> {day.winddir}° ");
                    Console.WriteLine($"    *Pressure -> {day.pressure} Pa");

                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n-----------------------------------");
            }

            Input();
        }

        private async static void LoadWeather()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("Getting weather...");

            Weather weather = new Weather();
            weather.City = city;
            weather.API = "F3CQY7DYEVNNPRC8FSVPNKPXK";

            if (await weather.GetWeather())
                ShowWeather(weather.CurrentWeather);
            else
                ShowWeather(null);
        }

        private static void Input()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("\nPodaj miasto: ");
            city = Console.ReadLine();

            LoadWeather();
        }

        private static float ToCelsius(dynamic value)
        {
            float temp = ((float)value - 32f) * (5f / 9f);
            return (float)Math.Round(temp, 1);
        }
    }
}
