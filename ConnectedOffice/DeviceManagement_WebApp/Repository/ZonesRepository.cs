using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using DeviceManagement_WebApp.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeviceManagement_WebApp.Repository
{
    public class ZonesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        //Get Zones
        public List<Zone> GetAll()
        {
            return _context.Zone.ToList();
        }

        //Get Specific Zone by ID
        public async Task<Zone> Details(Guid? id)
        {
            var zone = await _context.Zone.FirstOrDefaultAsync(m => m.ZoneId == id);

            return (zone); 
        }

        //Create new Zone
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async void Create(Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _context.Add(zone);
            await _context.SaveChangesAsync();
        }

        //Update Zone
        public async void Update(Zone zone)
        {
            _context.Entry(zone).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Delete Zone
        public async void Delete(Zone zone)
        {
            _context.Remove(zone);
            await _context.SaveChangesAsync();
        }

        //Does Zone exist?
        public bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }

        public SelectList GetList()
        {
            SelectList list = new SelectList(_context.Zone, "ZoneId", "ZoneName");
            return list;
        }
    }
}
