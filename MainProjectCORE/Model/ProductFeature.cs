namespace MainProjectCORE.Model
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductId { get; set; } //bunu bu şekilde yazdığımız zaman for. key olarak otomatik algılar.


        public Product Product { get; set; }

    }
}
