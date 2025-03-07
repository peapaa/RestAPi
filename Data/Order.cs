namespace RestAPi.Data
{
    public enum OrderStatus
    {
        Pending = 0,
        Processing = 1,
        Delivered = 2,
        Cancelled = 3
    }
    public class Order
    {
        public Guid OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        public string OrderEmail { get; set; }
        public string OrderNote { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }

    }
}
