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
        // 定義飲料價格及其字典
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
            // 初始化元件，將 XAML 中定義的 UI 元素載入視窗
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var targetTextBox = sender as TextBox; // 取得觸發事件的 TextBox 控件

            int amount; // 宣告數量變數
            bool success = int.TryParse(targetTextBox.Text, out amount); // 將文字轉換為整數並判斷是否成功

            if (!success)
                MessageBox.Show("請輸入數字", "輸入錯誤"); // 若轉換失敗，顯示錯誤訊息
            else if (amount <= 0)
                MessageBox.Show("請輸入正整數", "輸入錯誤"); // 若輸入的數量為 0 或負數，顯示錯誤訊息
            else
            {
                var targetStackPanel = targetTextBox.Parent as StackPanel; // 取得 TextBox 的父容器 StackPanel
                var targetLabel = targetStackPanel.Children[0] as Label; // 第一個子元素是 Label，取出並作為飲料名稱的標籤
                var drinkName = targetLabel.Content.ToString(); // 取得標籤內容，為飲料名稱

                // 顯示訊息框，包含飲料名稱、數量和總價
                MessageBox.Show(drinkName + " " + amount + "杯，共" + drinks[drinkName] * amount + "元");
            }
        }
    }
}