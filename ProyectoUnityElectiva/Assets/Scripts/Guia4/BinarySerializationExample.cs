using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySerializationExample : MonoBehaviour
{
    void Start()
    {
        MyData data = new MyData() { level = 3, health = 78.4f, playerName = "Cesar" };

        string path = Application.persistentDataPath + "/playerData.dat";

        // Serializar
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            bf.Serialize(fs, data);
        }
        Debug.Log("Guardado binario en: " + path);

        // Deserializar
        if (File.Exists(path))
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                MyData loaded = (MyData)bf.Deserialize(fs);
                Debug.Log($"Deserializado binario -> {loaded.playerName} nivel:{loaded.level} health:{loaded.health}");
            }
        }
    }
}
