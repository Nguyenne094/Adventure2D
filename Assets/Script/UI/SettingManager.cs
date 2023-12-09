using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void OnResume(){
        Time.timeScale = 1;
    }

    public void ReturnHome(){
        StartCoroutine(LoadHomeScene());
    }

    private IEnumerator LoadHomeScene()
    {
        transition.SetTrigger(AnimationString.sceneTransition);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("GameStart");
    }
}
