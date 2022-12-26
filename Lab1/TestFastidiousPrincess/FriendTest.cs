using FluentAssertions;
using FastidiousPrincess;
using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFastidiousPrincess
{
    public class FriendTest
    {
        private Mock<IContenderGenerator> _contenderGenerator;

        [SetUp]
        public void Setup()
        {
            _contenderGenerator = new Mock<IContenderGenerator>();
        }

        List<Contender> CreateContenderListForFriendTest()
        {
            var contenders = new List<Contender>();
            contenders.Add(new Contender("name 1", "last name 1", 10));
            contenders.Add(new Contender("name 2", "last name 2", 5));
            return contenders;
        }

        [Test]
        public void CompareContenders_ReturnBest()
        {
            List<Contender> contenderList = CreateContenderListForFriendTest();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);
            hall.InitHall();
            var friend = new Friend(hall);

            var bestContender = hall.GetNextContender();
            var worseContender = hall.GetNextContender();
            CompareType compareType = friend.CompareContenders(bestContender, worseContender);
            compareType.Should().Be(CompareType.Better);
        }

        [Test]
        public void CompareContenders_ReturnWorse()
        {
            List<Contender> contenderList = CreateContenderListForFriendTest();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);
            hall.InitHall();
            var friend = new Friend(hall);

            var bestContender = hall.GetNextContender();
            var worseContender = hall.GetNextContender();
            CompareType compareType = friend.CompareContenders(worseContender, bestContender);
            compareType.Should().Be(CompareType.Worse);
        }

        [Test]
        public void CompareIfFriendDontKnow_CompareContenders_ThrowException()
        {
            List<Contender> contenderList = CreateContenderListForFriendTest();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);
            hall.InitHall();
            var friend = new Friend(hall);

            var bestContender = contenderList[0];
            var worseContender = contenderList[1];
            friend.Invoking(f => f.CompareContenders(worseContender, bestContender))
                .Should().Throw<Exception>()
                .WithMessage("Подруга не может сравнивать претендентов, которые ещё не были у принцессы.");
        }
    }
}
