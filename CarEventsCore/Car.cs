using System;

namespace CarEventsCore
{


    public class CarEventArgs : EventArgs
    {
        public readonly string msg;

        public CarEventArgs(string msg)
        {
            this.msg = msg;
        }
    }
    internal class Car
    {
        // This delegate works in conjunction with the Car events
        public delegate void CarEngineHandler(object sender, CarEventArgs e);

        // This car sends these events
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

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
                Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
                // almost dead
                if (10 == MaxSpeed - CurrentSpeed)
                {
                    AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
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
