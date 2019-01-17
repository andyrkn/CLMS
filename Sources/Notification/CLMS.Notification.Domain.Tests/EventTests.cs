using CLMS.Notification.Domain.Entities;
using System;
using System.Linq;
using Xunit;

namespace CLMS.Notification.Domain.Tests
{
    public class EventTests
    {
        private Guid eventId = new Guid("68DD2A6B-3B06-4271-8E29-1F93CD0A127B");

        [Fact]
        public void Given_Create_When_OriginIdAndNameIsPassed_Then_ShouldCreateAnEvent()
        {
            // act
            var result = Event.Create(eventId, "test");

            // assert
            Assert.NotNull(result);
        }


        [Fact]
        public void Given_Create_When_OriginIdAndNameIsPassed_Then_ShouldCreateAnEventAndSetOriginIdAndName()
        {
            // act
            var name = "test";
            var result = Event.Create(eventId, name);

            // assert
            Assert.Equal(name, result.Name);
            Assert.Equal(eventId, result.OriginId);
        }

        [Fact]
        public void Given_Subscribe_When_EmailIsPassed_Then_ShouldSubscribeToEvent()
        {
            // arrange
            var testEmail = "test@email";
            var @event = Event.Create(eventId, "Test");
            
            // act
            @event.Subscribe(testEmail);

            // assert
            Assert.Contains(@event.Subscriptions, x => x.Email == testEmail);
        }

        [Fact]
        public void Given_Unsubscribe_When_EmailIsSubscribed_Then_ShouldRetrunOkResult()
        {
            // arrange
            var testEmail = "test@email";
            var @event = Event.Create(eventId, "Test");
            @event.Subscribe(testEmail);

            // act
            var result = @event.Unsubscribe(testEmail);

            // assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Given_Unsubscribe_When_EmailIsSubscribed_Then_ShouldRemoveSubscription()
        {
            // arrange
            var testEmail = "test@email";
            var @event = Event.Create(eventId, "Test");
            @event.Subscribe(testEmail);

            // act
            @event.Unsubscribe(testEmail);

            // assert
            Assert.DoesNotContain(@event.Subscriptions, x => x.Email == testEmail);
        }
    }
}
