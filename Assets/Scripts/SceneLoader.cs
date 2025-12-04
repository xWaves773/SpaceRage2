using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStartScene ()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadStage1 ()
    {
        SceneManager.LoadScene("Stage 1");
    }

    public void LoadStage2 ()
    {
        SceneManager.LoadScene("Stage 2");
    }

    public void LoadStage3()
    {
        SceneManager.LoadScene("Stage 3");
    }
}
