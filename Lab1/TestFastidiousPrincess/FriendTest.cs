using FluentAssertions;
using Labs;
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
        private const int _ContendersCount = 100;
        private Mock<IHostApplicationLifetime> _lifetime;
        private Mock<IContenderGenerator> _contenderGenerator;

        [SetUp]
        public void Setup()
        {
            _lifetime = new Mock<IHostApplicationLifetime>();
            _contenderGenerator = new Mock<IContenderGenerator>();
        }

        List<Contender> CreateContenderListForFriendTest()
        {
            var contenders = new List<Contender>();
            int contendersCount = 100;
            for (int i = contendersCount; i > 0; i--)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = i;
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }

        [Test]
        public void CompareContenders_ReturnBest()
        {
            List<Contender> contenderList = CreateContenderListForFriendTest();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.ContendersCount()).Returns(_ContendersCount);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);

            Contender bestContender = hall.GetNextContender();
            Contender worseContender = hall.GetNextContender();
            CompareType cp = friend.CompareContenders(bestContender, worseContender);
            CompareType cp_better = CompareType.Better;
            cp.Should().Be(cp_better);
        }

        [Test]
        public void CompareContenders_ReturnWorse()
        {
            List<Contender> contenderList = CreateContenderListForFriendTest();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.ContendersCount()).Returns(_ContendersCount);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);

            Contender bestContender = hall.GetNextContender();
            Contender worseContender = hall.GetNextContender();
            CompareType cp = friend.CompareContenders(worseContender, bestContender);
            CompareType cp_better = CompareType.Worse;
            cp.Should().Be(cp_better);
        }

        [Test]
        public void CompareIfFriendDontKnow_CompareContenders_ThrowException()
        {
            List<Contender> contenderList = CreateContenderListForFriendTest();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.ContendersCount()).Returns(_ContendersCount);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);

            Contender bestContender = contenderList[0];
            Contender worseContender = contenderList[1];
            friend.Invoking(f => f.CompareContenders(worseContender, bestContender)).Should().Throw<Exception>().WithMessage("Подруга не может сравнивать претендентов, которые ещё не были у принцессы.");
        }
    }
}
