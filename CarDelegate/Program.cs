using System;

namespace CarDelegate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Car c1 = new Car();
            //register the simple method name
            c1.RegisterWithCarEngine(CallMeHere);
            Console.WriteLine("***Speeding UP***");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            c1.UnregisterWithCarEngine(CallMeHere);
        }


        private static void CallMeHere(string msgforcaller)
        {
            throw new NotImplementedException();
        }


        //--------------------------------------------------------------
        //{
        //    // create car
        //    Car c1 = new Car(10, 100, "SlugBug");

        //    // tell the car which method to call
        //    // when it wants us send us messages
        //    c1.RegisterWithCarEngine(OnCarEngineEvent);

        //    // hold onto delegate object, so we can unregistered it later
        //    Car.CarEngineHandler handler2 = OnCarEngineEvent2;
        //    c1.RegisterWithCarEngine(handler2);
        //    // speed up (this will trigger the events)
        //    Console.WriteLine("***Speeding Up***");
        //    for (int i = 0; i < 6; i++)
        //    {
        //        c1.Accelerate(20);
        //    }
        //    // unregistered second handler
        //    c1.UnregisterWithCarEngine(handler2);

        //    // We won't see the "uppercase" message anymore!
        //    Console.WriteLine("***Speeding Up***");
        //    for (int i = 0; i < 6; i++)
        //    {
        //        c1.Accelerate(20);
        //    }
        //}


        //private static void OnCarEngineEvent2(string msgforcaller)
        //{
        //    Console.WriteLine($"=>{msgforcaller.ToUpper()}");
        //}

        //// this is the target for incoming events
        //public static void OnCarEngineEvent(string msg)
        //{
        //    Console.WriteLine("\n*** Message From Car Object ***");
        //    Console.WriteLine($"=>{msg}");
        //    Console.WriteLine("********************************\n");
        //}

    }
}
