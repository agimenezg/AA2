
using Microsoft.AspNetCore.Mvc;
using CarritoItem;
using ProductItem;

using CarritoController;

using ProductsController;
using ProductsRepo;
//using Product.Data;

namespace CarritoController;





[ApiController]
[Route("[Controller]")]

public class SitesController : ControllerBase
{

   private static List<CarritoItems> Carritos = new List<CarritoItems>{           

         new CarritoItems{id = 1, name = "Carrito1", userName = "Andrea", password = "123", IdCategory=3},
          new CarritoItems{id = 2, name = "Carrito2", userName = "Andrea", password = "123", IdCategory=3},
};
   

[HttpGet]
    public ActionResult<List<ProductItems>> Get(){
        return Ok(Carritos);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<CarritoItems> Get (int id){
        var carrito = Carritos.Find (x =>x.id == id);
        return carrito == null ? NotFound() : Ok(carrito);
    }
    



    [HttpPost]
     public ActionResult<CarritoItems> Post([FromBody] CarritoItems carrito){
        var existingCategory = Carritos.Find(x=>x.id== carrito.id);
        if (existingCategory != null){
          
          String url = Request.Path.ToString() + "/" + carrito.id;
            return Conflict("ya existe esa categoria");
        } else {
            Carritos.Add(carrito);
            var resourceUrl = Request.Path.ToString()+ "/" + carrito.id;
            return Created(resourceUrl, carrito);
        }
        }
 
     [HttpPut]
    public ActionResult Put (CarritoItems carrito){
        var existingCarritoItems = Carritos.Find(x=>x.id== carrito.id);
        if (existingCarritoItems == null){
            return Conflict("no existe esa categoria");
        } else {
            existingCarritoItems.name = carrito.name;
            return Ok();
        }
        }
     [HttpDelete]
    [Route("{id}")]
    public ActionResult<ProductItems> Delete (int id){
        var carrito = Carritos.Find (x =>x.id == id);
        if (carrito == null){
            return NotFound();
        } else{
            Carritos.Remove(carrito);
            return NoContent();
        }
    }
    
    
    }
