using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private string doorID;

    private void Start()
    {
        string lastUsedDoor = PlayerPrefs.GetString("LastDoorUsed", "");

        if (doorID == lastUsedDoor)
        {
            GameObject player = GameManager.Instance.Player;
            if (player != null)
            {
                CharacterController cc = player.GetComponent<CharacterController>();
                if (cc != null)
                {
                    cc.enabled = false; // Desactiva para mover sin errores
                    player.transform.position = transform.position;
                    player.transform.rotation = transform.rotation;
                    cc.enabled = true;
                }
                else
                {
                    player.transform.position = transform.position;
                    player.transform.rotation = transform.rotation;
                }
            }
        }
    }
}
