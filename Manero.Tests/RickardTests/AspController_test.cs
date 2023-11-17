namespace Manero.Tests.RickardTests
{

    //Testing the asp-controller for signoutpopup
    public class SignOutPopupControllerTests
    {
        [Fact]
        public void AspControllerAttribute_Should_Contain_Correct_Value()
        {
            // Arrange
            string htmlContent = @"<a asp-controller=""signoutpopup""></a>";

            // Act
            string aspControllerAttribute = GetAspControllerAttribute(htmlContent);

            // Assert
            Assert.Equal("signoutpopup", aspControllerAttribute);
        }

        // Helper method to extract the value of the asp-controller attribute
        private string GetAspControllerAttribute(string htmlContent)
        {
            // Search for the asp-controller attribute in the HTML content
            int startIndex = htmlContent.IndexOf("asp-controller=\"");
            if (startIndex == -1)
            {
                return null!; // Attribute not found
            }

            // Extract the attribute's value
            int valueStartIndex = startIndex + "asp-controller=\"".Length;
            int endIndex = htmlContent.IndexOf('"', valueStartIndex);
            if (endIndex == -1)
            {
                return null!; // Attribute value not closed with a double quote
            }

            string attributeValue = htmlContent.Substring(valueStartIndex, endIndex - valueStartIndex);
            return attributeValue;
        }
    }
}
