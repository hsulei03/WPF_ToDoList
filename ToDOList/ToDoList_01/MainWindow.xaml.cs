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
using ToDoList_01.Service;
using ToDoList_01.ViewModel;

namespace ToDoList_01
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public enum MenuOptions
    {
        myday,
        important,
        planned,
        assignedToMe,
        work,
    }
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ToDoViewModel();
            GetMyday();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index =(MenuOptions)ListMenu.SelectedIndex;
            ListView listView = (ListView)sender;
            IEnumerable<MenuModel> items = (IEnumerable<MenuModel>)listView.ItemsSource;
            TitleText.Text = items.ToArray()[ListMenu.SelectedIndex].Title;
            switch (index)
            {
                case MenuOptions.myday:
                    GetMyday();
                    break;
                case MenuOptions.important:
                    //GetImportant();
                    break;
                case MenuOptions.planned:
                    //GetPlanned();
                    break;
                case MenuOptions.assignedToMe:
                    //GetAssigendToMe();
                    break;
                case MenuOptions.work:
                    GetWorks();
                    break;
                default:
                    break;
            }
                
            
        }

        private void inputText_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if (inputText.Text == "")
                {
                    MessageBox.Show("工作內容不可為空");
                    return;
                }
                else
                {
                    AddJobs();
                }
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var ddd = BtnAdd.Tag;
            if (inputText.Text == "")
            {
                MessageBox.Show("工作內容不可為空");
                return;
            }
            else
            {
                AddJobs();
            }
        }

        private void GetWorks()
        {
            var service = new ToDoListService();
            var dateString = string.Empty;
            TodoList.ItemsSource = service.GetJobList(dateString);
        }

        private void GetMyday()
        {
            var service = new ToDoListService();
            var dateString = DateTime.Now.ToString("yyyy-MM-dd");
            TodoList.ItemsSource = service.GetJobList(dateString);
        }

        private void AddJobs()
        {
            var vm = new ItemsViewModel();
            vm.WorkContent = inputText.Text;
            var service = new ToDoListService();
            var result = service.AddJobs(vm);
            if (result.IsSuccessful)
            {
                GetMyday();
            }
            else
            {
                var path = result.WriteLog();
                MessageBox.Show($"發生錯誤，請參考{path}");
            }
            inputText.Text = string.Empty;

        }

        private void Completed_Click(object sender, RoutedEventArgs e)
        {
            Button jobId = (Button)sender;
            var service = new ToDoListService();

        }
    }
}
