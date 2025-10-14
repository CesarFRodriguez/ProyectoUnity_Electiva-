using UnityEngine;
using Firebase.Auth;
using Firebase.Extensions;
using TMPro;

public class FirebaseAuthDemo : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    private FirebaseAuth auth;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void Register()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password)
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    Debug.LogError("❌ Registro falló: " + task.Exception);
                    return;
                }

                // ✅ Nueva forma: acceder al resultado correctamente
                FirebaseUser newUser = task.Result.User;
                Debug.Log("✅ Usuario creado: " + newUser.Email);
            });
    }

    public void Login()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        auth.SignInWithEmailAndPasswordAsync(email, password)
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    Debug.LogError("❌ Error de login: " + task.Exception);
                    return;
                }

                // ✅ Nueva forma: acceder al resultado correctamente
                FirebaseUser user = task.Result.User;
                Debug.Log("✅ Sesión iniciada: " + user.Email);
            });
    }
}
