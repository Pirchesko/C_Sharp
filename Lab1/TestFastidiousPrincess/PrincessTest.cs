using Microsoft.Extensions.Hosting;
using Moq;
using System;
using FastidiousPrincess;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using FluentAssertions;

namespace TestFastidiousPrincess
{
    public class PrincessTest
    {
        private Mock<IHostApplicationLifetime> _lifetime;
        private Mock<IContenderGenerator> _contenderGenerator;

        [SetUp]
        public void Setup()
        {
            _lifetime = new Mock<IHostApplicationLifetime>();
            _contenderGenerator = new Mock<IContenderGenerator>();
        }

        List<Contender> CreateContenderListForPrincessWhoNotMarried()
        {
            var contenders = new List<Contender>();
            for (int i = Constants.ContendersCount; i > 0; i--)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = i;
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }

        [Test]
        public void FindBestContender_PrincessNotMarried()
        {
            List<Contender> contenderList = CreateContenderListForPrincessWhoNotMarried();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            IContenderForPrincess contender = princess.FindBestContender();
            int happyMark = princess.GoToHallAndGetHappyMark(contender);

            int happyMarkIfPrincessNotMarried = 10;
            happyMark.Should().Be(happyMarkIfPrincessNotMarried);
        }

        List<Contender> CreateContenderListForPrincessWhoMarriedOnLooser()
        {
            var contenders = new List<Contender>();
            for (int i = 1; i <= Constants.ContendersCount; i++)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = i;
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }

        [Test]
        public void FindBestContender_PrincessMarriedOnLooser()
        {
            List<Contender> contenderList = CreateContenderListForPrincessWhoMarriedOnLooser();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            IContenderForPrincess contender = princess.FindBestContender();
            int happyMark = princess.GoToHallAndGetHappyMark(contender);

            int happyMarkIfPrincessMarriesOnLooser = 0;
            happyMark.Should().Be(happyMarkIfPrincessMarriesOnLooser);
        }

        List<Contender> CreateContenderListForPrincessWhoMarriedOnBestContender()
        {
            var contenders = new List<Contender>();
            for (int i = 1; i <= 0.37 * Constants.ContendersCount; i++)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = i;
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            for (int i = Constants.ContendersCount; i > 0.37 * Constants.ContendersCount; i--)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = i;
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }

        [Test]
        public void FindBestContender_PrincessMarriedOnBestContender()
        {
            List<Contender> contenderList = CreateContenderListForPrincessWhoMarriedOnBestContender();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            IContenderForPrincess contender = princess.FindBestContender();
            int happyMark = princess.GoToHallAndGetHappyMark(contender);

            int happyMarkIfMarriedOnBestContender = 100;
            happyMark.Should().Be(happyMarkIfMarriedOnBestContender);
        }

        List<Contender> CreateContenderListWithOneContender()
        {
            var contenderList = new List<Contender>();
            string firstName = Randomizer.GetRandomFirstName();
            string lastName = Randomizer.GetRandomWithoutRepeatLastName();
            int mark = Randomizer.GetRandomWithoutRepeatMark();
            var contender = new Contender(firstName, lastName, mark);
            contenderList.Add(contender);
            return contenderList;
        }

        [Test]
        public void FindBestContender_NoContenders_ThrowException()
        {
            List<Contender> contenderList = CreateContenderListWithOneContender();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend, _lifetime.Object);

            princess.Invoking(p => p.FindBestContender())
                .Should().Throw<Exception>()
                .WithMessage("В коридоре больше нету претендентов!");
        }
    }
}
