using FitnessApp.Models;
using FitnessApp.Models.Context;
using FitnessApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.Repositories;

public class ProductEfCoreRepository : IProductRepository
{
    private readonly FitnessContext _context;

    public ProductEfCoreRepository(FitnessContext context) => _context = context;

    public ProductEfCoreRepository() => _context = new FitnessContext();

    

    public void Update(int id, User user)
    {
        if (user.Id == default)
            user.Id = id;

        this._context.Users.Update(user);
        this._context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }
}
