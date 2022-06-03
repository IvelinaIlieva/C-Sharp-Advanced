using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        //fields:
        private int year;
        private double pressure;

        //props:
        public int Year { get; set; }
        public double Pressure { get; set; }

        //constructor:
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }
}
