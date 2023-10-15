using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using PZ23.Windows;

namespace PZ23;

public partial class AdminWindow : RequestWindow
{
    public AdminWindow()
    {
        InitializeComponent();
    }

    private void AddRequestOnClick(object? sender, RoutedEventArgs e)
    {
       
        AddRequestWindow addRequest = new AddRequestWindow();
        this.Hide();
        addRequest.Show();
        ShowTable(fullTable);
    }

    private void RequestsOnClick(object? sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow();
        this.Hide();
        requestWindow.Show();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        RepairWindow repairWindow = new RepairWindow();
        this.Hide();
        repairWindow.Show();
    }
}