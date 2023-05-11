using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobraConsoleExample.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }

        public Car(int carId, string carMake, string carModel, int carYear, int carDoors, string carColor, int carPrice)
        {
            Id = carId;
            Make = carMake;
            Model = carModel;
            Year = carYear;
            Doors = carDoors;
            Color = carColor;
            Price = carPrice;
        }

        public bool Guess(int guessPrice)
        {
            return (Math.Abs(this.Price - guessPrice) <= 5000);
        }
    }
}
