using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CrimeAnalyzer
{
    public static class MusicStatsReport
    {
        public static string GenerateText(List<MusicStats> musicStatsList)
        {
            string report = "Music Analyzer Report\n\n";

            if (musicStatsList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }

            var startYear = (from musicStats in musicStatsList select musicStats.Year).Min();
            var endYear = (from musicStats in musicStatsList select musicStats.Year).Max();

            //report += $"Period: {startYear}-{endYear} ({musicStatsList.Count} years)\n";

            Console.WriteLine("----------------------------------------------------");
            //Console.WriteLine("Song plays over 200");

            var songPlays = from musicStats in musicStatsList where musicStats.Plays > 200 select musicStats;
            report += "song plays over 200\n";
            foreach (var musicStats in songPlays)
            {
                report += "name: " + musicStats.Name + " artist: " + musicStats.Artist + " album: " + musicStats.Album + " Genre: " + musicStats.Genre + " size: " + musicStats.Size + " time: " + musicStats.Time + " year: " + musicStats.Year + " plays: " + musicStats.Plays + "\n";
            }
            report += "\n";

            report += "amount of alternative songs\n";
            var songAlternerative = (from musicStats in musicStatsList where musicStats.Genre == "Alternative"  select musicStats.Genre);
            
            //report += songAlternerative.Length + "\n";


            report += "\n";




            var welcomeToTheFishbowl = from musicStats in musicStatsList where musicStats.Album == "Welcome to the Fishbowl"  select musicStats;
            report += "welcome to the fishbowl songs\n";
            foreach (var musicStats in welcomeToTheFishbowl)
            {
                report += "name: " + musicStats.Name + " artist: " + musicStats.Artist + " album: " + musicStats.Album + " Genre: " + musicStats.Genre + " size: " + musicStats.Size + " time: " + musicStats.Time + " year: " + musicStats.Year + " plays: " + musicStats.Plays + "\n";
            }
            report += "\n";
            //report += "Years murders per year < 15000:
            report += "song playlist from before 1970\n";
            var years = from musicStats in musicStatsList where musicStats.Year < 1970 select musicStats;
            if (years.Count() > 0)
            {
                foreach (var year in years)
                {
                    report += "name: " + year.Name + " artist: " + year.Artist + " album: " + year.Album + " Genre: " + year.Genre + " size: " + year.Size + " time: " + year.Time + " year: " + year.Year + " plays: " + year.Plays + "\n";

                }
                report.TrimEnd(',');
                report += "\n";
            }
            else
            {
                report += "not available\n";
            }
            report += "\n";
            //report += "Years murders per year < 15000: ";
            report += "songs with names longer than 85 characters\n";
            var musicStatsWithTitlesLongerThan85 = from musicStats in musicStatsList where musicStats.Name.Length > 85 select musicStats;
            foreach (var musicStats in musicStatsWithTitlesLongerThan85)
            {
                report += "name: " + musicStats.Name +  "\n";
            }
            report += "\n";

            report += "Longest song name\n";
            var longestSong = (from musicStats in musicStatsList select musicStats.Time).Max();
            report += $"longest song: {longestSong}\n";

            //report += "Robberies per year > 500000: ";
            /* var records = from musicStats in musicStatsList where musicStats. > 500000 select crimeStats;
             if (records.Count() > 0)
             {
                 foreach (var record in records)
                 {
                     report += record.Year + " = " + record.Robbery + ",";
                 }
                 report.TrimEnd(',');
                 report += "\n";
             }
             else
             {
                 report += "not available\n";
             }

             report += "Violent crime per capita rate (2010): ";
             var violentCrimeRates = from crimeStats in crimeStatsList where crimeStats.Year == 2010 select ((double)(crimeStats.ViolentCrime) / (double)(crimeStats.Population));
             if (violentCrimeRates.Count() > 0)
             {
                 report += violentCrimeRates.First();
                 report += "\n";
             }
             else
             {
                 report += "not available\n";
             }

             var averageMurdersAll = (from crimeStats in crimeStatsList select crimeStats.Murder).Average();
             report += $"Average murder per year (all years): {averageMurdersAll}\n";

             var averageMurders1994_1997 = (from crimeStats in crimeStatsList where crimeStats.Year >= 1994 && crimeStats.Year <= 1997 select crimeStats.Murder).Average();
             report += $"Average murder per year (1994 - 1997): {averageMurders1994_1997}\n";

             var averageMurders2010_2014 = (from crimeStats in crimeStatsList where crimeStats.Year >= 2010 && crimeStats.Year <= 2013 select crimeStats.Murder).Average();
             report += $"Average murder per year (2010 - 2014): {averageMurders2010_2014}\n";

             var minimumThefts = (from crimeStats in crimeStatsList where crimeStats.Year >= 1999 && crimeStats.Year <= 2004 select crimeStats.Theft).Min();
             report += $"Minimum thefts per year (1999 - 2004): {minimumThefts}\n";

             var maximumThefts = (from crimeStats in crimeStatsList where crimeStats.Year >= 1999 && crimeStats.Year <= 2004 select crimeStats.Theft).Max();
             report += $"Maximum thefts per year (1999 - 2004): {maximumThefts}\n";

             report += "Year of highest number of motor vehicle thefts: ";
             var yearMaxMotorVehicleThefts = from crimeStats in crimeStatsList where crimeStats.MotorVehicleTheft == ((from stats in crimeStatsList select stats.MotorVehicleTheft).Max()) select crimeStats.Year;
             if (yearMaxMotorVehicleThefts.Count() > 0)
             {
                 report += yearMaxMotorVehicleThefts.First();
                 report += "\n";
             }
             else
             {
                 report += "not available\n";
             }
             */
            return report;
        }
    }
}
