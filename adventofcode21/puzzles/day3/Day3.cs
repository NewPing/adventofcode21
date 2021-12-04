using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode21.puzzles
{
    internal class Day3
    {
        public Day3()
        {
            diagnostics1();
            diagnostics2();
        }

        public void diagnostics1()
        {
            var binaryDiagnose = File.ReadAllLines("puzzles/day3/binary diagnostics.txt");
            var gammaRate = "";
            var epsilonRate = "";

            for (int i = 0; i < binaryDiagnose[0].Length; i++)
            {
                var ones = 0;
                var zeros = 0;
                foreach (var reading in binaryDiagnose)
                {
                    if (reading[i].Equals('0'))
                    {
                        zeros++;
                    } else
                    {
                        ones++;
                    }
                }
                if (ones > zeros)
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                } else
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
            }

            Console.WriteLine($"power consumtion: { Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2) }");
        }

        public void diagnostics2()
        {
            var binaryDiagnose = File.ReadAllLines("puzzles/day3/binary diagnostics.txt");
            var oxygenGeneratorRating = diagnoseRating(binaryDiagnose.ToList(), true);
            var co2ScrubberRating = diagnoseRating(binaryDiagnose.ToList(), false);

            Console.WriteLine($"life support rating: { Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(co2ScrubberRating, 2) }");
        }

        /// <summary>
        /// diagnoses binary diagnose data for oxygen generator and co0 scrubber
        /// </summary>
        /// <param name="binaryDiagnose"></param> list of strings containing binary data (must all have the same length)
        /// <param name="isOxygenDiagnose"></param> determines if the diagnosis is for oxygen generator or co0 scrubber
        /// <returns>rating</returns>
        /// <exception cref="Exception"></exception>
        private string diagnoseRating(List<string> binaryDiagnose, bool isOxygenDiagnose)
        {
            var currentDiagnosticData = binaryDiagnose;
            var foundReading = false;

            for (int bitPos = 0; !foundReading; bitPos++)
            {
                var ones = new List<string>();
                var zeros = new List<string>();

                if ((bitPos < binaryDiagnose[0].Length) && (currentDiagnosticData.Count > 1))
                {
                    foreach (var reading in currentDiagnosticData)
                    {
                        if (reading[bitPos].Equals('0'))
                        {
                            zeros.Add(reading);
                        }
                        else
                        {
                            ones.Add(reading);
                        }
                    }
                    if (isOxygenDiagnose)
                    {
                        if (ones.Count > zeros.Count)
                        {
                            currentDiagnosticData = ones;
                        }
                        else if (zeros.Count > ones.Count)
                        {
                            currentDiagnosticData = zeros;
                        } else
                        {
                            currentDiagnosticData = ones;
                        }
                    } else
                    {
                        if (ones.Count > zeros.Count)
                        {
                            currentDiagnosticData = zeros;
                        }
                        else if (zeros.Count > ones.Count)
                        {
                            currentDiagnosticData = ones;
                        }
                        else
                        {
                            currentDiagnosticData = zeros;
                        }
                    }                    
                } else
                {
                    foundReading = true;
                }
            }

            return currentDiagnosticData[0];
        }
    }
}
