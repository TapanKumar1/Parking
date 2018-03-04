using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using Parking.Engine;
using Parking.Model;

namespace Parking.Winform
{
	public partial class Form1 : Form
	{
		private readonly ICalculator<EarlyBirdCalculator> _earlyBirdCalculator;
		private readonly ICalculator<StandardRateCalculator> _standardRateCalculator;
		public Form1(ICalculator<EarlyBirdCalculator> earlyBirdCalculator, ICalculator<StandardRateCalculator> standardRateCalculator)
		{
			_earlyBirdCalculator = earlyBirdCalculator;
			_standardRateCalculator = standardRateCalculator;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			var calculatedRate = new ParkingCalculator(_earlyBirdCalculator, _standardRateCalculator)
								.Calculate(new TimeSlot
								{
									EntryTime = dtpEntry.Value,
									ExitTime = dtpExit.Value
								});

			result.Text = JsonConvert.SerializeObject(calculatedRate, Formatting.Indented);
			this.Cursor = Cursors.Default;
		}
	}
}
