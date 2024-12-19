namespace Basket.API.Models
{
    public class ShoppingCard
    {
        public ShoppingCard(string userName)
        {
            UserName = userName;
        }
        public ShoppingCard() // For Mapping
        {

        }
        public string UserName { get; set; } = default!;
        public List<ShoppingCardItem> Items { get; set; } = new();
        public decimal Price => Items.Sum(x => x.Price * x.Quentity);
    }
}
