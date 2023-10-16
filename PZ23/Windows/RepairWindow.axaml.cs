using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace PZ23.Windows;

public partial class RepairWindow : Window
{
    private Database database = new Database();
    private List<Repair> _repairs;

    public string fullTable =
        "select RepairID, DateStart, DateEnd, Cost, MaterialsName, DefectCause from pro1_4.Repair " +
        "join pro1_4.Materials m on m.MaterialsID = Repair.Materials;";

    public RepairWindow()
    {
        Width = 820;
        Height = 400;
        InitializeComponent();
        ShowTable(fullTable);
    }

    public void ShowTable(string sql)
    {
        try
        {
            _repairs = new List<Repair>();
            database.openConnection();
            MySqlCommand command = new MySqlCommand(sql, database.getConnection());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read() && reader.HasRows)
            {
                var currentRepair = new Repair()
                {
                    RepairID = reader.GetInt32("RepairID"),
                    DateStart = reader.GetString("DateStart"),
                    DateEnd = reader.GetString("DateEnd"),
                    Cost = reader.GetDouble("Cost"),
                    Materials = reader.GetString("MaterialsName"),
                    DefectCause = reader.GetString("DefectCause")
                };
                _repairs.Add(currentRepair);
            }
            database.closeConnection();
            RepairDataGrid.ItemsSource = _repairs;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}