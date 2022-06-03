using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        //fields:
        private int horsePower;
        private double cubicCapacity;

        //props:
        public int HorsePower { get; set; }
        public double CubicCapacity { get ; set; } 

        //constructor:
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
}
