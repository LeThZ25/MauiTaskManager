using System.Globalization;

namespace Task_Manager.Converters
{
	public class BoolToStrikethroughConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// Nếu IsCompleted = true thì gạch ngang (Strikethrough), ngược lại thì không (None)
			if (value is bool isCompleted && isCompleted)
				return TextDecorations.Strikethrough;

			return TextDecorations.None;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}
}