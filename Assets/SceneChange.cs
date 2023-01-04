using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public FadeScene fadeScene;
    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }
    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScene.FadeOut();
        yield return new WaitForSeconds(fadeScene.fadeDuration);

        SceneManager.LoadScene(sceneIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
