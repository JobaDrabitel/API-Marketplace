using API_Marketplace_.net_7_v1.API_Handlers;
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
builder.Services.AddDbContext<MarketplaceDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-L57VS11;Database=master;Trusted_Connection=True;"); // �������� �� ���� ������ �����������
});

var app = builder.Build();


// Users
app.MapPut("/api/user/create", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<User>(context, dbContext));

app.MapDelete("/api/user/deletebyid/{userId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<User>(context, dbContext));

app.MapGet("/api/user/getbyid/{userId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<User>(context, dbContext));

app.MapPost("/api/user/updatebyid/{Id}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<User>(context, dbContext));

app.MapGet("/api/user/getall", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<User>(dbContext, context));



// Products
app.MapPut("/api/product/create", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Product>(context, dbContext));

app.MapDelete("/api/product/deletebyid/{productId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Product>(context, dbContext));

app.MapGet("/api/product/getbyid/{productId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Product>(context, dbContext));

app.MapPost("/api/product/updatebyid/{productId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Product>(context, dbContext));

app.MapGet("/api/product/getall", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Product>(dbContext, context));


// Orders
app.MapPut("/api/order/create", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Order>(context, dbContext));

app.MapDelete("/api/order/deletebyid/{orderId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Order>(context, dbContext));

app.MapGet("/api/order/getbyid/{orderId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Order>(context, dbContext));

app.MapPost("/api/order/updatebyid/{orderId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Order>(context, dbContext));

app.MapGet("/api/order/getall", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Order>(dbContext, context));


// OrderItems
app.MapPut("/api/orderitem/create", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<OrderItem>(context, dbContext));

app.MapDelete("/api/orderitem/deletebyid/{orderItemId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<OrderItem>(context, dbContext));

app.MapGet("/api/orderitem/getbyid/{orderItemId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<OrderItem>(context, dbContext));

app.MapPost("/api/orderitem/updatebyid/{orderItemId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<OrderItem>(context, dbContext));

app.MapGet("/api/orderitem/getall", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<OrderItem>(dbContext, context));


// Reviews
app.MapPut("/api/review/create", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Review>(context, dbContext));

app.MapDelete("/api/review/deletebyid/{reviewId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Review>(context, dbContext));

app.MapGet("/api/review/getbyid/{reviewId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Review>(context, dbContext));

app.MapPost("/api/review/updatebyid/{reviewId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Review>(context, dbContext));

app.MapGet("/api/review/getall", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Review>(dbContext, context));


// Categories
app.MapPut("/api/category/create", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Category>(context, dbContext));

app.MapDelete("/api/category/getbyid/{categoryId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Category>(context, dbContext));

app.MapPost("/api/category/updatebyid/{categoryId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Category>(context, dbContext));

app.MapGet("/api/category/deletebyid/{categoryId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Category>(context, dbContext));

app.MapGet("/api/category/getall", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Category>(dbContext, context));


// Wishlists
app.MapPut("/api/wishlist/create", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Wishlist>(context, dbContext));

app.MapDelete("/api/wishlist/getbyid/{wishlistId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Wishlist>(context, dbContext));

app.MapPost("/api/wishlist/updatebyid/{wishlistId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Wishlist>(context, dbContext));

app.MapGet("/api/wishlist/deletebyid/{wishlistId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Wishlist>(context, dbContext));

app.MapGet("/api/wishlist/getall", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Wishlist>(dbContext, context));


// Roles
app.MapPut("/api/role/create", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.CreateEntityAsync<Role>(context, dbContext));

app.MapDelete("/api/role/getbyid/{roleId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.DeleteEntityByIDAsync<Role>(context, dbContext));

app.MapPost("/api/role/updatebyid/{roleId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.UpdateEntityAsync<Role>(context, dbContext));

app.MapGet("/api/role/deletebyid/{roleId}", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetEntityAsync<Role>(context, dbContext));

app.MapGet("/api/role/getall", async (MarketplaceDbContext dbContext, HttpContext context) =>
    await APIHandler.GetAllEntitiesAsync<Role>(dbContext, context));



app.Run();