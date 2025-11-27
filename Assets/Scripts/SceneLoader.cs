using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadStartScene ()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadMainScene ()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadEndScene ()
    {
        SceneManager.LoadScene("End");
    }

}
