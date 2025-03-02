using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text.Json;

public class OnlineStoreModel : PageModel
{
    public List<PotteryItem> PotteryItems { get; set; } = new();

    public void OnGet()
    {
        PotteryItems = new List<PotteryItem>
        {
            new PotteryItem { Name = "Blue Vase", Price = 45.99, CreationDate = DateTime.Parse("2024-01-15"), Size = "10in x 5in", ArtistName = "Yarin", ImageUrl = "/images/2.jpg" },
            new PotteryItem { Name = "Rustic Clay Bowl", Price = 29.99, CreationDate = DateTime.Parse("2023-12-05"), Size = "8in x 4in", ArtistName = "Yarin", ImageUrl = "/images/1.jpg" }
        };
    }

    public IActionResult OnPost(string name, double price)
    {
        var cart = GetCartFromSession();
        cart.Add(new PotteryItem { Name = name, Price = price });

        SaveCartToSession(cart);

        return RedirectToPage();
    }

    private List<PotteryItem> GetCartFromSession()
    {
        var cartData = HttpContext.Session.GetString("Cart");
        return cartData != null ? JsonSerializer.Deserialize<List<PotteryItem>>(cartData) : new List<PotteryItem>();
    }

    private void SaveCartToSession(List<PotteryItem> cart)
    {
        HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
    }
}
