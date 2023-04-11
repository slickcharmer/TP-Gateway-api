using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseServiceTest
{
    public class NurseModelTest
    {
        [Fact]
        public void Id()
        {
            // Arrange
            Guid expectedId = Guid.NewGuid();
            var person = new NurseModels.Nurse_Models { Id = expectedId };

            // Act
            Guid actualId = person.Id;

            // Assert
            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public void Name()
        {
            // Arrange
            string expectedName = "John Doe";
            var person = new NurseModels.Nurse_Models { Name = expectedName };

            // Act
            string actualName = person.Name;

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void Email()
        {
            // Arrange
            string expectedEmail = "johndoe@example.com";
            var person = new NurseModels.Nurse_Models { Email = expectedEmail };

            // Act
            string actualEmail = person.Email;

            // Assert
            Assert.Equal(expectedEmail, actualEmail);
        }

        [Fact]
        public void PhoneNo()
        {
            // Arrange
            long expectedPhoneNo = 1234567890;
            var person = new NurseModels.Nurse_Models { PhoneNo = expectedPhoneNo };

            // Act
            long actualPhoneNo = person.PhoneNo.Value;

            // Assert
            Assert.Equal(expectedPhoneNo, actualPhoneNo);
        }
    }

}
