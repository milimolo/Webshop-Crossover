using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.DomainService.Filtering;
using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService
{
    public interface IShoeService
    {
        //New Customer
        Shoe NewShoe(string name
            );

        //Create //POST
        Shoe CreateShoe (Shoe shoe);
        //Read //GET
        FilteringList<Shoe> GetAllShoes ();
        FilteringList<Shoe> GetFilteredShoes(Filter filter);
        Shoe FindShoesById(int id);
        int Count();
        //Update //PUT
        Shoe UpdateShoe(Shoe ShoeUpdate);
        
        //Delete //DELETE
        Shoe DeleteShoe(int id);

    }
}
