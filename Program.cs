using API_Marketplace_.net_7_v1.API_Handlers;
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
builder.Services.AddDbContext<MarketplaceContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-L57VS11;Database=master;Trusted_Connection=True;"); // Замените на вашу строку подключения
});

var app = builder.Build();


// Users
app.MapPut("/api/user/create", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<User>(context, dbContext));

app.MapDelete("/api/user/deletebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<User>(context, dbContext));

app.MapGet("/api/user/getbyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<User>(context, dbContext));

app.MapPost("/api/user/updatebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<User>(context, dbContext));

app.MapGet("/api/user/getall", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<User>(dbContext, context));

app.MapPost("/api/user/getbyfields", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.SearchEntitiesByJsonAsync<User>(context, dbContext));



// Products
app.MapPut("/api/product/create/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.CreateProductAndLinkToUserAsync(context, dbContext));

app.MapDelete("/api/product/deletebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Product>(context, dbContext));

app.MapGet("/api/product/getbyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Product>(context, dbContext));

app.MapPost("/api/product/updatebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Product>(context, dbContext));

app.MapGet("/api/product/getall", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Product>(dbContext, context));
app.MapGet("/api/product/delete/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
	await APIHandler.HideProduct(context, dbContext));

app.MapPost("/api/product/getbyfields", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.SearchEntitiesByJsonAsync<Product>(context, dbContext));

// Orders
app.MapPut("/api/order/create", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Order>(context, dbContext));

app.MapDelete("/api/order/deletebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Order>(context, dbContext));

app.MapGet("/api/order/getbyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Order>(context, dbContext));

app.MapPost("/api/order/updatebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Order>(context, dbContext));

app.MapGet("/api/order/getall", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Order>(dbContext, context));

app.MapPost("api/order/getbyfields", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.SearchEntitiesByJsonAsync<Order>(context, dbContext));


// OrderItems
//app.MapPut("/api/orderitem/create", async (MarketplaceContext dbContext, HttpContext context) =>
//    await APIHandler.CreateEntityAsync<OrderItem>(context, dbContext));

//app.MapDelete("/api/orderitem/deletebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
//    await APIHandler.DeleteEntityByIDAsync<OrderItem>(context, dbContext));

//app.MapGet("/api/orderitem/getbyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
//    await APIHandler.GetEntityAsync<OrderItem>(context, dbContext));

//app.MapPost("/api/orderitem/updatebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
//    await APIHandler.UpdateEntityAsync<OrderItem>(context, dbContext));

//app.MapGet("/api/orderitem/getall", async (MarketplaceContext dbContext, HttpContext context) =>
//    await APIHandler.GetAllEntitiesAsync<OrderItem>(dbContext, context));


// Reviews
app.MapPut("/api/review/create", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Review>(context, dbContext));

app.MapDelete("/api/review/deletebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Review>(context, dbContext));

app.MapGet("/api/review/getbyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Review>(context, dbContext));

app.MapPost("/api/review/updatebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Review>(context, dbContext));

app.MapGet("/api/review/getall", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Review>(dbContext, context));

app.MapPost("/api/review/getbyfields", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.SearchEntitiesByJsonAsync<Review>(context, dbContext));


// Categories
app.MapPut("/api/category/create", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Category>(context, dbContext));

app.MapDelete("/api/category/deletebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Category>(context, dbContext));

app.MapPost("/api/category/updatebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Category>(context, dbContext));

app.MapGet("/api/category/getbyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Category>(context, dbContext));

app.MapGet("/api/category/getall", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Category>(dbContext, context));


// Wishlists
app.MapPut("/api/wishlist/create", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Wishlist>(context, dbContext));

app.MapGet("/api/wishlist/getbyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Wishlist>(context, dbContext));

app.MapPost("/api/wishlist/updatebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Wishlist>(context, dbContext));

app.MapDelete("/api/wishlist/deletebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Wishlist>(context, dbContext));

app.MapGet("/api/wishlist/getall", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Wishlist>(dbContext, context));

app.MapPost("/api/wishlist/getbyfields", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.SearchEntitiesByJsonAsync<Wishlist>(context, dbContext));

// Roles
app.MapPut("/api/role/create", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Role>(context, dbContext));

app.MapDelete("/api/role/deletebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Role>(context, dbContext));

app.MapPost("/api/role/updatebyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Role>(context, dbContext));

app.MapGet("/api/role/getbyid/{Id}", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Role>(context, dbContext));

app.MapGet("/api/role/getall", async (MarketplaceContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Role>(dbContext, context));



app.Run();