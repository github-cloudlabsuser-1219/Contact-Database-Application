using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using YourProjectName.Controllers; // Adjust the namespace to where your UserController is located

namespace YourProjectName.Tests
{
    [TestMethod]
    public void Create_PostNewUser_ShouldAddUserAndRedirectToIndex()
    {
        // Arrange
        var controller = new UserController();
        var newUser = new User { Name = "Test User", Email = "test@example.com" };
        var initialCount = UserController.userlist.Count;

        // Act
        var result = controller.Create(newUser) as RedirectToRouteResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.RouteValues["action"]); // Check redirection to Index
        Assert.AreEqual(initialCount + 1, UserController.userlist.Count); // Ensure the user list count has increased by 1
        var addedUser = UserController.userlist.LastOrDefault(); // Assuming the new user is added at the end
        Assert.IsNotNull(addedUser);
        Assert.AreEqual(initialCount + 1, addedUser.Id); // Check if the Id is correctly assigned
        Assert.AreEqual("Test User", addedUser.Name); // Optional: Verify that the added user's properties are correct
    }
}
