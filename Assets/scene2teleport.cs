using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    public string targetSceneName;
    public int targetSceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load by name
            SceneManager.LoadScene(targetSceneName);

        }
    }

    public void TeleportToScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}