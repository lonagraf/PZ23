using System;
using System.Collections.Generic;
using System.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;
using PZ23.Windows;

namespace PZ23;

public partial class RequestWindow : Window
{
    private Database database = new Database();

    private List<Request> _requests;

    public string fullTable =
        "select RequestID, DateAdded, EquipmentName, DefectName, ProblemDescription, ClientName, StatusName from request " +
        "join pro1_4.equipment_type et on request.Equipment = et.EquipmentTypeID " +
        "join pro1_4.defect_type dt on request.Defect = dt.DefectTypeID " +
        "join pro1_4.client c on request.Client = c.ClientID " +
        "join pro1_4.request_status rs on request.RequestStatus = rs.RequestStatusID;";
    
    public RequestWindow()
    {
        InitializeComponent();
        ShowTable(fullTable);
    }

    public void ShowTable(string sql)
    {
        try
        {
            _requests = new List<Request>();
            database.openConnection();
            MySqlCommand command = new MySqlCommand(sql, database.getConnection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read() && reader.HasRows)
            {
                var currentRequest = new Request()
                {
                    RequestID = reader.GetInt32("RequestID"),
                    DateAdded = reader.GetString("DateAdded"),
                    Equipment = reader.GetString("EquipmentName"),
                    Defect = reader.GetString("DefectName"),
                    ProblemDescription = reader.GetString("ProblemDescription"),
                    Client = reader.GetString("ClientName"),
                    RequestStatus = reader.GetString("StatusName"),
                };
                    _requests.Add(currentRequest);
            }
            database.closeConnection();
            RequestDataGrid.ItemsSource = _requests;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    private void MainWindowOnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Hide();
        mainWindow.Show();
    }

    private void MenuItem_OnClick(object? sender, RoutedEventArgs e)
    {
        Request selectedRequest = RequestDataGrid.SelectedItem as Request;
        if (selectedRequest != null)
        {
            EditRequestWindow editRequestWindow = new EditRequestWindow(selectedRequest);
            this.Hide();
            editRequestWindow.Show();
            ShowTable(fullTable);
        }
        else
        {
            Console.WriteLine("Выберите строку для редактирования!!!");
        }

    }
}