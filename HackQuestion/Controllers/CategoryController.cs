using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackQuestion.Libraries.Core.Domain.Categories;
using HackQuestion.Libraries.Data.Repository;
using HackQuestion.Libraries.Services.Entity;
using HackQuestion.Libraries.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackQuestion.Controllers
{  
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices, int i)
        {
            this._categoryServices = categoryServices;

            if (_categoryServices.Count() == 0)
            {
                List<Category> items = new List<Category>();

                items.Add(new Category("C#"));
                items.Add(new Category("Regular Question"));
                items.Add(new Category("PHP"));
                items.Add(new Category("RoR"));
                items.Add(new Category("Javascript"));
                items.Add(new Category("Java"));
                items.Add(new Category("SQL Server"));
                items.Add(new Category("General"));

                foreach (var categorias in items)
                    _categoryServices.Add(categorias);

                _categoryServices.Save();


            }

        }



        [HttpGet]
        public List<Category> GetAll()
        {
            return _categoryServices.Query().ToList();
        }


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var data = _categoryServices.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);

        }


        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {

            var data = _categoryServices.Query();
            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(
                           p => p.Name.Contains(name)
                        );
            }
            return Ok(data);
            
        }



       
    }
}