using Labs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Immutable;

namespace WebApp.Pages.Lab;


[Authorize]
public class IndexModel : PageModel
{
    private static readonly ImmutableArray<ILab> _labs =
    [
        Lab1.Instance,
        Lab2.Instance,
        Lab3.Instance
    ];


    [BindProperty(SupportsGet = true)]
    public required int Number { get; init; }

    [BindProperty]
    public required PostModel Post { get; init; }

    public ViewModel View { get; private set; } = null!;


    public void OnGet()
    {
        if (ModelState.IsValid)
        {
            if (!(Number >= 1 && Number <= _labs.Length))
            {
                ModelState.AddModelError("", $"Laboratory work ¹{Number} does not exist.");
            }
        }
        View = new();
    }


    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            if (!(Number >= 1 && Number <= _labs.Length))
            {
                ModelState.AddModelError("", $"Laboratory work ¹{Number} does not exist.");
            }
        }
        View = ModelState.IsValid
            ? new()
            {
                Input = Post.Input,
                Output = _labs[Number - 1].Calculate(Post.Input ?? "")
            }
            : new();
    }



    public class PostModel
    {
        public string? Input { get; set; }

        public string? Output { get; set; }
    }


    public class ViewModel
    {
        public string? Input { get; set; }

        public string? Output { get; set; }
    }
}