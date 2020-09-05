using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using ToDOList.Services;
using ToDOList.ViewModel;

namespace ToDOList
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<ItemsViewModel> items = new List<ItemsViewModel>
            {
                new ItemsViewModel{WorkContent="測試一二三四五",IsDown=false,IsImportant=false },
                new ItemsViewModel{WorkContent="測試二",IsDown=false,IsImportant=false },
                new ItemsViewModel{WorkContent="測試三",IsDown=false,IsImportant=false }
            };
            TodoList.ItemsSource = items;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListMenu.SelectedIndex;
            
        }

        private void inputText_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                if (inputText.Text == null) return;

                var vm = new ItemsViewModel();
                vm.WorkContent = inputText.Text;
                vm.IsDown = false;
                vm.IsImportant = false;
                var service = new ToDoListService();
                var result = service.AddJobs(vm);
                if (result.IsSuccessful)
                {
                    MessageBox.Show("成功");
                }
                else
                {
                    var path = result.WriteLog();
                    MessageBox.Show($"發生錯誤，請參考{path}");
                }
            }
        }
    }
}
