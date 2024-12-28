using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.tagsFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    internal interface ITagRepository
    {
        public DbSet<Tag> Table { get; }
        public Task<Tag> GetbyId(int id);
        public IQueryable<Tag> GetAll();
        public IQueryable<Tag> FindAll(Expression<Func<Tag, bool>> expression);
        public Task<Tag> Create(Tag tags);
        public void Update(Tag tags);
        public void Delete(Tag tags);
        public void SoftDelete(Tag tags);
        public Task<int> SaveChangesAsync();
        public Task<bool> IsExsist(Expression<Func<Tag, bool>> expression);
    }
}
