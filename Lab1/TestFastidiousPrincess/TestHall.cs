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
    public class TestHall
    {
        private Mock<IContenderGenerator> _contenderGenerator;

        [SetUp]
        public void Setup()
        {
            _contenderGenerator = new Mock<IContenderGenerator>();
        }

        List<Contender> CreateContenderListWithTwoContenders()
        {
            var contenders = new List<Contender>();
            for (int i = 0; i < 2; i++)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = Randomizer.GetRandomWithoutRepeatMark();
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }

        [Test]
        public void GetNextContender_ReturnContender()
        {
            List<Contender> contenderList = CreateContenderListWithTwoContenders();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);

            var contenderFirst = contenderList[0];
            var contender = hall.GetNextContender();
            contender.Should().Be(contenderFirst);
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
        public void GetNextContender_NoContenders_ThrowException()
        {
            List<Contender> contenderList = CreateContenderListWithOneContender();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);
            hall.GetNextContender();
            hall.Invoking(h => h.GetNextContender()).Should().Throw<Exception>().WithMessage("В коридоре больше нету претендентов!");
        }

        [Test]
        public void GetMarkByName_GetCorrectMark()
        {
            List<Contender> contenderList = CreateContenderListWithOneContender();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);
            Contender contender = hall.GetNextContender();
            int markByName = hall.GetMarkByName(contender);
            int mark = contender.Mark;
            markByName.Should().Be(mark);
        }

        [Test]
        public void GetMarkByName_ContenderNotExist_ReturnException()
        {
            List<Contender> contenderList = CreateContenderListWithOneContender();
            _contenderGenerator.Setup(contenderGenerator => contenderGenerator.CreateListContender()).Returns(contenderList);
            Hall hall = new Hall(_contenderGenerator.Object);

            string firstName = Randomizer.GetRandomFirstName();
            string lastName = Randomizer.GetRandomWithoutRepeatLastName();
            int mark = Randomizer.GetRandomWithoutRepeatMark();
            var contender = new Contender(firstName, lastName, mark);

            hall.Invoking(h => h.GetMarkByName(contender))
                .Should().Throw<Exception>()
                .WithMessage("Такого претендента не существовало");
        }
    }
}
