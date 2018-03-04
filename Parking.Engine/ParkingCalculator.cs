using Parking.Model;

namespace Parking.Engine
{
	public class ParkingCalculator
	{
		private readonly ICalculator<EarlyBirdCalculator> _earlyBirdCalculator;
		private readonly ICalculator<StandardRateCalculator> _standardRateCalculator;
		
		public ParkingCalculator(ICalculator<EarlyBirdCalculator> earlyBirdCalculator,
			ICalculator<StandardRateCalculator> standardRateCalculator)
		{
			_earlyBirdCalculator = earlyBirdCalculator;
			_standardRateCalculator = standardRateCalculator;
		}

		public IRate Calculate(TimeSlot timeSlot)
		{
			//Early Bird Calculator

			var rate = _earlyBirdCalculator.Calculate(timeSlot);
			if(rate.ParkingRate.Amount > 0) return rate;

			/* Night Rate Calculator
			...
			...
			...
			*/

			/* Weekend Rate Calculator
			...
			...
			...
			*/

			//Standard Rate Calculator
			rate = _standardRateCalculator.Calculate(timeSlot);
			if (rate.ParkingRate.Amount > 0) return rate;

			return new Rate { ParkingRate = new ParkingRate { Amount = 0.0m, Name = "Unknown"}, TimeSlot = timeSlot} ;
		}
	}
}