using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.ApplicationService.Impl;
using WebShop.Core.DomainService.Filtering;
using WebShop.Core.Entity;

namespace WebShop.Core.DomainService
{
    public interface IShoeRepository
    {
        // CRUD
        Shoe CreateShoe(Shoe shoe);

        Shoe ReadShoeById(int id);
        FilteringList<Shoe> ReadAllShoes(Filter filter = null);


        Shoe UpdateShoe(Shoe shoeToUpdate);

        Shoe DeleteShoe(int id);

        int Count(); 
    }
}
