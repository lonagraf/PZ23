using System;
using System.Collections.Generic;
using System.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace PZ23;

public partial class RequestWindow : Window
{
    private Database database = new Database();

    private List<Request> _requests;
    
    public string fullTable =
        "select RequestID, DateAdded, EquipmentName, DefectName, ProblemDescription, ClientName, StatusName, EmployeeName from pro1_4.request " +
        "join pro1_4.equipmenttype on request.Equipment = equipmenttype.EquipmentTypeID " +
        "join pro1_4.defecttype on request.Defect= defecttype.DefectTypeID " +
        "join pro1_4.client on request.Client = client.ClientID " +
        "join pro1_4.requeststatus on request.RequestStatus = requeststatus.RequestStatusID " +
        "join pro1_4.employee on request.Employee = employee.EmployeeID;";
    
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
                    Employee = reader.GetString("EmployeeName")
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
}