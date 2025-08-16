using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // referencia global

    private void Awake()
    {
        // Asegura que solo exista un GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // no destruir entre escenas
        }
        else
        {
            Destroy(gameObject); // si ya hay uno, destruye el duplicado
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0); // vuelve al menú
    }

    public void Load(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
