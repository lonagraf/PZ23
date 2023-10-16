﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace PZ23;

public partial class AddRequestWindow : Window
{
    private Database database = new Database();
    public AddRequestWindow()
    {
        InitializeComponent();
        Width = 300;
        Height = 450;
        
    }

    private void AddRequestOnClick(object? sender, RoutedEventArgs e)
    {
        string dateAdded = DateTextBox.Text;
        string equipment = EquipmentTextBox.Text;
        string defect = DefectTextBox.Text;
        string client = ClientTextBox.Text;
        string requestStatus = RequestStatusTextBox.Text;
        string problemDescription = ProblemDescriptionTextBox.Text;
        database.openConnection();
        string sql =
            "insert into Request (DateAdded, Equipment, Defect, Client, RequestStatus, ProblemDescription) " +
            "values (@DateAdded, @Equipment, @Defect, @Client, @RequestStatus, @ProblemDescription);";
        MySqlCommand command = new MySqlCommand(sql, database.getConnection());
        command.Parameters.AddWithValue("@DateAdded",dateAdded);
        command.Parameters.AddWithValue("@Equipment",equipment);
        command.Parameters.AddWithValue("@Defect",defect);
        command.Parameters.AddWithValue("@Client",client);
        command.Parameters.AddWithValue("@RequestStatus",requestStatus);
        command.Parameters.AddWithValue("ProblemDescription",problemDescription);
        command.ExecuteNonQuery();
        database.closeConnection();
    }

    private void BackOnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Hide();
        mainWindow.Show();
    }
}