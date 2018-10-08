using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime SellDate { get; set; }

        public string Colour { get; set; }

        public Owner PreviousOwner { get; set; }

        public double Price { get; set; }
    }
}
