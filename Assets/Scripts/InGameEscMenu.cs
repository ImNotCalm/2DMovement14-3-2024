using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameEscMenu : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Listening...");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Clicked");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
