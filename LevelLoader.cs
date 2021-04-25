using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;

    public GameObject CanvasAnimation;

    public float TransitionTime = 0.5f;

    bool Loading = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(Loading == false)
        {
            if (collision.tag == "Player")
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
                Loading = true;
            }
            else if (collision.tag == "Enemy")
            {
                StartCoroutine(LoadRetryPage("RetryPage"));
                Loading = true;
            }
        }
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        CanvasAnimation.gameObject.SetActive(true);

        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        Loading = false;

        SceneManager.LoadScene(LevelIndex);
    }

    IEnumerator LoadRetryPage(string SceneName)
    {
        CanvasAnimation.gameObject.SetActive(true);

        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        Loading = false;

        SceneManager.LoadScene(SceneName);
    }
}
