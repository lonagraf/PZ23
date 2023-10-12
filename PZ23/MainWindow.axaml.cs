using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PZ23;

public partial class MainWindow : RequestWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void RequestsWindowOnClick(object? sender, RoutedEventArgs e)
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
    }
}