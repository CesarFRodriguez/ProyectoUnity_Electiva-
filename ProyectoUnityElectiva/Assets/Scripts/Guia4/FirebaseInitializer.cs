using System.Threading.Tasks;
using UnityEngine;
using Firebase;
using Firebase.Extensions;

public class FirebaseInitializer : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var status = task.Result;
            if (status == DependencyStatus.Available)
            {
                Debug.Log("Firebase dependencies OK.");
                // Aquí puedes inicializar otras cosas o cargar la escena siguiente
            }
            else
            {
                Debug.LogError($"No se pudieron resolver dependencias de Firebase: {status}");
            }
        });
    }
}
