using AutoFixture;
using Moq;
using FluentAssertions;
using AllergyServiceApi.Controllers;
using BusinessLogic;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace AllergyApiTest
{
    public class AllergyControllerTest
    {
        private readonly IFixture fixture;
        private readonly Mock<ILogic> mockLogic;
        private readonly AllergyController controller;


        public AllergyControllerTest()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<ILogic>>();
            controller = new AllergyController(mockLogic.Object);
        }

        [Fact]
        public void GetAllergies_AllergyService_OkResponse()
        {
            var allergyMock = fixture.Create<IEnumerable<Allergy>>();
            mockLogic.Setup(x => x.GetAllergies()).Returns(allergyMock);

            var result = controller.Get();

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(allergyMock.GetType());
            mockLogic.Verify(x => x.GetAllergies(), Times.AtLeastOnce());
        }


        [Fact]
        public void GetAllergies_AllergyService_BadRequest()
        {
            IEnumerable<Allergy> response = null;
            mockLogic.Setup(x => x.GetAllergies()).Returns(response);

            var result = controller.Get();

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetAllergies(), Times.AtLeastOnce());
        }

        [Fact]
        public void AddAllergy_AllergyService_CreatedRequest()
        {
            var request = fixture.Create<Allergy>();
            mockLogic.Setup(x => x.AddAllergy(request));


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedResult>();
            mockLogic.Verify(x => x.AddAllergy(request), Times.AtLeastOnce());

        }

        [Fact]
        public void AddAllergy_AllergyService_BadRequest()
        {
            var request = fixture.Create<Allergy>();
            mockLogic.Setup(x => x.AddAllergy(request)).Throws(new Exception("Something wrong with the request"));


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddAllergy(request), Times.AtLeastOnce());
        }
    }
}