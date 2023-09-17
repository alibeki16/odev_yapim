using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using odev_yapim.Models;

namespace odev_yapim.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            NorthwindEntities nortentitisi = new NorthwindEntities();
            return View(nortentitisi.Customers.ToList());
        }
        public ActionResult SiparisBilgi(string customerID)
        {
            NorthwindEntities nortentitisi = new NorthwindEntities();
            ViewBag.Message = "Siparis Bilgileri.";
            var customerOrders = nortentitisi.Orders
        .Where(order => order.CustomerID == customerID)
        .ToList();
            return View(customerOrders);
        }
        public ActionResult MusteriOlustur()
        {
            ViewBag.Message = "Musteri Oluşturma.";
            return View();
        }
        public ActionResult AddCustomer(Musterieklemodel model)
        {
            try
            {
                NorthwindEntities db = new NorthwindEntities();

                Customer emp = new Customer();
                emp.CustomerID = model.CustomerID;
                emp.CompanyName = model.CompanyName;
                emp.ContactName = model.ContactName;
                emp.ContactTitle = model.ContactTitle;
                emp.Address = model.Address;
                emp.City = model.City;
                emp.Region = model.Region;
                emp.PostalCode = model.PostalCode;
                emp.Country = model.Country;
                emp.Phone = model.Phone;
                emp.Fax = model.Fax;

                db.Customers.Add(emp);
                db.SaveChanges();
            }
            catch(Exception ex) {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}