using CobraConsoleExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobraConsoleExample
{
    class Program
    {
        private static List<Car> cars = new List<Car>() {
            new Car(1, "Audi", "R8", 2018, 2, "Red", 79995),
            new Car(2, "Tesla", "3", 2018, 4, "Black", 54995),
            new Car(3, "Porsche", " 911 991", 2020, 2, "White", 155000),
            new Car(4, "Mercedes-Benz", "GLE 63S", 2021, 5, "Blue", 83995),
            new Car(5, "BMW", "X6 M", 2020, 5, "Silver", 62995),
        };
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Guess the Price!");
            getCars();
            Console.WriteLine("Options");
            Console.WriteLine("1 - Guess the Price");
            Console.WriteLine("2 - Add new Car");
            Console.WriteLine("3 - Edit Car");
            Console.WriteLine("4 - Delete Car");
            Console.WriteLine("Choose Option: ");
            var UserInput = Console.ReadLine();
            switch (UserInput.ToString())
            {
                case "1": 
                    GuessPrice(); 
                    break;
                case "2":
                    Add();
                    break;
                case "3":
                    Edit();
                    break;
                case "4":
                    Delete();
                    break;
                default:
                    MainMenu();
                    break;
            }            
        }
        public static bool CompareCar(int id, int guessPrice)
        {
            Car guessCar = cars.Find(x => x.Id == id);
            if (guessCar != null)
            {
                return guessCar.Guess(guessPrice);
            }
            else
            {
                return false;
            }            
        }
        public static void AddCar(int newId, string newMake, string newModel, int newYear, int newDoors, string newColor, int newPrice)
        {
            Car newCar = new Car(newId, newMake, newModel, newYear, newDoors, newColor, newPrice);
            cars.Add(newCar);
        }
        public static void DeleteCar(int deleteId)
        {
            Car deleteCar = cars.Find(x => x.Id == deleteId);
            if (deleteCar != null)
            {
                cars.Remove(deleteCar);
            }
        }
        public static void UpdateCar(int updateId, string updateMake, string updateModel, int updateYear, int updateDoors, string updateColor, int updatePrice)
        {
            Car updateCar = cars.Find(x => x.Id == updateId);
            cars.Remove(updateCar);
            Car newUpdateCar = new Car(updateId, updateMake, updateModel, updateYear, updateDoors, updateColor, updatePrice);
            cars.Add(newUpdateCar);
        }
        public static void getCars()
        {
            Console.WriteLine("Our Car List is");
            Console.WriteLine("-----------------");
            if (cars.Count > 0)
            {
                cars.Sort((c1, c2) => 
                {
                    return c1.Id.CompareTo(c2.Id);
                });

                foreach (Car singleCar in cars)
                {
                    Console.WriteLine("Car ID: " +singleCar.Id + " - " + singleCar.Make + " " + singleCar.Model + " - Year: " + singleCar.Year + " - Doors: " + singleCar.Doors + " - Color: " + singleCar.Color);
                }
            }
            else
            {
                Console.WriteLine("Empty List");
            }
            
            Console.WriteLine("-----------------");
        }
        public static void GuessPrice()
        {
            Console.Clear();
            getCars();
            Console.WriteLine("Select the Car Id");
            string opt = Console.ReadLine();
            if (ValidOption(opt))
            {
                Console.WriteLine("Enter the guess price");
                string price = Console.ReadLine();
                if (CompareCar(Convert.ToInt32(opt), Convert.ToInt32(price)))
                {
                    Console.WriteLine("RESULT: Good job!");
                }
                else
                {
                    Console.WriteLine("RESULT: Nice try");
                }
                    Console.ReadLine();
                MainMenu();
            }
            else
            {
                GuessPrice();
            }
        }
        public static void Delete()
        {
            Console.Clear();
            getCars();
            Console.WriteLine("Select the Car Id to Delete");
            string opt = Console.ReadLine();
            if (ValidOption(opt))
            {
                DeleteCar(Convert.ToInt32(opt));
                getCars();
                Console.ReadLine();
                MainMenu();
            }
            else
            {
                Delete();
            }
        }
        public static void Add()
        {
            int newId = (cars.Max(x => x.Id)) + 1;
            Console.Clear();
            Console.WriteLine("-- Add new car --");
            Console.WriteLine("(Your new car Id will be: " + newId + ")");
            Console.WriteLine("Enter Maker: ");
            string newMake = Console.ReadLine();
            Console.WriteLine("Enter Model: ");
            string newModel = Console.ReadLine();
            Console.WriteLine("Enter Year: ");
            string newYear = Console.ReadLine();
            Console.WriteLine("Enter Doors: ");
            string newDoors = Console.ReadLine();
            Console.WriteLine("Enter Color: ");
            string newColor = Console.ReadLine();
            Console.WriteLine("Enter Price: ");
            string newPrice = Console.ReadLine();
            if (ValidNumber(newYear) && ValidNumber(newDoors) && ValidNumber(newPrice))
            {
                AddCar(newId, newMake, newModel, Convert.ToInt32(newYear), Convert.ToInt32(newDoors), newColor, Convert.ToInt32(newPrice));
                getCars();
                Console.ReadLine();
                MainMenu();
            }
            else
            {
                Add();
            }            
        }
        public static void Edit()
        {
            Console.Clear();
            Console.WriteLine("-- Select your car to edit --");
            getCars();            
            string editId = Console.ReadLine();
            if (ValidOption(editId))
            { 
                Console.WriteLine("Enter Maker: ");
                string editMake = Console.ReadLine();
                Console.WriteLine("Enter Model: ");
                string editModel = Console.ReadLine();
                Console.WriteLine("Enter Year: ");
                string editYear = Console.ReadLine();
                Console.WriteLine("Enter Doors: ");
                string editDoors = Console.ReadLine();
                Console.WriteLine("Enter Color: ");
                string editColor = Console.ReadLine();
                Console.WriteLine("Enter Price: ");
                string editPrice = Console.ReadLine();
                if (ValidNumber(editYear) && ValidNumber(editDoors) && ValidNumber(editPrice))
                {
                    UpdateCar(Convert.ToInt32(editId), editMake, editModel, Convert.ToInt32(editYear), Convert.ToInt32(editDoors), editColor, Convert.ToInt32(editPrice));
                    getCars();
                    Console.ReadLine();
                    MainMenu();
                }
                else
                {
                    Edit();
                }
            }
            else
            {
                Edit();
            }
        }
        public static bool ValidOption(string opt)
        {
            int validNumber;
            bool isNumber = int.TryParse(opt, out validNumber);
            if ((isNumber) && (cars.Find(x => x.Id == validNumber) != null))
            {
                return true;
            }
            return false;
        }
        public static bool ValidNumber(string num)
        {
            int validNumber;
            bool isNumber = int.TryParse(num, out validNumber);
            if ((isNumber))
            {
                return true;
            }
            return false;
        }
    }
}
