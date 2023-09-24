namespace StocksAPI.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Action { get; set; }
        public int Quantity { get; set; }
    }
}
