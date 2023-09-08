using API_Marketplace_.net_7_v1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MarketplaceDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-L57VS11;Database=master;Trusted_Connection=True;"); // �������� �� ���� ������ �����������
});

var app = builder.Build();

// ��������� ���������� POST-������� ��� �������� ������������
app.MapPost("/api/users", async (MarketplaceDbContext dbContext, HttpContext context) =>
{
    // ������ JSON-���� �������
    using var reader = new StreamReader(context.Request.Body);
    var jsonBody = await reader.ReadToEndAsync();

    try
    {
        // ������������� JSON � ������ User
        var newUser = JsonSerializer.Deserialize<User>(jsonBody);

        // ��������� ������������ � DbSet<User> � ��������� ��������� � ���� ������
        dbContext.Users.Add(newUser);
        await dbContext.SaveChangesAsync();

        // ���������� �������� �����
        context.Response.StatusCode = 201; // Created
        await context.Response.WriteAsync("User created successfully.");
    }
    catch (JsonException)
    {
        // ������ � ������� JSON-������, ���������� ������
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsync("Invalid JSON data.");
    }
});
app.Run();