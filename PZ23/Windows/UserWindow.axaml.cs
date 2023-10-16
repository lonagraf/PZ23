using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace PZ23;

public partial class UserWindow : RequestWindow
{
    public UserWindow()
    {
        Width = 300;
        Height = 300;
        InitializeComponent();
        Icon = new WindowIcon("icons/user.png");
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        AddRequestWindow addRequest = new AddRequestWindow();
        this.Hide();
        addRequest.Show();
        ShowTable(fullTable);
    }
}