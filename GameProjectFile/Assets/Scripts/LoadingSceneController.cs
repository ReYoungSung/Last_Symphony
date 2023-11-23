using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    // static string nextScene;

    [SerializeField]
    Image progressBar;

    public static void LoadScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("SecondScene");
        op.allowSceneActivation = false;

        float timer = 0f;
        float duration = 4.8f; // Set the duration of the Lerp function to 5 seconds
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.1f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                float progress = Mathf.Lerp(0.01f, 1f, timer / duration); // Divide the timer by duration to control the speed of the Lerp function
                progressBar.fillAmount = progress;
                if (progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
