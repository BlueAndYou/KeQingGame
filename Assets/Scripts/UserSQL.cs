using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserSQL : MonoBehaviour
{
    //���ݿ�����
    protected SqliteConnection connection;
    //���ݿ�����
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
        //����������IF NOT EXISTS��ʾ�ñ�����ʱ�Żᴴ��
        command = new SqliteCommand("CREATE TABLE IF NOT EXISTS USER(USERNAME INTEGER PRIMARY KEY AUTOINCREMENT, PASSWORD)", connection);
        //ִ������
        command.ExecuteNonQuery();
        //��������
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
