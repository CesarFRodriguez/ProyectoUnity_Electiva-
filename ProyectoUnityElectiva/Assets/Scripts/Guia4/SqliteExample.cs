using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SqliteExample : MonoBehaviour
{
    private string dbFileName = "My_DB.db";
    private string connectionString;

    void Start()
    {
        string dbPath = Path.Combine(Application.persistentDataPath, dbFileName);

        // Si no existe, crear DB vacía
        if (!File.Exists(dbPath))
        {
            Debug.Log("Creando DB en: " + dbPath);
            SqliteConnection.CreateFile(dbPath);
        }

        connectionString = "URI=file:" + dbPath;
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            using (var cmd = connection.CreateCommand())
            {
                // Crear tabla si no existe
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS players (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, score INTEGER);";
                cmd.ExecuteNonQuery();

                // Insertar ejemplo
                cmd.CommandText = "INSERT INTO players (name, score) VALUES ('Cesar', 900);";
                cmd.ExecuteNonQuery();

                // Leer
                cmd.CommandText = "SELECT id, name, score FROM players;";
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log($"Player id:{reader["id"]} name:{reader["name"]} score:{reader["score"]}");
                    }
                }
            }
            connection.Close();
        }
    }
}
