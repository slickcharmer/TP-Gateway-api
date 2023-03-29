using AutoFixture;
using Moq;
using FluentAssertions;
using AllergyServiceApi.Controllers;
using BusinessLogic;
using Models;
using df = DataFluentApi;
using Xunit;
using DataFluentApi.Entities;

namespace AllergyApiTest
{
    public class AllergyMapperTest
    {
        [Fact]
        public void EntitiesToModels()
        {
            df.Entities.Allergy map = new df.Entities.Allergy();
            var result = Mapper.Map(map);
            Assert.Equal(result.GetType(),typeof(Models.Allergy));
        }

        [Fact]
        public void ModelsToEntities()
        {
            Models.Allergy map = new Models.Allergy();
            var result = Mapper.Map(map);
            Assert.Equal(result.GetType(),typeof(df.Entities.Allergy));
        }
    }
}
