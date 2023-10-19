using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using MySql.Data.MySqlClient;
using PZ23.Windows;

namespace PZ23;

public partial class RequestWindow : Window
{
    private Database database = new Database();

    private List<Request> _requests;

    public string fullTable =
        "select RequestID, DateAdded, EquipmentName, DefectName, ProblemDescription, " +
        "ClientName, StatusName,EmployeeName, PriorityName from pro1_4.Request " +
        "join pro1_4.equipment_type et on Request.Equipment = et.EquipmentTypeID " +
        "join pro1_4.defect_type dt on Request.Defect = dt.DefectTypeID " +
        "join pro1_4.client c on Request.Client = c.ClientID " +
        "join pro1_4.request_status rs on Request.RequestStatus = rs.RequestStatusID " +
        "join pro1_4.priority P on Request.Priority = P.PriorityID " +
        "join pro1_4.employee e on request.Employee = e.EmployeeID;";
    
    public RequestWindow()
    {
        Icon = new WindowIcon("icons/window-alt.png");
        InitializeComponent();
        ShowTable(fullTable);
    }

    public void ShowTable(string sql)
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
                Priority = reader.GetString("PriorityName"),
                Employee = reader.GetString("EmployeeName")
            }; 
                _requests.Add(currentRequest);
        }
        database.closeConnection();
        RequestDataGrid.ItemsSource = _requests;
    }

    private void MainWindowOnClick(object? sender, RoutedEventArgs e)
    {
        AdminWindow adminWindow = new AdminWindow();
        this.Hide();
        adminWindow.Show();
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
            //Console.WriteLine("Выберите строку для редактирования!!!");
            var box = MessageBoxManager.GetMessageBoxStandard("Ошибка",
                "Выберите строку для редактирования", ButtonEnum.Ok);
            var result = box.ShowAsync();
        }

    }

    private void TxtSearch_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        List<Request> search = _requests.Where(x => x.RequestID.
            ToString().Contains(txtSearch.Text.ToString())).ToList();
        RequestDataGrid.ItemsSource = search;
    }
}