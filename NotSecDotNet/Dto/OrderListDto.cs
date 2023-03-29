namespace NotSecDotNet.Dto
{
    public class OrderListDto
    {
        public OrderListDto()
        {
            OrderItems = new List<OrderItemDto>();
        }

        public List<OrderItemDto> OrderItems  { get; set; }
    }
}
