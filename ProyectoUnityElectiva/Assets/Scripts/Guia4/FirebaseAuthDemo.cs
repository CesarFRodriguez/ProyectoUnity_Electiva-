using UnityEngine;
using Firebase.Auth;
using System.Threading.Tasks;
using Firebase.Extensions;

public class FirebaseAuthDemo : MonoBehaviour
{
    FirebaseAuth auth;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void Register(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Registro falló: " + task.Exception);
                return;
            }
            FirebaseUser newUser = task.Result;
            Debug.Log("Usuario creado: " + newUser.UserId);
        });
    }

    public void Login(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                Debug.Log("Login OK: " + auth.CurrentUser.Email);
                // Aquí puedes cargar la escena principal del juego
            } else {
                Debug.LogError("Login error: " + task.Exception);
            }
        });
    }
}
