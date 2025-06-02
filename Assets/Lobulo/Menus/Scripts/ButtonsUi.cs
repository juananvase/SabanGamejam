using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsUI : MonoBehaviour
{
    [SerializeField] private CharacterDataSO _characterData; // <-- NUEVO

    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryLevel()
    {
        _characterData.CurrentHealth = _characterData.MaxHealth;

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
