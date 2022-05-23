
using CarritoItem;
using ProductItem;

using CarritoRepo;
using CarritoController;

using ProductsController;
using ProductsRepo;
//using Product.Data;

namespace CarritoRepo;


public interface Repository<T>{
    void add (T item);
    void remove (int id);
    void update (int id, T item);
    T get(int id);
    List<T> getAll();
}

public class CarritoRepo : Repository<CarritoItems>
{
        private static Dictionary<int, CarritoItems> carritos = new Dictionary<int, CarritoItems>(){
    
        {1, new CarritoItems(){id = 1, name = "test1", userName = "user", password = "password", IdCategory=3}},
        {2, new CarritoItems(){id = 2, name = "test2", userName = "user", password = "password", IdCategory=3}}
};



public void add(CarritoItems carrito)
{
    if(carritos.ContainsKey(carrito.id))
    {
        throw new Exception("Carrito already exist");
    }
    carritos.Add(carrito.id, carrito);
}

public void remove(int id)
     {
         
        if (!carritos.ContainsKey(id))
        {
            throw new Exception("Carrito not found");
        }
        carritos.Remove(id);
        
        }
public void update(int id, CarritoItems carrito)
    {
        if(carritos.ContainsKey(id))
        {
        throw new Exception("Carrito not found");
        }
        carritos[id] = carrito;
    }
    
public CarritoItems get(int id)
{
    if  (carritos.ContainsKey(id))
    {
        return carritos[id];
    }
    throw new Exception("Carrito not found");
}

public List<CarritoItems> getAll(){ return carritos.Values.ToList();}

}


