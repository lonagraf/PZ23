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
        Width = 300;
        Height = 300;
        Icon = new WindowIcon("icons/user.png");
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

    private void ReportOnClick(object? sender, RoutedEventArgs e)
    {
        ReportWindow repairWindow = new ReportWindow();
        this.Hide();
        repairWindow.Show();
    }

    private void StatisticsOnClick(object? sender, RoutedEventArgs e)
    {
        StatisticsWindow statisticsWindow = new StatisticsWindow();
        this.Hide();
        statisticsWindow.Show();
    }
}