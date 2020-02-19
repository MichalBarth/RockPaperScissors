using RockPaperScissors.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace RockPaperScissors.ViewModel.Converters
{
    class ResultToPictureConverter : IValueConverter
    {
        public BitmapImage Rock { get; set; }
        public BitmapImage Paper { get; set; }
        public BitmapImage Scissors { get; set; }
        public BitmapImage None { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is RPSResult)
            {
                switch ((int)value)
                {
                    case 0: { return None; }
                    case 1: { return Rock; }
                    case 2: { return Paper; }
                    case 3: { return Scissors; }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
