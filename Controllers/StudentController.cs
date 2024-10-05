using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementD.Data;
using SchoolManagementD.Models;

namespace SchoolManagementD.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationContext _context;

        public StudentController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.Include(s => s.Group).ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new StudentForCreation();
            model.Groups = _context.Groups.ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentForCreation model)
        {
            var student = new Student
            {
                Name = model.Name,
                GroupId = model.GroupId
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            var model = new StudentForModification
            {
                Id = id,
                Name = student.Name,
                Groups = _context.Groups.ToList(),
                SelectedGroupId = student.GroupId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentForModification model)
        {
            var student = new Student
            {
                Id = model.Id,
                Name = model.Name,
                GroupId = model.GroupId
            };

            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
