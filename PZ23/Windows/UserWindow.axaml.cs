using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace PZ23;

public partial class UserWindow : RequestWindow
{
    public UserWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        AddRequestWindow addRequest = new AddRequestWindow();
        this.Hide();
        addRequest.Show();
        ShowTable(fullTable);
    }
}