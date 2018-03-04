using System;
using System.Collections.Generic;
using System.Linq;
using CommonLib;
using Parking.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Parking.BL.Builders;
using Parking.Engine;

namespace Parking.Test
{
	[TestClass]
	public class ParkingCalculatorTests
	{
		private readonly ParkingCalculator _calculator;
		private readonly Mock<IRepository<RefData>> _mockRepository;
		private const string StandardRate = "Standard Rate";
		private const string EarlyBirdRate = "Early Bird Rate";
		private List<RefData> _refDatas;

		public ParkingCalculatorTests()
		{
			_mockRepository = new Mock<IRepository<RefData>>();
			var refDataBuilder = new RefDataBuilder(_mockRepository.Object);
			var earlyBirdCalculator = new EarlyBirdCalculator(refDataBuilder);
			var standardRateCalculator = new StandardRateCalculator(refDataBuilder);
			var mockParkingCalculator = new Mock<ParkingCalculator>(earlyBirdCalculator, standardRateCalculator);
			_calculator = mockParkingCalculator.Object;
		}

		[TestInitialize]
		public void Setup()
		{
			_refDatas = new List<RefData>
			{
				new RefData {Amount = 5, RefDataTypeId = 4, Name = StandardRate, Duration = 1, RefDataType = new RefDataType { Name = StandardRate} },
				new RefData {Amount = 10, RefDataTypeId = 4, Name = StandardRate, Duration = 2, RefDataType = new RefDataType { Name = StandardRate}},
				new RefData {Amount = 15, RefDataTypeId = 4, Name = StandardRate, Duration = 3, RefDataType = new RefDataType { Name = StandardRate}},
				new RefData {Amount = 20, RefDataTypeId = 4, Name = StandardRate, Duration = 3.1, RefDataType = new RefDataType { Name = StandardRate}},
				new RefData {Amount = 13, RefDataTypeId = 1, Name = EarlyBirdRate, RefDataType = new RefDataType { Name = EarlyBirdRate}}
			};

		}

		[TestMethod]
		public void WhenEntryIsBetween6AmAnd9AmAndExitIsBetween330PmAnd11Pm()
		{
			//Arrange
			var timeSlot = new TimeSlot
			{
				EntryTime = new DateTime(2018, 1, 5, 6, 0, 0),
				ExitTime = new DateTime(2018, 1, 5, 15, 30, 0)
			};
			_mockRepository.Setup(x => x.Matches(It.IsAny<ICriteria<RefData>>())).Returns(_refDatas.Where(x => x.RefDataType.Name == EarlyBirdRate).AsQueryable());
			var expectedParkingRate = new ParkingRate { Amount = 13, Name = EarlyBirdRate };

			//Act
			var actualRate = _calculator.Calculate(timeSlot);

			//Assert
			Assert.AreEqual(expectedParkingRate.Amount, actualRate.ParkingRate.Amount);
			Assert.AreEqual(expectedParkingRate.Name, actualRate.ParkingRate.Name);

		}

		[TestMethod]
		public void WhenEntryIsBetween6PmAnd12AmAndExitNextDayBefore6Am()
		{
			//Arrange
			var timeSlot = new TimeSlot
			{
				EntryTime = new DateTime(2018, 1, 5, 6, 0, 0),
				ExitTime = new DateTime(2018, 1, 5, 15, 30, 0)
			};
			_mockRepository.Setup(x => x.Matches(It.IsAny<ICriteria<RefData>>())).Returns(_refDatas.Where(x => x.RefDataType.Name == EarlyBirdRate).AsQueryable());
			var expectedParkingRate = new ParkingRate { Amount = 13, Name = EarlyBirdRate };

			//Act
			var actualRate = _calculator.Calculate(timeSlot);

			//Assert
			Assert.AreEqual(expectedParkingRate.Amount, actualRate.ParkingRate.Amount);
			Assert.AreEqual(expectedParkingRate.Name, actualRate.ParkingRate.Name);
		}

		[TestMethod]
		public void GivenEntryAndExitTimeShouldReturnRate20WhenDurationIsMoreThan3Hours()
		{
			//Arrange
			var timeSlot = new TimeSlot
			{
				EntryTime = new DateTime(2018, 1, 5, 9, 1, 0),
				ExitTime = new DateTime(2018, 1, 5, 15, 0, 0)
			};
			_mockRepository.Setup(x => x.Matches(It.IsAny<ICriteria<RefData>>())).Returns(_refDatas.Where(x => x.RefDataType.Name == StandardRate).AsQueryable());
			var expectedParkingRate = new ParkingRate { Amount = 20, Name = StandardRate };

			//Act
			var actualRate = _calculator.Calculate(timeSlot);

			//Assert
			Assert.AreEqual(expectedParkingRate.Amount, actualRate.ParkingRate.Amount);
			Assert.AreEqual(expectedParkingRate.Name, actualRate.ParkingRate.Name);
		}

	}
}
