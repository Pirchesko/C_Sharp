using FluentAssertions;
using Labs;
using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestFastidiousPrincess
{
    public class ContenderGeneratorTest
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

        List<Contender> CreateContenderListWithoutUniqueContenders()
        {
            var contenders = new List<Contender>();
            int contendersCount = 100;
            for (int i = 0; i < contendersCount; i++)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = Randomizer.GetRandomWithoutRepeatMark();
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }

        bool CheckUniqueListContender(List<Contender> contenders)
        {
            Contender[] contendersArray = contenders.ToArray();
            IEnumerable<Contender> distingContenders = contendersArray.Distinct();
            if (contendersArray.Count() == distingContenders.Count())
            {
                return true;
            }
            return false;
        }

        [Test]
        public void GenerateUniqueContenders_ReturnUnique()
        {
            ContenderGenerator contenderGenerator = new ContenderGenerator();
            Hall hall = new Hall(contenderGenerator);
            var contenderList = new List<Contender>();
            for (int i = 0; i < _ContendersCount; i++)
            {
                contenderList.Add(hall.GetNextContender());
            }
            bool unique = true;
            bool checkListContenderUnique = CheckUniqueListContender(contenderList);
            checkListContenderUnique.Should().Be(unique);
        }
    }
}
