using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            GameManager.Instance.BackToMenu(); // llama al GameManager persistente
        });
    }
}
