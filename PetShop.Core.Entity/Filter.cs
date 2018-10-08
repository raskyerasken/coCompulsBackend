using System.Reflection.Metadata.Ecma335;

namespace PetShop.Core.Entity
{
    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPrPage { get; set; }
        public string OrderBy { get; set; }
    }
}