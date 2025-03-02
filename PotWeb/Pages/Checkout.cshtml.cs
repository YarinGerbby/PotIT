using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text.Json;

public class CheckoutModel : PageModel
{
    [BindProperty]
    public string FullName { get; set; }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string CardNumber { get; set; }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            // Here, we could integrate Stripe or PayPal for real payments
            HttpContext.Session.Remove("Cart"); // Clear the cart after purchase
            return RedirectToPage("OrderConfirmation");
        }

        return Page();
    }
}
