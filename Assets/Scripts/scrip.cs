using UnityEngine;

public class RecyclingBin : MonoBehaviour
{
    private TrashGameManager gameManager;

    public void SetGameManager(TrashGameManager manager)
    {
        gameManager = manager;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is tagged as "Trash"
        if (other.CompareTag("Trash"))
        {
            // Destroy the trash object
            Destroy(other.gameObject);

            // Notify the game manager that trash was collected
            if (gameManager != null)
            {
                gameManager.TrashCollected();
            }

            Debug.Log("Trash collected!");
        }
    }
}