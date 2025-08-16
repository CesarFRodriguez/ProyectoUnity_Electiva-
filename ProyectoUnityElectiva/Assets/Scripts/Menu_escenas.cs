using UnityEngine;
using UnityEngine.UI;

public class Menu_escenas : MonoBehaviour
{
    public int sceneIndex; // asigna en el inspector

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.Instance.Load(sceneIndex);
        });
    }
}
