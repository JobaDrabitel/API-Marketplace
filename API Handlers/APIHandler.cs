using API_Marketplace_.net_7_v1.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.Json;

namespace API_Marketplace_.net_7_v1.API_Handlers
{
    public class APIHandler
    {
        public static async Task CreateEntityAsync<T>(HttpContext context, MarketplaceDbContext dbContext) where T : class
        {
            using var reader = new StreamReader(context.Request.Body);
            var jsonBody = await reader.ReadToEndAsync();

            try
            {
                var newEntity = JsonSerializer.Deserialize<T>(jsonBody);

                dbContext.Set<T>().Add(newEntity);

                await dbContext.SaveChangesAsync();

                var entityType = typeof(T);
                var firstProperty = entityType.GetProperties().FirstOrDefault();
                if (firstProperty != null)
                {
                    var entityId = firstProperty.GetValue(newEntity);

                    context.Response.StatusCode = 201;
                    await context.Response.WriteAsync(entityId.ToString()); ;
                }
            }
            catch (JsonException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid JSON data.");
            }
        }


        public static async Task GetEntityAsync<T>(HttpContext context, MarketplaceDbContext dbContext) where T : class
        {
            if (context.Request.RouteValues["Id"] is string entityIdStr && int.TryParse(entityIdStr, out int entityId))
            {
                var entity = await dbContext.Set<T>().FindAsync(entityId);

                if (entity != null)
                {
                    var entityJson = JsonSerializer.Serialize(entity);
                    context.Response.StatusCode = 200;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(entityJson);
                }
                else
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync($"{typeof(T).Name} not found.");
                }
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync($"Invalid {typeof(T).Name} ID format.");
            }
        }

        public static async Task GetAllEntitiesAsync<T>(MarketplaceDbContext dbContext, HttpContext context) where T : class
        {
            var entityJson = JsonSerializer.Serialize(await dbContext.Set<T>().ToListAsync());
            await context.Response.WriteAsync(entityJson);
        }

        public static async Task UpdateEntityAsync<T>(HttpContext context, MarketplaceDbContext dbContext) where T : class
        {
            if (context.Request.RouteValues["Id"] is string entityIdStr && int.TryParse(entityIdStr, out int entityId))
            {
                using var reader = new StreamReader(context.Request.Body);
                var jsonBody = await reader.ReadToEndAsync();

                try
                {
                    var entityToUpdate = await dbContext.Set<T>().FindAsync(entityId);
                    if (entityToUpdate != null)
                    {
                        var updatedEntity = JsonSerializer.Deserialize<T>(jsonBody);

                        foreach (var propertyInfo in typeof(T).GetProperties())
                        {
                            if (!(propertyInfo.Name.Contains("ID") || propertyInfo.Name.Contains("Id")))
                            {
                                var newValue = propertyInfo.GetValue(updatedEntity);
                                if (newValue != null)
                                {
                                    propertyInfo.SetValue(entityToUpdate, newValue);
                                }
                            }
                        }

                        await dbContext.SaveChangesAsync();
                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync($"{typeof(T).Name} updated successfully.");
                    }
                    else
                    {
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync($"{typeof(T).Name} not found.");
                    }
                }
                catch (JsonException)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid JSON data.");
                }
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync($"Invalid {typeof(T).Name} ID format.");
            }
        }

        public static async Task DeleteEntityByIDAsync<T>(HttpContext context, MarketplaceDbContext dbContext) where T : class
        {
            if (context.Request.RouteValues["Id"] is string entityIdStr && int.TryParse(entityIdStr, out int entityId))
            {
                var entityToDelete = await dbContext.Set<T>().FindAsync(entityId);

                if (entityToDelete != null)
                {
                    dbContext.Set<T>().Remove(entityToDelete);
                    await dbContext.SaveChangesAsync();
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync($"{typeof(T).Name} deleted successfully.");
                }
                else
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync($"{typeof(T).Name} not found.");
                }
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync($"Invalid {typeof(T).Name} ID format.");
            }
        }

        public static async Task SearchEntitiesByJsonAsync<T>(HttpContext context, MarketplaceDbContext dbContext) where T : class
        {
            using var reader = new StreamReader(context.Request.Body);
            var jsonBody = await reader.ReadToEndAsync();

            try
            {
                var searchRequest = JsonSerializer.Deserialize<T>(jsonBody);
                var properties = typeof(T).GetProperties();
                var query = dbContext.Set<T>().AsQueryable();

                for (int i = 1; i < properties.Length; i++)
                {
                    var property = properties[i];

                    if (property.PropertyType != typeof(string) &&
                        typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                    {
                        continue;
                    }

                    var value = property.GetValue(searchRequest);
                    if (value != null && !value.Equals(0))
                    {
                        query = query.Where($"{property.Name} = @0", value);
                    }
                }

                var matchingEntities = await query.ToListAsync();

                var responseJson = JsonSerializer.Serialize(matchingEntities);
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(responseJson);
            }
            catch (JsonException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid JSON data.");
            }
        }
    }
}
