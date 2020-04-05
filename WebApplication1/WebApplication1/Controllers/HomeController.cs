using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ShopContext db = new ShopContext();

        public ActionResult Index()
        {
            IEnumerable<Car> cars = db.Cars;
            ViewBag.Cars = cars;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.CarId = id;
            return View();
        }
        [HttpPost]
        public string Buy(int CarId, string FullName, int Age)
        {
            //Car car = db.Cars.Find(CarId);
            Car car = db.Cars.Where(c => CarId == c.CarId).FirstOrDefault();
            car.Reserve = true;

            Client client = new Client
            {
                FullName = FullName,
                Age = Age
            };

            db.Clients.Add(client);
            db.SaveChanges();

            Order order = new Order
            {
                CarId = CarId,
                ClientId = client.ClientId,
                Date = DateTime.Now
            };

            db.Orders.Add(order);
            db.SaveChanges();
            return "Спасибо," + client.FullName + ", за покупку!";
        }
    }
}