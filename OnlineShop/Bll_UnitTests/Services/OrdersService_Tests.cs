using BLL.AutoMapperConfiguration;
using BLL.DTO;
using BLL.Services;
using DAL.Abstract;
using DAL.DataEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bll_UnitTests.Services
{
    [TestClass]
    public class OrdersService_Tests
    {
        static OrdersService_Tests()
        {
            AutoMapperConfiguration.Initialize();

        }

        private List<Stage> _stages = new List<Stage> {
            new Stage { Caption = "TEST"}
        };

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Throws_WhenUnitOfWorkIsNull()
        {
            //sut
            var sut = new OrdersService(null);
        }

        [TestMethod]
        public void Constructor_CreatesInstance_WhenAllIsOk()
        {
            //arrange 
            var unitOfWork = new Mock<IUnitOfWork>();

            //sut 
            var sut = new OrdersService(unitOfWork.Object);
        }

        [TestMethod]
        public void GetAllOrderStages_ReturnsExpectedStages_WhenAllIsOk()
        {
            //arrange
            var uow = new Mock<IUnitOfWork>();

            uow.Setup(x => x.Stages.GetAll()).Returns(_stages);

            //sut 
            var sut = new OrdersService(uow.Object);
            var result = sut.GetAllOrderStages().ToList();

            //assert 
            Assert.AreEqual(_stages.Count, result.Count);
            Assert.AreEqual(_stages[0].Caption, result[0].Caption);
        }

        [TestMethod]
        public void AddStage_AddsNewStage_WhenAllIsOk()
        {
            //arrange
            var uow = new Mock<IUnitOfWork>();

            uow.Setup(x => x.Stages.Add(It.IsAny<Stage>()))
                .Callback((Stage x) => { _stages.Add(x); });
            uow.Setup(x => x.Stages.GetAll()).Returns(_stages);

            var newStage = new StageDto() { Caption = "TEST1"};

            var stagesBefore = uow.Object.Stages.GetAll().Count();

            //sut
            var sut = new OrdersService(uow.Object);
            sut.AddStage(newStage);
            var stages = sut.GetAllOrderStages().ToList();

            //assert
            Assert.AreEqual(stagesBefore + 1, stages.Count);
            Assert.AreEqual(stages[1].Caption, newStage.Caption);
        }
    }
}
