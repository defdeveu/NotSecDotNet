using Microsoft.AspNetCore.Mvc;
using NotSecDotNet.Data;
using NotSecDotNet.Dto;
using NotSecDotNet.Model;
using System.IO;
using System;
using NotSecDotNet.Services;

namespace NotSecDotNet.Controllers
{
    [ApiController]
    public class SellMovieObjectsController : ControllerBase
    {
        private readonly SellMovieObjectsService movieObjectsService;

        public SellMovieObjectsController(SellMovieObjectsService movieObjectsService)
        {
            this.movieObjectsService = movieObjectsService;
        }


        [Route("movieobject")]
        [HttpGet]
        public List<MovieObject> findAllBuyableObjects()
        {
            return movieObjectsService.findAllBuyableObjects();
        }

        [Route("order")]
        [HttpPut]
        public OrderResultDto placeOrder([FromBody] OrderListDto orderList)
        {
            return movieObjectsService.placeOrder(orderList);
        }
    }
}
