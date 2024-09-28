using Microsoft.AspNetCore.Mvc;
using SchoolManagementD.Data;
using SchoolManagementD.Models;

namespace SchoolManagementD.Controllers
{
    public class GroupController : Controller
    {
        private readonly ApplicationContext _context;
        
        public GroupController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var groups = _context.Groups.ToList();
            return View(groups);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var model = new GroupForCreation();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GroupForCreation model)
        {
            var group = new Group
            {
                Name = model.Name
            };

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var group = _context.Groups.Find(id);

            var model = new GroupForModification
            {
                Id = id,
                Name = group.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GroupForModification model)
        {
            var group = new Group
            {
                Id = model.Id,
                Name = model.Name
            };

            _context.Groups.Update(group);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) 
        {
            var group = _context.Groups.Find(id);
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
