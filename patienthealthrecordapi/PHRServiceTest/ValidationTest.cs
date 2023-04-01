using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace PHRServiceTest
{
    public class ValidationTest
    {
        [Fact]
        public void IsValidBP_ValidInput_ReturnsInput()
        {
            // Arrange
            string input = "120/80";

            // Act
            string result = Validation.IsValidBP(input);

            // Assert
            Assert.Equal(input, result);
        }

        [Fact]
        public void IsValidBP_InvalidInput_ThrowsException()
        {
            // Arrange
            string input = "120-80";

            // Act and Assert
            Assert.Throws<Exception>(() => Validation.IsValidBP(input));
        }
    }
}
