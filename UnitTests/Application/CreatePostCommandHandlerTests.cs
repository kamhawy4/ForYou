using Xunit;
using Moq;
using FluentAssertions;
using ForYou.Application.Handler.Post;
using ForYou.Application.Command.Post;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using ForYou.SharedServices.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ForYou.Application.Contracts;

public class CreatePostHandlerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IHandleAttachment> _attachmentMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IEmailService> _emailServiceMock;
    private readonly CreatePostHandler _handler;

    public CreatePostHandlerTests()
    {
        _mapperMock = new Mock<IMapper>();
        _attachmentMock = new Mock<IHandleAttachment>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _emailServiceMock = new Mock<IEmailService>();

        // Mock repositories inside UnitOfWork
        var postRepositoryMock = new Mock<IAsyncRepository<PostEntity>>();
        _unitOfWorkMock.Setup(u => u.posts).Returns(postRepositoryMock.Object);

        _handler = new CreatePostHandler(
            _mapperMock.Object,
            _attachmentMock.Object,
            _unitOfWorkMock.Object,
            _emailServiceMock.Object
        );
    }

    //[Fact]
    //public async Task Handle_ValidCommand_ShouldAddPostUploadAttachmentAndSendEmail()
    //{
    //    // Arrange
    //    var command = new CreatePostCommend
    //    {
    //        Title = "Test Post",
    //        Content = "Test Content",
    //        Image = new FormFile(null, 0, 0, "Image", "test.png"),
    //        TagIds = new List<Guid> { Guid.NewGuid() }
    //    };

    //    var postEntity = new PostEntity { PostId = Guid.NewGuid() };

    //    _mapperMock.Setup(m => m.Map<PostEntity>(command)).Returns(postEntity);
    //    _attachmentMock.Setup(a => a.Upload(It.IsAny<IFormFile>())).Returns(Task.CompletedTask);
    //    _emailServiceMock.Setup(e => e.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);
    //    _unitOfWorkMock.Setup(u => u.posts.AddAsync(It.IsAny<PostEntity>())).Returns(Task.CompletedTask);

    //    // Act
    //    var result = await _handler.Handle(command, CancellationToken.None);

    //    // Assert
    //    result.Should().Be(postEntity.PostId);
    //    _mapperMock.Verify(m => m.Map<PostEntity>(command), Times.Once);
    //    _attachmentMock.Verify(a => a.Upload(command.Image), Times.Once);
    //    _unitOfWorkMock.Verify(u => u.posts.AddAsync(It.Is<PostEntity>(p => p == postEntity)), Times.Once);
    //    _emailServiceMock.Verify(e => e.SendEmailAsync("akamhawy@2p.com.sa", "for test"), Times.Once);
    //}

    [Fact]
    public async Task Handle_InvalidCommand_ShouldThrowException()
    {
        // Arrange
        var command = new CreatePostCommend
        {
            Title = "", // Invalid title
            Content = "Test Content"
        };

        _mapperMock.Setup(m => m.Map<PostEntity>(command)).Returns(new PostEntity());

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<Exception>().WithMessage("post not found");
    }
}
