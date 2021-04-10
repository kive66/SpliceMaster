using DMSkin.CloudMusic.ViewModel;
using SpliceMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DMSkin.CloudMusic.View {
    /// <summary>
    /// EditWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditWindow  {
        public EditWindow() {
            InitializeComponent();
            DataContext = new EditViewModel();
        }
        private void DMSystemCloseButton_Click(object sender, System.Windows.RoutedEventArgs e) {

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e) {

        }
        private void tb_PreviewTextInput(object sender, TextCompositionEventArgs e) {

            Regex re = new Regex("[^0-9.]+");

            e.Handled = re.IsMatch(e.Text);

        }
    }
}
