using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;

namespace VerySimpleForum.Pages
{
    public class ShowSubTopicsModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public ShowSubTopicsModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public IEnumerable<SubTopic> SubTopics { get; set; }
        public void OnGet()
        {
            SubTopics = context.SubTopics;
        }
    }
}
