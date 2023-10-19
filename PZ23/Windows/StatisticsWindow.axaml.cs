using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using MySql.Data.MySqlClient;

namespace PZ23.Windows;

public partial class StatisticsWindow : Window
{
    private Database database = new Database();
    private List<Statistics> _statisticsList = new List<Statistics>();

    public string finRequests =
        "select count(*) as AmountFinRequest from pro1_4.request " +
        "join pro1_4.request_status RS on Request.RequestStatus = RS.RequestStatusID " +
        "where StatusName like 'Выполнено';";

    public string defectStatistic =
        "select DefectName, count(Defect) as AmountDefects from defect_type " +
        "join pro1_4.Request R on defect_type.DefectTypeID = R.Defect " +
        "group by DefectName;";
    public StatisticsWindow()
    {
        Icon = new WindowIcon("icons/stats.png");
        Width = 500;
        Height = 200;
        InitializeComponent();
        ShowFinRequests(finRequests);
        ShowDefectStatistic(defectStatistic);
    }

    public void ShowFinRequests(string sql)
    {
        _statisticsList = new List<Statistics>();
        database.openConnection();
        MySqlCommand command = new MySqlCommand(sql, database.getConnection());
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentStatistics = new Statistics()
            {
                AmountFinRequest = reader.GetInt32("AmountFinRequest"),
            };
            _statisticsList.Add(currentStatistics);
        }
        database.closeConnection();
        FinRequestsDataGrid.ItemsSource = _statisticsList;
    }

    public void ShowDefectStatistic(string sql)
    {
        _statisticsList = new List<Statistics>();
        database.openConnection();
        MySqlCommand command = new MySqlCommand(sql, database.getConnection());
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentStatistics = new Statistics()
            {
                DefectName = reader.GetString("DefectName"),
                AmountDefects = reader.GetInt32("AmountDefects")
            };
            _statisticsList.Add(currentStatistics);
        }
        database.closeConnection();
        DefectStatisticDataGrid.ItemsSource = _statisticsList;
    }

    private void BackBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        AdminWindow adminWindow = new AdminWindow();
        this.Hide();
        adminWindow.Show();
    }
}