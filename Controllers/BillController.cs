using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hSenidBiz.Models;

namespace hSenidBiz.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            using (BillContext dbModels = new BillContext())
            {
                return View(dbModels.Bills.ToList());
            }
        }

        [HttpGet]
        public ActionResult AddBill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBill(Bill currentModel)
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddDetail()
        {
            using (BillContext dbModels = new BillContext())
            {
                var products = dbModels.Products.ToList();
                ViewBag.ProductList = new SelectList(products, "Name", "Name");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddDetail(Detail detailModel)
        {
            using (BillContext dbModels = new BillContext())
            {
                Bill billModel = new Bill();
                var item = dbModels.Products.Where(x => x.Name == detailModel.Name)
                                .Select(x => new {
                                    Price = x.Price,
                                }).Single();
                float itemPrice = item.Price;
                detailModel.Price = itemPrice;

                float totalPrice = itemPrice * detailModel.Quantity;
                detailModel.Amount = totalPrice;

                float withVAT = float.Parse((totalPrice * 1.12).ToString());
                float Total = float.Parse((withVAT * 0.95).ToString());

                billModel.Date = DateTime.Now;
                billModel.SubTotal = totalPrice;
                billModel.Discount = 5;
                billModel.Vat = 12;
                billModel.Total = Total;
                detailModel.Bill = billModel;

                dbModels.Bills.Add(billModel);
                dbModels.Details.Add(detailModel);
                dbModels.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Item Added!";
            return RedirectToAction("Index", "Bill");
        }
    }
}