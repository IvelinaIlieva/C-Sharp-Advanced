﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        private string name;
        private int alcohol;
        private int quantity;

        public string Name { get => name; set => name = value; }

        public int Alcohol { get => alcohol; set => alcohol = value; }

        public int Quantity { get => quantity; set => quantity = value; }

        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Ingredient: {Name}");
            sb.AppendLine($"Quantity: {Quantity}");
            sb.Append($"Alcohol: {Alcohol}");

            return sb.ToString();
        }
    }
}
