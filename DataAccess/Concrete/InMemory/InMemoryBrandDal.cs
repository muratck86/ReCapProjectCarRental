using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //public class InMemoryBrandDal : IRentDal<Brand>
    //{
    //    List<Brand> _brands;

    //    public InMemoryBrandDal()
    //    {
    //        _brands = new List<Brand>
    //        {
    //            new Brand { Id = 1, Name = "Hyundai", Model = "Tucson"},
    //            new Brand { Id = 2, Name = "Toyota", Model = "Corolla"},
    //            new Brand { Id = 6, Name = "Tesla", Model = "Model 3"},
    //            new Brand { Id = 5, Name = "Mercedes", Model = "AMG"},
    //            new Brand { Id = 3, Name = "Renault", Model = "Megane"},
    //            new Brand { Id = 4, Name = "Ford", Model = "Focus"},
    //            new Brand { Id = 7, Name = "Toyota", Model = "Raw4"},
    //        };
    //    }
    //    public void Add(Brand brand)
    //    {
    //        _brands.Add(brand);
    //    }

    //    public List<Brand> GetAll()
    //    {
    //        return _brands;
    //    }

    //    public Brand GetById(int id)
    //    {
    //        return _brands.SingleOrDefault(r => r.Id == id);
    //    }

    //    public bool Remove(Brand brand)
    //    {
    //        return _brands.Remove(brand);
    //    }

    //    public bool Update(Brand brand)
    //    {
    //        Brand brandToUpdate = GetById(brand.Id);
    //        if(brandToUpdate != null)
    //        {
    //            brandToUpdate.Model = brand.Model;
    //            brandToUpdate.Name = brand.Name;
    //            return true;
    //        }
    //        return false;
    //    }
    //}
}
