﻿using InmarCodeTestData;
using InmarCodeTestData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmarCodeTestApis.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OfferController : ControllerBase
  {
    private OfferService _Service;
    public OfferController(OfferService service)
    {
      _Service = service;
    }

    [HttpGet]
    [Route("GetTodaysOffer")]
    public IList<Offer> GetTodaysOffer()
    {
      return _Service.GetTodaysOffers();
    }

    [HttpGet]

    [Route("GetAllProduct")]
    public IList<Product> GetAllProduct()
    {
      //oops!! could have used rderBy from Linq to sort the data :)
      //Instead of Implementing IComparable in the Product class 
      var products = _Service.SortedProducts();
      var lowerstPriceProducts = products.ToList().Take(3);
      return lowerstPriceProducts.ToList();
    }

    [HttpGet]

    [Route("GetProductWithSecondLowestPrice")]
    public Product GetProductWithSecondLowestPrice()
    {    
      //oops!! could have used orderBy from Linq to sort the data :)
      //Instead of Implementing IComparable in the Product class 
      var products = _Service.SortedProducts();
      var lowerstPriceProducts = products[1];
      return lowerstPriceProducts;
    }

    [HttpPost]

    [Route("AddProduct")]
    public Product AddProduct(ProductResource productResource)
    {
      var product = _Service.AddProduct(productResource.Name, productResource.Price, 
        productResource.Description);
      return product;
     
    }
  }
}
