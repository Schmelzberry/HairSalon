using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;
using System.Linq;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private readonly HairSalonContext _db;

        public ClientsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
             List<Client> model = _db.Clients
                                     .Include(client => client.Stylist)
                                     .ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (client.StylistId == 0)
            {
                return RedirectToAction("Create");
            }
            else 
            {
                _db.Clients.Add(client);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            Client client = _db.Clients
                .Include(model => model.Stylist)
                .FirstOrDefault(model => model.ClientId == id);
            return View(client);
        }

        public ActionResult Delete(int id)
        {
           Client targetClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            return View(targetClient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client targetClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            _db.Clients.Remove(targetClient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    
        }
    }

