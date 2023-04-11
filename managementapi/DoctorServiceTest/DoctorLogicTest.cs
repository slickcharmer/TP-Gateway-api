using AutoFixture;
using DNApi.Controllers;
using BusinessLogicLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DoctorServiceTest
{
    public class DoctorLogicTest
    {
        private readonly Mock<IDoctorRepo> _mockRepo;
        private readonly DoctorLogic _logic;

        public DoctorLogicTest()
        {
            _mockRepo = new Mock<IDoctorRepo>();
            _logic = new DoctorLogic(_mockRepo.Object);
        }

        [Fact]
        public void AddDoctor_ReturnsString()
        {
            // Arrange
            var doctor = new DataLayer.Entities.Doctor();

            _mockRepo.Setup(r => r.AddDoctor(doctor)).Returns("Success");

            // Act
            var result = _logic.AddDoctor(doctor);

            // Assert
            Assert.IsType<string>(result);
            Assert.Equal("Success", result);
        }

        [Fact]
        public void GetAll_ReturnsIEnumerableOfDoctor()
        {
            // Arrange
            var mockRepo = new Mock<IDoctorRepo>();
            mockRepo.Setup(repo => repo.GetAllDoctors())
                    .Returns(new List<DataLayer.Entities.Doctor>());

            var logic = new DoctorLogic(mockRepo.Object);

            // act
            var result = logic.GetAll();

            // assert
            Assert.IsAssignableFrom<IEnumerable<DataLayer.Entities.Doctor>>(result);
        }

        [Fact]
        public void GetById_ReturnsIEnumerableOfDoctor()
        {
            var id = Guid.NewGuid();
            var doctors = new List<DataLayer.Entities.Doctor> { new DataLayer.Entities.Doctor(), new DataLayer.Entities.Doctor(), new DataLayer.Entities.Doctor() };

            _mockRepo.Setup(r => r.GetDoctorById(id)).Returns(doctors);

            // Act
            var result = _logic.GetById(id);

            // Assert
            Assert.IsType<List<DataLayer.Entities.Doctor>>(result);
            Assert.Equal(doctors, result);
        }

        [Fact]
        public void DeleteDoctor_ReturnsString()
        {
            // Arrange
            var email = "test@example.com";

            _mockRepo.Setup(r => r.Delete(email)).Returns("Success");

            // Act
            var result = _logic.DeleteDoctor(email);

            // Assert
            Assert.IsType<string>(result);
            Assert.Equal("Success", result);
        }
    }

}
