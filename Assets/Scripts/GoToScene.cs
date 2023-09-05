using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    [SerializeField] private float loadDelay;

    // Loads the specified scene
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneDelay(sceneName));
    }

    private IEnumerator LoadSceneDelay(string sceneName)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneName);
    }
}
