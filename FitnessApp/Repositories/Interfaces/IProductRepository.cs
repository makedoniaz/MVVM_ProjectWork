using FitnessApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.Repositories.Interfaces;

public interface IProductRepository
{
    IQueryable<Product> GetAll();

    Product? GetById(int id);

    void Create(Product product);
}
