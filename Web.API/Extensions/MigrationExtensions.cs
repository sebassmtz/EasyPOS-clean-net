﻿using Microsoft.EntityFrameworkCore;
using EasyPOS.Infrastructure.Persistence;

namespace Web.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigration(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }

    }
}
