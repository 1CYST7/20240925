using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20240925
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> drinks = new Dictionary<string, int>
        {
            {"紅茶大杯",60},
            {"紅茶小杯",40},
            {"綠茶大杯",50},
            {"綠茶小杯",30},
            {"可樂大杯",50},
            {"可樂小杯",30},
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var targetTextBox = sender as TextBox;
            int amount;
            bool success = int.TryParse(targetTextBox.Text, out amount);
            if (!success)
            {
                MessageBox.Show("請輸入數字", "輸入錯誤");
            }
            else if (amount <= 0)
            {
                MessageBox.Show("請輸入正整數", "輸入錯誤");
            }
            else
            {
                var targetStackPanel = targetTextBox.Parent as StackPanel;
                var targetlabel = targetStackPanel.Children[0] as Label;
                var drinkname = targetlabel.Content.ToString();
                MessageBox.Show(drinkname + " " + amount + "杯，共" + drinks[drinkname] * amount + "元");
            }
        }
    }
}