using UserApp.DataLayer;
using UserApp.DataLayer.Entities;

using (var db = new AppDbContext())
{
    ////Delete every user
    //foreach (var user in db.Users.ToList())
    //{
    //    db.Users.Remove(user);
    //}
    //db.SaveChanges();



    //db.Database.EnsureCreated();


    ////Create user
    //var user = new UserEntity { Id = 3, Name = "Stephens Nanni", Email = "stephensnanni@example.com", PublicId = Guid.NewGuid() };
    //db.Users.Add(user);
    //db.SaveChanges();
    //Console.WriteLine($"Používate¾ {user.Name} bol pridaný s ID {user.Id}");

    //Console.WriteLine("\nVšetci používatelia:");
    //var users = db.Users.ToList();
    //foreach (var u in users)
    //{
    //    Console.WriteLine($"ID: {u.Id}, Meno: {u.Name}, Email: {u.Email}");
    //}
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

