
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using CarritoItem;
using ProductItem;

using CarritoRepo;
using CarritoController;

using ProductsController;
using ProductsRepo;

//using Product.Data;
namespace ProductsController;


    [ApiController]
    [Route("[Controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<ProductItems> Products = new List<ProductItems>{
            new ProductItems { id=1 ,name="Product1",description="uno"},
            new ProductItems { id=2 ,name="Product2",description="dos"}

        };
 

[HttpGet]
    public ActionResult<List<ProductItems>> Get(){
        return Ok(Products);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<ProductItems> Get (int id){
        var product = Products.Find (x =>x.id == id);
        return product == null ? NotFound() : Ok(product);
    }
    



    [HttpPost]
     public ActionResult<ProductItems> Post([FromBody] ProductItems product){
        var existingProduct = Products.Find(x=>x.id== product.id);
        var prueba = Products.Find(x=>x.id== product.id);
        if (existingProduct != null){
          
          String url = Request.Path.ToString() + "/" + product.id;
            return Conflict("ya existe esa categoria");
        } 
        if (prueba != null){
          
          String url = Request.Path.ToString() + "/" + product.id;
            return NotFound("error");
        } else 
        
        {
            Products.Add(product);
            var resourceUrl = Request.Path.ToString()+ "/" + product.id;
            return Created(resourceUrl, product);
            
        }
        }
 
     [HttpPut]
    public ActionResult Put (ProductItems product){
        var existingProduct = Products.Find(x=>x.id== product.id);
        if (existingProduct == null){
            return Conflict("no existe esa categoria");
        } else {
            existingProduct.name = product.name;
            return Ok();
        }
        }
     [HttpDelete]
    [Route("{id}")]
    public ActionResult<ProductItems> Delete (int id){
        var product = Products.Find (x =>x.id == id);
        if (product == null){
            return NotFound("no funciona");
        } else{
            Products.Remove(product);
            return NoContent();
        }
    }
    
    
    }


    
   


