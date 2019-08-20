using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackQuestion.Models;
using HackQuestion.Libraries.Services.Interfaces;
using HackQuestion.Libraries.Core.Domain.Categories;
using HackQuestion.Libraries.Services.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HackQuestion.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryServices _category;
        private readonly IQuestionServices _question;

        public HomeController(ICategoryServices category, IQuestionServices question)
        {
            this._category = category;
            this._question = question;

        }

        public IActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(_category.Query().ToList(), "Id", "Name");
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
