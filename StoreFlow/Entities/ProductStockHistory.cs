namespace StoreFlow.Entities
{
    public class ProductStockHistory
    {
        public int ProductStockHistoryId { get; set; }
        public int ProductId { get; set; }
        public int ProductStock { get; set; }
        public DateTime Date     { get; set; }
        public Product Product { get; set; }
    }
}
