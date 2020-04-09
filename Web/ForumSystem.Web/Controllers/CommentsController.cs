namespace ForumSystem.Web.Controllers
{
    using System.Threading.Tasks;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentInputModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.commentsService.Create(model.PostId, userId, model.Content);
            return this.RedirectToAction("ById", "Posts", new { id = model.PostId });
        }
    }
}
