using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashGameManager : MonoBehaviour
{
    private int totalTrashCount;
    private int collectedTrashCount = 0;
    public int sceneToLoad = 2; // The scene index to load (0-based, so 2 = third scene)

    void Start()
    {
        // Find all trash objects in the scene
        GameObject[] trashObjects = GameObject.FindGameObjectsWithTag("Trash");
        totalTrashCount = trashObjects.Length;

        Debug.Log("Total trash objects to collect: " + totalTrashCount);

        // Make sure our RecyclingBin can call our TrashCollected method
        RecyclingBin[] bins = FindObjectsOfType<RecyclingBin>();
        foreach (RecyclingBin bin in bins)
        {
            bin.SetGameManager(this);
        }
    }

    public void TrashCollected()
    {
        collectedTrashCount++;
        Debug.Log("Trash collected: " + collectedTrashCount + "/" + totalTrashCount);

        // Check if all trash is collected
        if (collectedTrashCount >= totalTrashCount)
        {
            Debug.Log("All trash collected! Loading scene: " + sceneToLoad);
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        // Wait a short delay before loading the next scene
        yield return new WaitForSeconds(1.5f);

        // Load the next scene
        SceneManager.LoadScene(sceneToLoad);
    }
}