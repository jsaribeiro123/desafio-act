using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<RazorAppNftContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("RazorAppNftContext")));
}
else
{
    builder.Services.AddDbContext<RazorAppNftContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionRazorAppNftContext")));
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapHealthChecks("/healthz").RequireAuthorization();
app.MapGet("/", () => "Hello World!");

app.UseAuthorization();

app.MapRazorPages();

app.Run();



