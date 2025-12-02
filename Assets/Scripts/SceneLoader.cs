using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStartScene ()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadMainScene ()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2 ()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
}
