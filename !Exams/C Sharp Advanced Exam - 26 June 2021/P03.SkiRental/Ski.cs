using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    public class Ski
    {
        private string manufacturer;
        private string model;
        private int year;


        public string Manufacturer
        {
            get => manufacturer;
            set => manufacturer = value;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }

        public int Year
        {
            get => year;
            set => year = value;
        }

        public Ski(string manufacturer, string model, int year)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;
        }

        public override string ToString()
        {
            return $"{Manufacturer} - {Model} - {Year}";
        }
    }
}
