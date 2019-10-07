using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.DomainService;
using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService.Impl
{
    public class ShoeService: IShoeService
    {
        readonly IShoeRepository _shoeRepository;

        public ShoeService(IShoeRepository shoeRepository  )
        {
            _shoeRepository = shoeRepository;
        }
            
        public Shoe NewShoe(string shoeName)
        {
            var shoe = new Shoe()
            {
                name = shoeName 
            };
            return shoe;
        }

        public Shoe CreateShoe (Shoe shoe)
        {
            return _shoeRepository.CreateShoe(shoe);
        }

        public List<Shoe> GetAllShoes()
        {
            return _shoeRepository.ReadAllShoes();
        }

        public Shoe FindShoesById(int id)
        {
            return _shoeRepository .ReadShoeById(id);
        }

        public int Count()
        {
           // return _shoeRepository.Count(); 
            throw new NotImplementedException();
        }

        public Shoe UpdateShoe(Shoe shoeUpdate)
        {
            return _shoeRepository.UpdateShoe(shoeUpdate);
        }

        public Shoe DeleteShoe(int id)
        {
            return _shoeRepository.DeleteShoe(id); 
        }
    }
}
