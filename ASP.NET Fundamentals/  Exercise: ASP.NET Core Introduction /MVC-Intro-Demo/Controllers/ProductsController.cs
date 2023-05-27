using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVC_Intro_Demo.Models;
using System.Text;
using static MVC_Intro_Demo.Seeding.DataProvider;

namespace MVC_Intro_Demo.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult All()
        {
            return View(Products);
        }

        public IActionResult ById(string id)
        {
            ProductViewModel? product = Products.FirstOrDefault(p => p.Id.ToString().Equals(id));

            if(product == null)
            {
                return RedirectToAction("All");
            }

            return View(product);
        }

        public IActionResult AllAsTextFile()
        {
            var sb = new StringBuilder();

            foreach (var item in Products)
            {
                sb.AppendLine($"{item.Name} {item.Price} lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.text");
            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
