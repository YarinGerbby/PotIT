using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text.Json;

public class CartModel : PageModel
{
    public List<PotteryItem> CartItems { get; set; } = new();

    public void OnGet()
    {
        CartItems = GetCartFromSession();
    }

    public IActionResult OnPostRemove(string name)
    {
        var cart = GetCartFromSession();
        cart.RemoveAll(item => item.Name == name);
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
