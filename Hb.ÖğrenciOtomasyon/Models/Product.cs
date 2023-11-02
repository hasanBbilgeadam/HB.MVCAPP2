namespace Hb.ÖğrenciOtomasyon.Models
{

    public enum Kategori
    {
        telefon=1,
        tablet=2,
        laptop=3,
    }
    public class Product
    {
        public Product()
        {
            Id = new Random().Next(2, 9999999);
        }
        public int Id { get; set; }
        public string Adı { get; set; }
        public bool PersoneldeMi { get; set; }
        public DateTime? VerilmeTarihi { get; set; }
        public Kategori Kategori { get; set; }
    }

    public class Personel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
