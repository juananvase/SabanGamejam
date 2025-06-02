using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private string entryDoorID; // <-- ID de esta puerta

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Guarda el ID de esta puerta como la que usaste para entrar a la siguiente escena
            PlayerPrefs.SetString("LastDoorUsed", entryDoorID);
            PlayerPrefs.Save();

            SceneManager.LoadScene(nextSceneName);
        }
    }
}
