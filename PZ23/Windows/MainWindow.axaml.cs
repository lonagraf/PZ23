using Avalonia.Controls;
using Avalonia.Interactivity;
using PZ23.Windows;

namespace PZ23;

public partial class MainWindow : RequestWindow
{
    public MainWindow()
    {
        Icon = new WindowIcon("icons/home.png");
        Width = 300;
        Height = 300;
        InitializeComponent();
        var comboBox = this.FindControl<ComboBox>("AuthCmb");
        comboBox.ItemsSource = new[] { "Администратор", "Пользователь" };
    }

    /*private void RequestsWindowOnClick(object? sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow();
        this.Hide();
        requestWindow.Show();
    }
    
    private void AddRequestWindowOnClick(object? sender, RoutedEventArgs e)
    {
        AddRequestWindow addRequest = new AddRequestWindow();
        this.Hide();
        addRequest.Show();
        ShowTable(fullTable);
    }*/

    private void AuthBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var comboBox = this.FindControl<ComboBox>("AuthCmb");
        comboBox.ItemsSource = new[] { "Администратор", "Пользователь" };
        string selectedRole = comboBox.SelectedItem.ToString();
        string password = AuthTxt.Text;
        if (selectedRole == "Администратор" && password == "admin")
        {
            AdminWindow adminWindow = new AdminWindow();
            this.Hide();
            adminWindow.Show();
        }
        else if (selectedRole == "Пользователь" && password == "user")
        {
            UserWindow userWindow = new UserWindow();
            this.Hide();
            userWindow.Show();
        }
        else
        {
            
        }
    }
}