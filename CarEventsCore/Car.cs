using System;

namespace CarEventsCore
{
    internal class Car
    {
        // This delegate works in conjunction with the Car events
        public delegate void CarEngineHandler(string msg);

        // This car sends these events
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        // Is car alive or dead?
        private bool _carIsDead;

        // Class constructors
        public Car()
        {

        }

        public Car(int currentSpeed, int maxSpeed, string petName)
        {
            CurrentSpeed = currentSpeed;
            MaxSpeed = maxSpeed;
            PetName = petName;
        }

        public void Accelerate(int delta)
        {
            if (_carIsDead)
            {
                Exploded?.Invoke("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // almost dead
                if (10 == MaxSpeed - CurrentSpeed)
                {
                    AboutToBlow?.Invoke("Careful buddy! Gonna blow!");
                }
                // still ok!
                if (CurrentSpeed >= MaxSpeed)
                {
                    _carIsDead = true;
                }
                else
                {
                    Console.WriteLine($"Current speed = {CurrentSpeed}");
                }
            }
        }
    }
}
