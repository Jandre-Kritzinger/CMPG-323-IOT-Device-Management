using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using DeviceManagement_WebApp.Controllers;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        // GET: Categories
        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        // GET: Categories by ID
        public async Task<Category> Details(Guid? id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);

            return (category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async void Create(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async void Delete(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
