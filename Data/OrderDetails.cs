namespace RestAPi.Data
{
    public class OrderDetails
    {
        public Guid OrderCode { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }
        public byte ProductDiscount { get; set; }

        // relationship
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
