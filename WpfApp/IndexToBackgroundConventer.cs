using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp
{
    class IndexToBackgroundConventer : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int number = int.Parse(value.ToString());
			if (number % 2 == 0)
			{
				var converter = new System.Windows.Media.BrushConverter();
				var brush = (Brush)converter.ConvertFromString("#FFAFC5FF");
				return brush;
			}
			else
			{
				var converter = new System.Windows.Media.BrushConverter();
				var brush = (Brush)converter.ConvertFromString("#FF75A1FF");
				return brush;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
