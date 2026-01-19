using System.Globalization;

namespace Task_Manager.Converters
{
	public class SummaryMultiConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			// values[0] là CompletedCount, values[1] là TotalCount
			if (values != null && values.Length == 2 &&
				values[0] is int completed && values[1] is int total)
			{
				return $"Completed: {completed} / Total: {total}";
			}
			return "Calculating...";
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}
}