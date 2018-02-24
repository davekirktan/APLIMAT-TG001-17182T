﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs.Utilities
{
    public class Randomizer
    {
        private double min, max;
        private Random random;

        public Randomizer(int min, int max)
        {
            this.min = min;
            this.max = max + 1; //add one because Random's max is exclusive
            random = new Random();
        }
        
        public double GenerateDouble()
        {
            return random.NextDouble() * (max - min) + min;
        }

        public int GenerateInt()
        {
            return (int)random.Next((int)min, (int)max);
        }
    }
}

