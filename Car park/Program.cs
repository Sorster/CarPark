using System;
using System.Diagnostics;
using Inputs;

namespace Car_park
{
    class Program
    {
        delegate void Action();

        static void Main(string[] args)
        {
            ParkingManager park = new ParkingManager();

            Action action;

            do
            {
                Menu();
                MenuPoint condition = ChooseMenuPoint();

                if (condition == MenuPoint.Exit) break;

                switch (condition)
                {
                    case MenuPoint.Buy:
                        {
                            action = park.AddCar;
                            WriteToLog("The car was bougth!");
                            break;
                        }
                    case MenuPoint.Sell:
                        {
                            action = park.SellCar;
                            WriteToLog("The car was sold!");
                            break;
                        }
                    case MenuPoint.Show:
                        {
                            action = park.ShowCars;
                            WriteToLog("The car list was showned!");
                            break;
                        }
                    case MenuPoint.Exit:
                        {
                            action = Exit;
                            WriteToLog("Exit the program!");
                            break;
                        }
                    default:
                        {
                            action = Error;
                            WriteToLog("There was a error!");
                            Console.WriteLine("Unknown command!");
                            break;
                        }
                }

                action();

                Console.WriteLine("Input any key to continue the program...");
                Console.ReadKey();
                Console.Clear();

            } while (true);
        }

        static void Menu()
        {
            Console.WriteLine("1 - Buy car");
            Console.WriteLine("2 - Sell car");
            Console.WriteLine("3 - Show cars");
            Console.WriteLine("4 - Exit");
            Console.Write("Command: ");
        }

        static MenuPoint ChooseMenuPoint()
        {
            int choice = NumbersInput.Integer("Command: ");
            Console.Clear();
            return (MenuPoint)choice;
        }

        enum MenuPoint
        {
            Buy = 1,
            Sell,
            Show,
            Exit
        }

        static void Exit()
        {
            Console.WriteLine("Exit...");
        }

        static void Error()
        {
            Console.WriteLine("Error!");
        }

        static void WriteToLog(string logInfo)
        {
            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");

                return;
            }

            EventLog myLog = new EventLog();
            myLog.Source = "MySource";

            myLog.WriteEntry(logInfo);
            EventInstance eventInstance = new EventInstance(1,2,EventLogEntryType.Information);
            myLog.WriteEvent(eventInstance, logInfo);
        }
    }
}
