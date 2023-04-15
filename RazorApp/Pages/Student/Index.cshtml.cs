using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Entities;
using RazorApp.Model;

namespace RazorApp.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly SchoolDbContext _context;

        public IndexModel(SchoolDbContext context)
        {
            _context = context;
        }
        public List<Entities.Student> Students { get; set; }
        public string Message { get; set; }
        public void OnGet(string search)
        {
            Message = "OnGet method worked";
            Students = string.IsNullOrEmpty(search) ? _context.Students.ToList() :
                _context.Students.Where(s => s.Firstname.ToLower().Contains(search.ToLower())).ToList();
        }
        [BindProperty]
        public Entities.Student Student { get; set; }

        public IActionResult OnPost()
        {
            _context.Students.Add(Student);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
