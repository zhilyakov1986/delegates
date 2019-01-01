﻿using System;

namespace CarEventsCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***Fun with the events");
            Car c1 = new Car(10, 100, "SlugBug");

            // register event handlers
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;

            Console.WriteLine("***Speeding Up***");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            Console.ReadLine();
            // Remove CarExploded method from invocation list
            c1.Exploded -= CarExploded;

            Console.WriteLine("\n****Speeding UP ****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        private static void CarExploded(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine($"=> Critical Message from Car: {msg.ToUpper()}");
        }

        private static void CarAboutToBlow(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
