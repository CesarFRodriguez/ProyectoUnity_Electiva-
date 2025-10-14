using UnityEngine;
using Firebase.Database;
using System.Collections.Generic;
using System;

public class RealtimeDbDemo : MonoBehaviour
{
    DatabaseReference reference;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        WriteNewPlayer("player_1", "Cesar", 123);
        ReadPlayers();
    }

    void WriteNewPlayer(string playerId, string name, int score)
    {
        var player = new Dictionary<string, object>{
            {"name", name},
            {"score", score}
        };
        reference.Child("players").Child(playerId).SetValueAsync(player).ContinueWith(task =>
        {
            if (task.IsCompleted) Debug.Log("Escritura completada.");
            else Debug.LogError("Error al escribir: " + task.Exception);
        });
    }

    void ReadPlayers()
    {
        reference.Child("players").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (var child in snapshot.Children)
                {
                    Debug.Log($"Player key:{child.Key} -> {child.Child("name").Value} score:{child.Child("score").Value}");
                }
            }
            else
            {
                Debug.LogError("Error lectura: " + task.Exception);
            }
        });
    }
}
