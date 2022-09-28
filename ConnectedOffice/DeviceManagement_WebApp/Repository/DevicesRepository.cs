using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Controllers;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
        //Get Devices
        public List<Device> GetAll()
        {
            var display = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return display.ToList();
        }

        //Get Specific Device by ID
        public async Task<Device> Details(Guid? id)
        {
            var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            return (device);
        }

        

        //Create new Device
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async void Create(Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _context.Add(device);
            await _context.SaveChangesAsync();
        }

        //Update Device
        public async void Update(Device device)
        {
            _context.Entry(device).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //Delete Device
        public async void Delete(Device device)
        {
            _context.Remove(device);
            await _context.SaveChangesAsync();
        }

        //Does Device exist?
        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.ZoneId == id);
        }
    }
}
