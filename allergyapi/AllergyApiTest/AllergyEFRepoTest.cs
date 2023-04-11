/*using DataFluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllergyApiTest
{
    public class AllergyEFRepoTests
    {
        private AllergyServiceDbContext dbContext;
        private AllergyEFRepo repo;

        public AllergyEFRepoTests()
        {
            // Initialize the in-memory database and repository
           *//* var options = new DbContextOptionsBuilder<AllergyServiceDbContext>()
                .UseInMemoryDatabase(databaseName: "AllergyDatabase")
                .Options;

            dbContext = new AllergyServiceDbContext(options);
            repo = new AllergyEFRepo(dbContext);*//*
        }

        [Fact]
        public void GetAllData_ReturnsAllergies()
        {
            // Arrange
            var allergies = new List<Allergy>
        {
            new Allergy { AllergyId = Guid.NewGuid(), AllergyName = "Peanuts" },
        };

            dbContext.Allergies.AddRange(allergies);
            dbContext.SaveChanges();

            // Act
            var result = repo.GetAllData();

            // Assert
            Assert.Equal(allergies.Count, result.Count);
            Assert.Equal(allergies[0].AllergyName, result[0].AllergyName);
        }

        [Fact]
        public void Add_AddsAllergy()
        {
            // Arrange
            var allergy = new Allergy { AllergyName = "Lactose" };

            // Act
            var result = repo.Add(allergy);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.AllergyId);
            Assert.Equal(allergy.AllergyName, result.AllergyName);
            Assert.Equal(1, dbContext.Allergies.Count());
        }
    }


}
*/