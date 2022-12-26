using FluentAssertions;
using FastidiousPrincess;
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
        [Test]
        public void GenerateUniqueContenders_ReturnUnique()
        {
            ContenderGenerator contenderGenerator = new ContenderGenerator();
            Hall hall = new Hall(contenderGenerator);
            hall.InitHall();
            var contenderList = new List<Contender>();
            for (int i = 0; i < Constants.ContendersCount; i++)
            {
                contenderList.Add(hall.GetNextContender());
            }
            contenderList.Should().HaveCount(Constants.ContendersCount).And.OnlyHaveUniqueItems();
        }
    }
}
