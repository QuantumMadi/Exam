using System;

namespace Goods
{
    [Serializable]
    public class Tyre
    {       
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int Radius { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool ForWinter { get; set; }
        public Tyre() { }
        public Tyre(int id, string companyName, int radius, int width, int height, bool forWinter)
        {
            Id = id;
            CompanyName = companyName;
            Radius = radius;
            Width = width;
            Height = height;
            ForWinter = forWinter;
        }
    }
}
