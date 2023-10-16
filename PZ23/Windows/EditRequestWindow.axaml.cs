using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace PZ23.Windows;

public partial class EditRequestWindow : Window
{
    private Database database = new Database();
    private Request _request;
    public EditRequestWindow(Request request)
    {
        _request = request;
        InitializeComponent();
        RequestStatusTextBox.Text = _request.RequestStatus;
        ProblemDescriptionTextBox.Text = _request.ProblemDescription;
    }

    private void EditOnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            string requestStatus = RequestStatusTextBox.Text;
            string problemDescription = ProblemDescriptionTextBox.Text;
            int id = _request.RequestID;
            database.openConnection();
            string sql =
                "update pro1_14.Request set RequestStatus = @RequestStatus, ProblemDescription = @ProblemDescription where RequestID = @Id";
            MySqlCommand command = new MySqlCommand(sql, database.getConnection());
            command.Parameters.AddWithValue("@RequestStatus", requestStatus);
            command.Parameters.AddWithValue("@ProblemDescription", problemDescription);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            database.closeConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    private void BackOnClick(object? sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow();
        this.Hide();
        requestWindow.Show();
    }
}