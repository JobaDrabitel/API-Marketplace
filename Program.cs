using API_Marketplace_.net_7_v1.Controllers;
using API_Marketplace_.net_7_v1.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:8080"); 
builder.Services.AddDbContext<Marketplace1Context>(options =>
{
    options.UseSqlServer("Server=DESKTOP-L57VS11;Database=master;Trusted_Connection=True;"); // Замените на вашу строку подключения
});

var app = builder.Build();


// Users
app.MapPost("/api/user/create", async (Marketplace1Context dbContext, HttpContext context) =>
    await UserAPIHandler.CreateUserAsync(context, dbContext));

app.MapGet("/api/user/deletebyid/{userId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await UserAPIHandler.DeleteUserByIDAsync(context, dbContext));

app.MapGet("/api/user/getbyid/{userId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await UserAPIHandler.GetUserByIDAsync(context, dbContext));

app.MapPost("/api/user/updatebyid/{userId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await UserAPIHandler.UpdateUserAsync(context, dbContext));

app.MapGet("/api/user/getall", async (HttpContext context) =>
    await context.Response.WriteAsJsonAsync(await UserAPIHandler.GetAllUsersAsync()));

app.MapPost("/api/user/auth", async (Marketplace1Context dbContext, HttpContext context) =>
    await context.Response.WriteAsJsonAsync(await UserAPIHandler.AuthenticateUserAsync(context, dbContext)));


// Products
app.MapPost("/api/product/create", async (Marketplace1Context dbContext, HttpContext context) =>
    await ProductAPIHandler.CreateProductAsync(context, dbContext));

app.MapGet("/api/product/deletebyid/{productId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await ProductAPIHandler.DeleteProductByIDAsync(context, dbContext));

app.MapGet("/api/product/getbyid/{productId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await ProductAPIHandler.GetProductAsync(context, dbContext));

app.MapPost("/api/product/updatebyid/{productId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await ProductAPIHandler.UpdateProductAsync(context, dbContext));

app.MapGet("/api/product/getall", async (HttpContext context) =>
    await context.Response.WriteAsJsonAsync(await ProductAPIHandler.GetAllProductsAsync()));


//Orders
app.MapPost("/api/order/create", async (Marketplace1Context dbContext, HttpContext context) =>
{
    await OrderAPIHandler.CreateOrderAsync(context, dbContext);
});

app.MapGet("/api/order/deletebyid/{orderId}", async (Marketplace1Context dbContext, HttpContext context) =>
{
    await OrderAPIHandler.CreateOrderAsync(context, dbContext);
});

app.MapGet("/api/order/getbyid/{orderId}", async (Marketplace1Context dbContext, HttpContext context) =>
{
    await OrderAPIHandler.CreateOrderAsync(context, dbContext);
});

app.MapPost("/api/order/updatebyid/{orderId}", async (Marketplace1Context dbContext, HttpContext context) =>
{
    await OrderAPIHandler.CreateOrderAsync(context, dbContext);
});
app.MapGet("/api/order/getall", async (HttpContext context) =>
{
    await context.Response.WriteAsJsonAsync(await OrderAPIHandler.GetAllOrdersAsync());
});



// Reviews
app.MapPost("/api/review/create", async (Marketplace1Context dbContext, HttpContext context) =>
    await ReviewAPIHandler.CreateReviewAsync(context, dbContext));

app.MapGet("/api/review/deletebyid/{reviewId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await ReviewAPIHandler.DeleteReviewByIdAsync(context, dbContext));

app.MapGet("/api/review/getbyid/{reviewId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await ReviewAPIHandler.GetReviewAsync(context, dbContext));

app.MapPost("/api/review/updatebyid/{reviewId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await ReviewAPIHandler.UpdateReviewAsync(context, dbContext));

app.MapGet("/api/review/getall", async (HttpContext context) =>
    await context.Response.WriteAsJsonAsync(await ReviewAPIHandler.GetAllReviewsAsync()));


// Categories
app.MapPost("/api/category/create", async (Marketplace1Context dbContext, HttpContext context) =>
    await CategoryAPIHandler.CreateCategoryAsync(context, dbContext));

app.MapGet("/api/category/getbyid/{categoryId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await CategoryAPIHandler.GetCategoryAsync(context, dbContext));

app.MapPost("/api/category/updatebyid/{categoryId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await CategoryAPIHandler.UpdateCategoryAsync(context, dbContext));

app.MapGet("/api/category/deletebyid/{categoryId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await CategoryAPIHandler.DeleteCategoryByIDAsync(context, dbContext));

app.MapGet("/api/category/getall", async (HttpContext context) =>
    await context.Response.WriteAsJsonAsync(await CategoryAPIHandler.GetAllCategoriesAsync()));




// Roles
app.MapPost("/api/role/create", async (Marketplace1Context dbContext, HttpContext context) =>
    await RoleAPIHandler.CreateRoleAsync(context, dbContext));

app.MapGet("/api/role/getbyid/{roleId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await RoleAPIHandler.GetRoleAsync(context, dbContext));

app.MapPost("/api/role/updatebyid/{roleId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await RoleAPIHandler.UpdateRoleAsync(context, dbContext));

app.MapGet("/api/role/deletebyid/{roleId}", async (Marketplace1Context dbContext, HttpContext context) =>
    await RoleAPIHandler.DeleteRoleByIDAsync(context, dbContext));

app.MapGet("/api/role/getall", async (HttpContext context) =>
    await context.Response.WriteAsJsonAsync(await RoleAPIHandler.GetAllRolesAsync()));


app.Run();