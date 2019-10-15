using ExploringMars.Domain.Enums;
using ExploringMars.Domain.Models;
using System;
using System.IO;
using System.Text;

namespace ExploringMars
{
    class Program
    {
        static void Main(string[] args)
        {       
            if (args.Length > 0 && File.Exists(args[0]))
            {
                using (var sr = new StreamReader(args[0], Encoding.Default))
                {
                    var plane = new Plane();
                    while (!sr.EndOfStream)
                    {
                        var instructions = sr.ReadLine().Split(' ');
                        switch (instructions.Length)
                        {
                            case 0:
                            default:
                                Console.WriteLine("Invalid instruction");
                                break;

                            case 1:
                                //always process last probe
                                var probe = plane.Probes.FindLast(x => x.Coordinates != null);

                                var success = probe.Process(instructions[0].ToCharArray());

                                if (success)
                                {
                                    Console.WriteLine(probe.GetPosition());
                                }
                                break;

                            case 2:
                                plane.Max = new Point(int.Parse(instructions[0]), int.Parse(instructions[1]));
                                break;

                            case 3:
                                plane.Probes.Add(new Probe(plane,
                                                            int.Parse(instructions[0]),
                                                            int.Parse(instructions[1]),
                                                            Enum.Parse<CardinalDirection>(instructions[2])));
                                break;
                        }
                    }
                }
                Console.Read();
            }
            else
            {
                Console.WriteLine("Invalid input file");
            }
        }
    }
}
