var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// ✅ Add session services
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache(); // Required for session storage

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // ✅ Enable serving static files (CSS, JS, images, etc.)

app.UseRouting();

app.UseSession(); // ✅ Ensure session middleware is added before using it

app.UseAuthorization();

app.MapRazorPages();

app.Run();