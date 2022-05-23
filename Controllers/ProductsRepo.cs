using CarritoItem;
using ProductItem;

using CarritoRepo;
using CarritoController;

using ProductsController;
using ProductsRepo;
//using Product.Data;

namespace ProductsRepo;

public interface Repository<T>{
    void add (T item);
    void remove (int id);
    void update (int id, T item);
    T get(int id);
    List<T> getAll();
}

public class ProductsRepo :Repository <ProductItems>
{
      private static Dictionary<int, ProductItems> products = new Dictionary<int, ProductItems>(){};
    
public void add(ProductItems product)
{
   
    
    if(products.Count==0){
        product.id=1;
    }
    else{
    product.id=products.Keys.Max()+1;
    }
    products.Add(product.id ,product);

 }

    
   


public void remove(int id)
     {
         
        if (!products.ContainsKey(id))
        {
            throw new Exception("Category not found");
        }
        products.Remove(id);
        
        }
public void update(int id, ProductItems category)
    {
        if(!products.ContainsKey(id))
        {
        throw new Exception("Category not found");
        }
        products[id] = category;
    }
    
public ProductItems get(int id)
{
    if  (products.ContainsKey(id))
    {
        return products[id];
    }
    throw new Exception("Category not found");
}

public List<ProductItems> getAll(){ return products.Values.ToList();}

}

