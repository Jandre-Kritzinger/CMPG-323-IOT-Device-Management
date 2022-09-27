using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

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
    }
}
