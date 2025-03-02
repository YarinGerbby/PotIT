public class PotteryItem
{
    public string Name { get; set; } = string.Empty; // ✅ Default value
    public double Price { get; set; }
    public DateTime CreationDate { get; set; }
    public string Size { get; set; } = string.Empty; // ✅ Default value
    public string ArtistName { get; set; } = string.Empty; // ✅ Default value
    public string ImageUrl { get; set; } = string.Empty; // ✅ Default value
}
