using BowlingGame.Api.Controllers;
using BowlingGame.Core.Abstractions.Services;
using BowlingGame.Core.Enums;
using BowlingGame.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Api;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class MenusControllerTest
{
    private readonly Mock<IMenuService> _menuService = new();
    private readonly MenusController _controller;

    public MenusControllerTest() => _controller = new MenusController(_menuService.Object);

    [Test]
    public void Get_WhenCalled_ReturnsMenuItems()
    {
        // Arrange
        List<MenuItem> menuItems = new() { new MenuItem() };
        _ = _menuService.Setup(x => x.GetMenuItems(It.IsAny<DataSource>())).Returns(menuItems);

        // Act
        IActionResult result = _controller.Get(DataSource.InMemory);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        Assert.That(((OkObjectResult)result).Value, Is.EqualTo(menuItems));
    }
}
