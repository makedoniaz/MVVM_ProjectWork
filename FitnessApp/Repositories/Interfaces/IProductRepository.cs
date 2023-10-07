using FitnessApp.Models;
using System.Collections.Generic;

namespace FitnessApp.Repositories.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();

    Product? GetById(int id);

    void Create(Product product);
}
