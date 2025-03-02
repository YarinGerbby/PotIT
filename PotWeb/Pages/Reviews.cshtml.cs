using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class ReviewsModel : PageModel
{
    public List<Review> Reviews { get; set; } = new();

    [BindProperty]
    public Review NewReview { get; set; }

    public void OnGet()
    {
        // Sample reviews (later we can connect to a database)
        Reviews.Add(new Review { Name = "Alice", Message = "Beautiful pottery!", Rating = 5 });
        Reviews.Add(new Review { Name = "John", Message = "Amazing craftsmanship.", Rating = 4 });
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            Reviews.Add(NewReview);
        }
        return Page();
    }
}

public class Review
{
    public string Name { get; set; }
    public string Message { get; set; }
    public int Rating { get; set; }
}
