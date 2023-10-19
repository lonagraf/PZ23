using System;
using System.Collections.Generic;
using System.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace PZ23.Windows;

public partial class ReportWindow : Window
{
    private Database database = new Database();
    
    private List<Report> _repairs;

    public string fullTable =
        "select reportID, request, dateStart, " +
        "dateEnd, cost, materialsName, defectCause from pro1_4.report " +
        "join pro1_4.materials on report.materials = materials.materialsID;";

    public ReportWindow()
    {
        Icon = new WindowIcon("icons/document.png");
        Width = 820;
        Height = 200;
        InitializeComponent();
        ShowTable(fullTable);
    }

    public void ShowTable(string sql)
    {
        _repairs = new List<Report>();
        database.openConnection();
        MySqlCommand command = new MySqlCommand(sql, database.getConnection());
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentRepair = new Report()
            {
                ReportID  = reader.GetInt32("reportID"),
                Request = reader.GetInt32("request"),
                DateStart = reader.GetString("dateStart"),
                DateEnd = reader.GetString("dateEnd"),
                Cost = reader.GetDouble("cost"),
                Materials = reader.GetString("materialsName"),
                DefectCause = reader.GetString("defectCause")
            };
            _repairs.Add(currentRepair);
        }
        database.closeConnection();
        RepairDataGrid.ItemsSource = _repairs;
    }

    private void BackBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        AdminWindow adminWindow = new AdminWindow();
        this.Hide();
        adminWindow.Show();
    }
}