using DriverReport.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverReport.Managers
{
    public class ReportManager
    {
        public async Task<IEnumerable<DriverModel>> ProcessInputFile(string file)
        {
            List<DriverModel> drivers = new List<DriverModel>();
            Dictionary<string, TripRunningTotalsModel> runningTotals = new Dictionary<string, TripRunningTotalsModel>();

            //var fileText = new StringBuilder();
            //using (var reader = new StreamReader(file.OpenReadStream()))
            //{
            //while (reader.Peek() >= 0)
            //{
            //fileText.AppendLine(await reader.ReadLineAsync());
            string[] lines = file.Split("\r\n");
            foreach (var line in lines)
            {
                //string line = await reader.ReadLineAsync();
                string[] fields = line.Split(" ");

                if (fields[0].Equals("Driver"))
                {
                    //drivers.Add(new DriverModel(fields[1]));
                    runningTotals.Add(fields[1], new TripRunningTotalsModel());
                }
                else if (fields[0].Equals("Trip"))
                {
                    string driverName = fields[1];
                    TimeSpan startTime = TimeSpan.Parse(fields[2]);
                    TimeSpan endTime = TimeSpan.Parse(fields[3]);
                    double distance = double.Parse(fields[4]);
                    var minutes = (int)(endTime - startTime).TotalMinutes;
                    double speed = distance / TimeSpan.FromMinutes(minutes).TotalHours;

                    if (speed >= 5 && speed <= 100)
                    {
                        var totals = runningTotals.GetValueOrDefault(driverName);
                        totals.Distance += distance;
                        totals.Minutes += minutes;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Command! Ignored.");
                }
                //}
                //}
            }

            foreach (KeyValuePair<string, TripRunningTotalsModel> entry in runningTotals)
            {
                //double speed = entry.Value.Distance / (entry.Value.Minutes / 60);
                double speed = entry.Value.Distance / TimeSpan.FromMinutes(entry.Value.Minutes).TotalHours;
                drivers.Add(new DriverModel(entry.Key, (int)Math.Round(entry.Value.Distance, 0), (int)Math.Round(speed, 0)));
            }

            return drivers;
        }
    }
}
