using System;
using System.Collections.Generic;
using System.Diagnostics;
using Inputs;

namespace Car_park
{
    public class ParkingManager : IExistable
    {
        public List<Transport> Cars = new List<Transport>();
        
        public void AddCar()
        {
            CarModel model = ChooseModel();
            if (model.Equals(0))
            {
                Console.WriteLine("Incorrect command!");
            }
            else
            {
                Transport car = new Transport(model);
                Cars.Add(car);
                Buy();
            }
        }
        CarModel ChooseModel()
        {
            Console.WriteLine("1. BMW X5");
            Console.WriteLine("2. Toyota Corolla");
            Console.WriteLine("3. Volkswagen Beetle");
            Console.WriteLine("4. Chevrolet Traverse");
            Console.Write("Command: ");
            int choice = NumbersInput.Integer("Command");

            switch (choice)
            {
                case 1:
                    {
                        return CarModel.BMW_X5;
                    }
                case 2:
                    {
                        return CarModel.Toyota_Corolla;
                    }
                case 3:
                    {
                        return CarModel.Volkswagen_Beetle;
                    }
                case 4:
                    {
                        return CarModel.Chevrolet_Traverse;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        public void SellCar()
        {
            int id = ChooseCarId() - 1;

            if (id == 0)
            {
                Console.WriteLine("This id was not found!");
            }
            else
            {
                Sell();
                Cars.RemoveAt(id);
                ShiftId(id);
            }
        }
        int ChooseCarId()
        {
            Console.WriteLine("PLese inout car id that you want to delete");
            Console.Write("Id: ");
            int id = NumbersInput.Integer("Id: ");

            return id;
        }
        void ShiftId(int id)
        {
            for (int i = id; i <= Cars.Count; i++)
            {
                Cars[i].SetId(id);
            }

            Cars[0].SetIdCount(Cars.Count);
        }

        public void ShowCars()
        {
            if(Cars.Count == 0)
            {
                Console.WriteLine("Parking is empty!");
            }
            else
            {
                for (int i = 0; i < Cars.Count; i++)
                {
                    Console.WriteLine($"Id: {Cars[i]._id}");
                    Console.WriteLine($"Model: {Cars[i]._name}");
                    Console.WriteLine($"Max sped: {Cars[i]._maxSpeed}");
                    Console.WriteLine($"Weigth: {Cars[i]._weigth}");
                    Console.WriteLine($"Seats: {Cars[i]._numberOfSeats}");
                    Console.WriteLine();
                }
            }
        }

        public void Buy()
        {
            Console.WriteLine("The car was bought!");
        }

        public void Sell()
        {
            Console.WriteLine("The car was sold!");
        }
    }
}