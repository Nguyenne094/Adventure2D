using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator transition;
    [SerializeField] private float transitionTime = 1f;

    public void OnStart(){
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        transition.SetTrigger(AnimationString.sceneTransition);

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnExit() {
        Application.Quit();
    }
}
