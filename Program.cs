using QuizTest.Components;
using QuizTest.Models;
using Microsoft.EntityFrameworkCore;
using QuizTest.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
string DBConnection = "Host=localhost,Database=Employees,uid=root,pwd=root";

builder.Services.AddDbContext<EmployeesContext>(options => options.UseMySQL(DBConnection)); //Dung de l?p k?t n?i cõ s? d? li?u
builder.Services.AddScoped<IStaffRepository, StaffRepository>(); //Add D?ch v? vào ð? s? d?ng cho b?t k? ðau

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
