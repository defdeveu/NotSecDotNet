using NotSecDotNet.Data;
using NotSecDotNet.Dto;
using NotSecDotNet.Model;
using System.Collections.Generic;
using System.Linq;

namespace NotSecDotNet.Services
{
    public class SellMovieObjectsService
    {
        private readonly MovieDbContext movieDbContext;

        public SellMovieObjectsService(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }
        internal List<MovieObject> findAllBuyableObjects()
        {
            return movieDbContext.MovieObjects.ToList();
        }

        internal OrderResultDto placeOrder(OrderListDto orderList)
        {
            List<OrderItemDto> orderItems = orderList.OrderItems;
            if (!orderItems.Any())
            {
                throw new InvalidOrderException("Emtpy order.");
            }
            HashSet<int> movieObjectIds = new HashSet<int>();
            int sumPrice = 0;
            foreach (OrderItemDto orderItem in orderItems)
            {
                int movieObjectId = orderItem.MovieObjectId;
                MovieObject mo = movieDbContext.MovieObjects.Find(movieObjectId);
                if (mo == null)
                {
                    throw new InvalidOrderException("Non existing movieObject in orderItem.");
                }
                if (movieObjectIds.Contains(movieObjectId))
                {
                    throw new InvalidOrderException("An order list should contain each movieObject only once.");
                }
                movieObjectIds.Add(movieObjectId);
                sumPrice += (mo.Price * orderItem.NrOfItemsOrdered);

            }
            OrderResultDto result = new OrderResultDto();

            result.OrderList = orderList;
            result.SumPriceToPay = sumPrice;
            return result;
        }
    }
}
