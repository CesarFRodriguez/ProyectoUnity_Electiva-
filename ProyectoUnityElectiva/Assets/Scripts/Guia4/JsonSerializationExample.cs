using UnityEngine;

public class JsonSerializationExample : MonoBehaviour
{
    void Start()
    {
        // 1) Crear instancia y llenarla
        BasicObject obj = new BasicObject();
        obj.name = "Jugador1";
        obj.score = 420;
        obj.health = 87.5f;

        // 2) Serializar a JSON
        string json = JsonUtility.ToJson(obj);
        Debug.Log("JSON serializado: " + json);

        // 3) Deserializar de JSON a un nuevo objeto
        BasicObject objFromJson = JsonUtility.FromJson<BasicObject>(json);
        Debug.Log($"Deserializado -> name:{objFromJson.name}, score:{objFromJson.score}, health:{objFromJson.health}");

        // 4) Guardar en disco (opcional)
        string path = Application.persistentDataPath + "/playerData.json";
        System.IO.File.WriteAllText(path, json);
        Debug.Log("Guardado en: " + path);

        // 5) Leer desde disco y deserializar (ejemplo de lectura)
        if (System.IO.File.Exists(path))
        {
            string readJson = System.IO.File.ReadAllText(path);
            BasicObject loaded = JsonUtility.FromJson<BasicObject>(readJson);
            Debug.Log("Cargado desde disco -> " + loaded.name);
        }
    }
}
