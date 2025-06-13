using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private float timeDelay;

    public void MoveToScene(string sceneName)
    {
        StartCoroutine(delayTransition(sceneName, timeDelay));
    }

    IEnumerator delayTransition(string sceneName, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(sceneName);
    }
}
