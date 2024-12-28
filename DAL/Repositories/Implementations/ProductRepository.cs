using Core.Entities;
using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class ProductRepository: IProductRepository
    {
        readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public DbSet<Product> Table => _context.Set<Product>();

        public async Task<Product> Create(Product products)
        {
            await Table.AddAsync(products);
            return products;
        }

        public void Delete(Product products)
        {
            Table.Remove(products);
        }

        public IQueryable<Product> FindAll(Expression<Func<Product, bool>> expression)
        {

            return expression != null ? Table.Where(expression) : Table;
        }

        public IQueryable<Product> GetAll()
        {
            return Table;
        }

        public async Task<Product> GetbyId(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Product products)
        {
            Table.Update(products);
        }
        public async Task<bool> IsExsist(Expression<Func<Product, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }

        public void SoftDelete(Product products)
        {
            products.IsDeleted = true;
            Table.Update(products);
        }
    }
}
