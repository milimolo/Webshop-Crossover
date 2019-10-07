using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.ApplicationService.Impl;
using WebShop.Core.Entity;

namespace WebShop.Core.DomainService
{
    public interface IShoeRepository
    {
        // CRUD
        Shoe CreateShoe(Shoe shoe);

        Shoe ReadShoeById(int id);
        List<Shoe> ReadAllShoes();

        Shoe UpdateShoe(Shoe shoeToUpdate);

        Shoe DeleteShoe(int id);

        int Count(); 
    }
}
