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
    class TagRepository:ITagRepository
    {
        readonly AppDBContext _context;

        public TagRepository(AppDBContext context)
        {
            _context = context;
        }

        public DbSet<Tag> Table => _context.Set<Tag>();

        public async Task<Tag> Create(Tag tags)
        {
            await Table.AddAsync(tags);
            return tags;
        }

        public void Delete(Tag tags)
        {
            Table.Remove(tags);
        }

        public IQueryable<Tag> FindAll(Expression<Func<Tag, bool>> expression)
        {

            return expression != null ? Table.Where(expression) : Table;
        }

        public IQueryable<Tag> GetAll()
        {
            return Table;
        }

        public async Task<Tag> GetbyId(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Tag tags)
        {
            Table.Update(tags);
        }
        public async Task<bool> IsExsist(Expression<Func<Tag, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }

        public void SoftDelete(Tag tags)
        {
            tags.IsDeleted = true;
            Table.Update(tags);
        }
    }
}
