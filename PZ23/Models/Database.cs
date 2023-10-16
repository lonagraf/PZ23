using System.Data;
using MySql.Data.MySqlClient;

namespace PZ23;

public class Database
{
    
    private MySqlConnection _connection = new MySqlConnection(@"server=10.10.1.24;database=pro1_14;port=3306;User Id=user_01;password=user01pro"); //подключение к БД

    public void openConnection() //открывает подключение
    {
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }//если соединение закрыто, то открывает
    }
    public void closeConnection() //закрывает подключение
    {
        if (_connection.State == ConnectionState.Open)
        {
            _connection.Close();
        }//если соединение открыто, то закрывает
    }

    public MySqlConnection getConnection() //возвращает строку подключения
    {
        return _connection;
    }
}