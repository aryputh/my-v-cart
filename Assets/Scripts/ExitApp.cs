using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApp : MonoBehaviour
{
    // ExitTheApp quits the application
    public void ExitTheApp(float delay)
    {
        StartCoroutine(ExitTheAppDelay(delay));
    }

    private IEnumerator ExitTheAppDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();

        print("Exited the app!");
    }
}
