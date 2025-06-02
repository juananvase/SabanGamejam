using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsUI : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadNextLevel() 
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextIndex);
    } 

    public void RetryLevel()
    {
        int lastSceneIndex = PlayerPrefs.GetInt("LastSceneBeforeDeath", 0);
        SceneManager.LoadScene(lastSceneIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
