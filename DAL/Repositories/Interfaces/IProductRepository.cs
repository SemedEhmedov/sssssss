using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public DbSet<Product> Table { get; }
        public Task<Product> GetbyId(int id);
        public IQueryable<Product> GetAll();
        public IQueryable<Product> FindAll(Expression<Func<Product, bool>> expression);
        public Task<Product> Create(Product products);
        public void Update(Product products);
        public void Delete(Product products);
        public void SoftDelete(Product products);
        public Task<int> SaveChangesAsync();
        public Task<bool> IsExsist(Expression<Func<Product, bool>> expression);
    }
}
