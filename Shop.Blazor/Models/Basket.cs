namespace Shop.Blazor.Models
{
    public class Basket
    {
        public string UserName { get; set; } = null!;
        public List<BasketItem> Items { get; set; } = new();
        public decimal TotalPrice { get; set; }
    }

    public class BasketItem
    {
        public int Quantity { get; set; }

        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;

        public string ImageURL { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
