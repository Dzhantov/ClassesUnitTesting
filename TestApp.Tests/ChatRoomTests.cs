using System;

using NUnit.Framework;

using TestApp.Chat;

namespace TestApp.Tests;

[TestFixture]
public class ChatRoomTests
{
    private ChatRoom _chatRoom = null!;
    
    [SetUp]
    public void Setup()
    {
        this._chatRoom = new();
    }
    
    [Test]
    public void Test_SendMessage_MessageSentToChatRoom()
    {
        // Arrange
        
        string sender = "Desi";
        string message = "You are the best!";
        //Act
        _chatRoom.SendMessage(sender, message);
        string actualResult = _chatRoom.DisplayChat();
        string expectedResult = "Chat Room Messages:" + Environment.NewLine
            + "Desi: You are the best! - Sent at ";

        //Assert
        Assert.That(actualResult, Does.Contain(expectedResult));
    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        //Act
        string actualResult = _chatRoom.DisplayChat();

        //Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        // Arrange
        
        string firstSender = "Desi";
        string firstSenderMessage = "You are the best!";
        string secondSender = "Ivan";
        string secondSenderMessage = "Ok Desi";
        //Act
        _chatRoom.SendMessage(firstSender, firstSenderMessage);
        _chatRoom.SendMessage(secondSender, secondSenderMessage);

        string actualResult = _chatRoom.DisplayChat();
        //string expectedResult = "Chat Room Messages:" 
           // + Environment.NewLine
           // + "Desi: You are the best! - Sent at " 
           // + Environment.NewLine
           // + "Ivan: Ok Desi - Sent at ";

        //Assert
        Assert.That(actualResult, Does.Contain("Chat Room Messages:"));
        Assert.That(actualResult, Does.Contain("Desi: You are the best! - Sent at"));
        Assert.That(actualResult, Does.Contain("Ivan: Ok Desi - Sent at"));
    }
}
