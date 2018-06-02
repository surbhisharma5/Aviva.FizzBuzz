namespace Aviva.FizzBuzz.Tests
{
    using BusinessLayer;
    using Interface;
    using Models;
    using Moq;
    using NUnit.Framework;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ApiBuisnessTests
    {
            public class DefaultRegistry : Registry
            {
                #region Constructors and Destructors

                public DefaultRegistry()
                {
                    Scan(
                        scan =>
                        {
                            scan.TheCallingAssembly();
                            scan.AddAllTypesOf<IFizzBuzz>();
                            scan.WithDefaultConventions();
                        });
                    For<IFizzBuzz>().Use<FizzBuzz>();
                    For<IBusinessRules>().Use<BusinessRules>();
                }

                #endregion
            }

            [SetUp]
            public static void ConfigureDependencies()
            {
                ObjectFactory.Initialize(x =>
                {
                    x.AddRegistry<DefaultRegistry>();

                });
            }


        [Test]
        public void Input_Number_42_Check_Count()
        {
            Mock<List<IFizzBuzz>> listInstance = new Mock<List<IFizzBuzz>>();
            IBusinessRules businessRules = new BusinessRules();
            List<IFizzBuzz> list = businessRules.GetData(42, listInstance.Object);
            Assert.AreEqual(42, list.Count);
            Assert.AreEqual("1", ((IFizzBuzz) list[0]).Message);
            Assert.AreEqual("2", ((IFizzBuzz) list[1]).Message);
        }

        [Test]
        public void Input_Number_Replace_3_Divisible_With_Proper_Message_Color()
        {
            Mock<List<IFizzBuzz>> listInstance = new Mock<List<IFizzBuzz>>();
            IBusinessRules businessRules = new BusinessRules();
            List<IFizzBuzz> list = businessRules.GetData(24, listInstance.Object);
            if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {
                Assert.AreEqual("Wizz", ((IFizzBuzz)list[2]).Message);
                Assert.AreEqual("Wizz", ((IFizzBuzz)list[5]).Message);
            }
            else
            {
                Assert.AreEqual("Fizz", ((IFizzBuzz)list[2]).Message);
                Assert.AreEqual("Fizz", ((IFizzBuzz)list[5]).Message);
            }
            Assert.AreEqual("blue", ((IFizzBuzz)list[2]).MessageColor);
            Assert.AreEqual("blue", ((IFizzBuzz)list[5]).MessageColor);
        }
    }

   
}
