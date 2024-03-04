using SuperHeroApp.Application.Common.Behaviours;
using SuperHeroApp.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SuperHeroApp.Application.SuperHeroFeatures.Commands.AddFavoriteSuperhero;

namespace SuperHeroApp.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<AddFavoriteSuperheroCommand>> _logger = null!;
    private Mock<IUser> _user = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<AddFavoriteSuperheroCommand>>();
        _user = new Mock<IUser>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _user.Setup(x => x.Id).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<AddFavoriteSuperheroCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new AddFavoriteSuperheroCommand { SuperheroId = 1}, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<AddFavoriteSuperheroCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new AddFavoriteSuperheroCommand { SuperheroId = 1 }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}
