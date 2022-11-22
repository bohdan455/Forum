using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;
using VerySimpleForum.DTO;

namespace VerySimpleForum.Pages.SubTopicPages
{
    public class SubTopicPageModel : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<SubTopicPageModel> logger;
        private string _title;

        public SubTopicPageModel(ApplicationDbContext context, ILogger<SubTopicPageModel> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        [BindProperty]
        public SubTopic? SubTopic { get; set; }
        [BindProperty]
        public CommentDTO Comment { get; set; }
        public IActionResult OnGet(string title)
        {

            _title = title;
            SubTopic = context.SubTopics.Where(SubTopic => SubTopic.Title == title)
                .Include(subTopic => subTopic.Comments).ThenInclude(comment => comment.BelongsTo)
                .Include(subTopic => subTopic.Comments).ThenInclude(comment => comment.Likes)
                .Include(subTopic => subTopic.Likes)
                .ToList().FirstOrDefault(); // eager loadding
            if (SubTopic == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

    }
}
