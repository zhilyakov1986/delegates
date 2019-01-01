using System;

namespace CarDelegate
{
    public class Car
    {
        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        // Is car alive or dead?
        private bool carIsDead;

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

        // Define a delegate type.
        public delegate void CarEngineHandler(string msgForCaller);
        // Define a member variable for this delegate
        private CarEngineHandler listOfHandlers;
        // Add registration function for the caller
        public void RegisterWithCarEngine(CarEngineHandler methodCall)
        {
            // use for single cast =
            //listOfHandlers = methodCall;
            // to enable multi cast use +=
            listOfHandlers += methodCall;
        }

        public void UnregisterWithCarEngine(CarEngineHandler methodCall)
        {
            listOfHandlers -= methodCall;
        }
        // implement the Accelerate() method to invoke the delegate's
        // invocation list under the correct circumstances
        public void Accelerate(int delta)
        {
            // if car is dead send the message
            if (carIsDead)
            {
                if (listOfHandlers != null)
                {
                    listOfHandlers("Sorry, this car is dead...");
                }
            }
            else
            {
                CurrentSpeed += delta;
                // is this car almost dead?
                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna Blow!");
                }

                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine($"CurrentSpeed = {CurrentSpeed}");
                }
            }
        }
    }
}

