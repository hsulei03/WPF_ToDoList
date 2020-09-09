using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<ItemsViewModel> itemViewModel;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ToDoViewModel();
            itemViewModel = GetMyday();
            TodoList.ItemsSource = itemViewModel;
            ListMenu.SelectedIndex = 0;
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
            Show(index);
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
                    AddTask();
                }
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (inputText.Text == "")
            {
                MessageBox.Show("工作內容不可為空");
                return;
            }
            else
            {
                AddTask();
            }
        }
        private void Completed_Click(object sender, RoutedEventArgs e)
        {
            Button completed = (Button)sender;
            var taskId = completed.Tag;
            var service = new ToDoListService();
            var result = service.Completed((int)taskId);
            var target = itemViewModel.FirstOrDefault((x) => x.Id == (int)taskId);
            if (result.IsSuccessful)
            {
                //成功再改變畫面
                var index = (MenuOptions)ListMenu.SelectedIndex;
                Show(index);
            }
            else
            {
                var path = result.WriteLog();
                MessageBox.Show($"發生錯誤，請參考{path}");
            }
        }

        private void BtnImportant_Click(object sender, RoutedEventArgs e)
        {
            Button completed = (Button)sender;
            var taskId = completed.Tag;
            var service = new ToDoListService();
            var result = service.Important((int)taskId);
            var target = itemViewModel.FirstOrDefault((x) => x.Id == (int)taskId);
            if (result.IsSuccessful)
            {
                //成功再改變畫面
                var index = (MenuOptions)ListMenu.SelectedIndex;
                Show(index);
            }
            else
            {
                var path = result.WriteLog();
                MessageBox.Show($"發生錯誤，請參考{path}");
            }
        }

        private ObservableCollection<ItemsViewModel> GetTasks()
        {
            var service = new ToDoListService();
            var dateString = string.Empty;
            var result = service.GetTaskList(dateString);
            return result;
        }
        private ObservableCollection<ItemsViewModel> GetMyday()
        {
            var service = new ToDoListService();
            var dateString = DateTime.Now.ToString("yyyy-MM-dd");
            var result = service.GetTaskList(dateString);
            return result;
        }
        private ObservableCollection<ItemsViewModel> GetImportant()
        {
            var service = new ToDoListService();
            var result = service.GetImportant();
            return result;
        }

        private void AddTask()
        {
            var vm = new ItemsViewModel();
            vm.WorkContent = inputText.Text;
            var service = new ToDoListService();
            //存入資料庫
            var result = service.AddTasks(vm);
            if (result.IsSuccessful)
            {
                //成功再改變畫面
                itemViewModel.Add(vm);
            }
            else
            {
                var path = result.WriteLog();
                MessageBox.Show($"發生錯誤，請參考{path}");
            }
            inputText.Text = string.Empty;

        }
        private void Show(MenuOptions index)
        {
            switch (index)
            {
                case MenuOptions.myday:
                    itemViewModel = GetMyday();
                    TodoList.ItemsSource = itemViewModel;
                    break;
                case MenuOptions.important:
                    itemViewModel = GetImportant();
                    TodoList.ItemsSource = itemViewModel;
                    break;
                case MenuOptions.planned:
                    //GetPlanned();
                    break;
                case MenuOptions.assignedToMe:
                    //GetAssigendToMe();
                    break;
                case MenuOptions.work:
                    itemViewModel = GetTasks();
                    TodoList.ItemsSource = itemViewModel;
                    break;
                default:
                    break;
            }
        }


    }
}
