using System;
using System.Collections.Generic;
using System.Linq;
using Parking.BL;
using Parking.Model;
using Parking.Utils;

namespace Parking.Engine
{
	public class EarlyBirdCalculator : ICalculator<EarlyBirdCalculator>
	{
		private readonly IModelBuilder<string, IEnumerable<RefData>> _refDataBuilder;

		public EarlyBirdCalculator(IModelBuilder<string, IEnumerable<RefData>> refDataBuilder)
		{
			_refDataBuilder = refDataBuilder;
		}

		public IRate Calculate(TimeSlot timeSlot)
		{
			if (!timeSlot.EntryTime.IsWeekday()) return GetRate(timeSlot, 0) ;

			if (timeSlot.EntryTime >= new DateTime(timeSlot.EntryTime.Year, timeSlot.EntryTime.Month, timeSlot.EntryTime.Day, 6, 0, 0)
			&& timeSlot.EntryTime <= new DateTime(timeSlot.EntryTime.Year, timeSlot.EntryTime.Month, timeSlot.EntryTime.Day, 9, 0, 0)
			&& timeSlot.ExitTime >= new DateTime(timeSlot.ExitTime.Year, timeSlot.ExitTime.Month, timeSlot.ExitTime.Day, 15, 30, 0)
			&& timeSlot.ExitTime <= new DateTime(timeSlot.ExitTime.Year, timeSlot.ExitTime.Month, timeSlot.ExitTime.Day, 23, 30, 0))
			{
				var refDatas = _refDataBuilder.Build("Early Bird Rate").ToList();
				var refData = refDatas.FirstOrDefault();
				return GetRate(timeSlot, refData?.Amount ?? 0);
			}

			return GetRate(timeSlot, 0);
		}

		public IRate GetRate(TimeSlot timeSlot, decimal amount)
		{
			return new Rate { TimeSlot = timeSlot, ParkingRate = new ParkingRate { Amount = amount, Name = "Early Bird Rate"} };
		}
	}
}