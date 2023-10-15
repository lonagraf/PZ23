using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PZ23;

public partial class MainWindow : RequestWindow
{
    public MainWindow()
    {
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
        string selectedRole = comboBox.SelectedItem.ToString();
        if (selectedRole == "Администратор")
        {
            AdminWindow adminWindow = new AdminWindow();
            this.Hide();
            adminWindow.Show();
        }
        else
        {
            UserWindow userWindow = new UserWindow();
            this.Hide();
            userWindow.Show();
        }
    }
}