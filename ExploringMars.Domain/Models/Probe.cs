using ExploringMars.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExploringMars.Domain.Models
{
    public sealed class Probe
    {
        public Plane Plane { get; private set; }
        public Point Coordinates { get; set; }
        public CardinalDirection CardinalDirection { get; set; }

        public Probe(Plane plane, int initialX, int initialY, CardinalDirection initialDirection)
        {
            Plane = plane;
            Coordinates = new Point(initialX, initialY);
            CardinalDirection = initialDirection;
        }

        public string GetPosition()
        {
            return string.Format("{0} {1} {2}", Coordinates.X, Coordinates.Y, CardinalDirection);
        }

        public bool Process(char[] instructions)
        {
            foreach (var item in instructions)
            {
                switch (Enum.Parse<Command>(item.ToString()))
                {
                    case Command.L:
                        switch (CardinalDirection)
                        {
                            case CardinalDirection.N:
                                CardinalDirection = CardinalDirection.W;
                                break;

                            case CardinalDirection.W:
                                CardinalDirection = CardinalDirection.S;
                                break;

                            case CardinalDirection.E:
                                CardinalDirection = CardinalDirection.N;
                                break;

                            case CardinalDirection.S:
                                CardinalDirection = CardinalDirection.E;
                                break;
                        }
                        break;

                    case Command.R:
                        switch (CardinalDirection)
                        {
                            case CardinalDirection.N:
                                CardinalDirection = CardinalDirection.E;
                                break;

                            case CardinalDirection.W:
                                CardinalDirection = CardinalDirection.N;
                                break;

                            case CardinalDirection.E:
                                CardinalDirection = CardinalDirection.S;
                                break;

                            case CardinalDirection.S:
                                CardinalDirection = CardinalDirection.W;
                                break;
                        }
                        break;

                    case Command.M:
                        switch (CardinalDirection)
                        {
                            case CardinalDirection.N:
                                Coordinates.Y++;
                                break;
                            case CardinalDirection.W:
                                Coordinates.X--;
                                break;
                            case CardinalDirection.E:
                                Coordinates.X++;
                                break;
                            case CardinalDirection.S:
                                Coordinates.Y--;
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid probe command!");
                        return false;
                }
            }

            if (Coordinates.X > Plane.Max.X ||
                Coordinates.Y > Plane.Max.Y ||
                Coordinates.X < Plane.Min.X ||
                Coordinates.Y < Plane.Min.Y)
            {
                Console.WriteLine("Probe is out of plane boundary!");
                return false;
            }

            return true;
        }


    }
}
