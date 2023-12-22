using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserSQL : MonoBehaviour
{
    //数据库连接
    protected SqliteConnection connection;
    //数据库命令
    protected SqliteCommand command;

    private void Awake()
    {
        Open();
        CreateTable();
    }
    public void Open()
    {

        string path = Application.streamingAssetsPath + "/MyGame.db";
        connection = new SqliteConnection("Data Source=" + path + ";Version=3");


        connection.Open();
    }
    public bool IsExit(int username)
    {

        command = new SqliteCommand($"SELECT * FROM USER WHERE USERNAME = {username}",
    connection);

        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            return true;
        }
        return false;
    }

    public bool IsCanLogin(int username,string password) 
    {
        command = new SqliteCommand($"SELECT * FROM USER WHERE USERNAME = {username} and password = '{password}'",
 connection);
        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            return true;
        }
        return false;
    }
    public void CreateTable()
    {
        //创建表命令IF NOT EXISTS表示该表不存在时才会创建
        command = new SqliteCommand("CREATE TABLE IF NOT EXISTS USER(USERNAME INTEGER PRIMARY KEY AUTOINCREMENT, PASSWORD)", connection);
        //执行命令
        command.ExecuteNonQuery();
        //结束命令
        command.Dispose();
    }
    public void InsertUser(int username, string password)
    {
        command = new SqliteCommand($"INSERT INTO USER VALUES({username}, '{password}')", connection);

        command.ExecuteNonQuery();

        command.Dispose();
    }
    public void Close()
    {
        connection.Close();
    }
    private void OnDestroy()
    {
        Close();
    }

}
