using Microsoft.Extensions.Hosting;
using Moq;
using System;
using Labs;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using FluentAssertions;

namespace TestFastidiousPrincess
{
    public class PrincessTest
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

        List<Contender> CreateContenderListForPrincessWhoGet10()
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
        public void FindBestContender_GetHappy10()
        {
            List<Contender> contenderList = CreateContenderListForPrincessWhoGet10();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.ContendersCount()).Returns(_ContendersCount);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            IContenderForPrincess contender = princess.FindBestContender();
            int happyMark = princess.GoToHallAndGetHappyMark(contender);

            int happyMarkIfPrincessNotMarried = 10;
            happyMark.Should().Be(happyMarkIfPrincessNotMarried);
        }

        List<Contender> CreateContenderListForPrincessWhoGet0()
        {
            var contenders = new List<Contender>();
            int contendersCount = 100;
            for (int i = 1; i <= contendersCount; i++)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = i;
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }

        [Test]
        public void FindBestContender_GetHappy0()
        {
            List<Contender> contenderList = CreateContenderListForPrincessWhoGet0();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.ContendersCount()).Returns(_ContendersCount);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            IContenderForPrincess contender = princess.FindBestContender();
            int happyMark = princess.GoToHallAndGetHappyMark(contender);

            int happyMarkIfPrincessMarriesOnLooser = 0;
            happyMark.Should().Be(happyMarkIfPrincessMarriesOnLooser);
        }

        List<Contender> CreateContenderListForPrincessWhoGet100()
        {
            var contenders = new List<Contender>();
            int contendersCount = 100;
            for (int i = 1; i <= 0.37 * contendersCount; i++)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = i;
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            for (int i = contendersCount; i > 0.37 * contendersCount; i--)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = i;
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }

        [Test]
        public void FindBestContender_GetHappy100()
        {
            List<Contender> contenderList = CreateContenderListForPrincessWhoGet100();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.ContendersCount()).Returns(_ContendersCount);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            IContenderForPrincess contender = princess.FindBestContender();
            int happyMark = princess.GoToHallAndGetHappyMark(contender);

            int happyMarkIfBestContender = 100;
            happyMark.Should().Be(happyMarkIfBestContender);
        }

        List<Contender> CreateContenderListForPrincessGetExceptionNoContenders()
        {
            var contenders = new List<Contender>();
            int contendersCount = 100;
            int contendersCountForException = 50;
            for (int i = contendersCount; i > contendersCountForException; i--)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = i;
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }

        [Test]
        public void FindBestContender_NoContenders_ThrowException()
        {
            List<Contender> contenderList = CreateContenderListForPrincessGetExceptionNoContenders();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.ContendersCount()).Returns(_ContendersCount);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            princess.Invoking(p => p.FindBestContender()).Should().Throw<Exception>().WithMessage("¬ коридоре больше нету претендентов!");
        }
    }
}