namespace Velour_Scents.Models
{
    public class Perfume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string FragranceNotes { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }  // Optional for perfume image
    }
}
