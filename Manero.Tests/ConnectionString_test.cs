﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Manero.Tests
{
    public class ConnectionString_test
    {
        [Fact]
        public void VerifyConnectionString()
        {
            // Arrange
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            // Act
            var connectionString = configuration.GetConnectionString("DatabaseConnection");

            // Assert
            var expectedConnectionString = "Server=tcp:grupp2projekt.database.windows.net,1433;Initial Catalog=Projekt2;Persist Security Info=False;User ID=SqlAdmin;Password=Bytmig123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            Assert.Equal(expectedConnectionString, connectionString);
        }

    }
}
