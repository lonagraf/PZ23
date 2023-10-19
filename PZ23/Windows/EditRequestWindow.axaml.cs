using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using MySql.Data.MySqlClient;

namespace PZ23.Windows;

public partial class EditRequestWindow : Window
{
    private Database database = new Database();
    private Request _request;
    public EditRequestWindow(Request request)
    {
        Icon = new WindowIcon("icons/edit.png");
        Width = 300;
        Height = 300;
        _request = request;
        InitializeComponent();
        RequestStatusTextBox.Text = _request.RequestStatus;
        ProblemDescriptionTextBox.Text = _request.ProblemDescription;
        EmployeeTextBox.Text = _request.Employee;
    }

    private void EditOnClick(object? sender, RoutedEventArgs e)
    {
        string requestStatus = RequestStatusTextBox.Text;
        string problemDescription = ProblemDescriptionTextBox.Text;
        string employee = EmployeeTextBox.Text;
        int id = _request.RequestID;
        database.openConnection();
        string sql =
            "update pro1_4.Request set RequestStatus = @RequestStatus, " +
            "ProblemDescription = @ProblemDescription, Employee = @Employee" +
            " where RequestID = @Id";
        MySqlCommand command = new MySqlCommand(sql, database.getConnection());
        command.Parameters.AddWithValue("@RequestStatus", requestStatus);
        command.Parameters.AddWithValue("@ProblemDescription", problemDescription);
        command.Parameters.AddWithValue("@Employee", employee);
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
        database.closeConnection();
        var box = MessageBoxManager.GetMessageBoxStandard("Уведомление", 
            "Статус заявки изменен", ButtonEnum.Ok);
        var result = box.ShowAsync();
    }

    private void BackOnClick(object? sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow();
        this.Hide();
        requestWindow.Show();
    }
    
}