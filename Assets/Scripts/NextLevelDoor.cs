using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{
    // The name of the next level scene
    public string nextLevelName = "Level2";

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player (you might need to tag your player or use layers)
        if (other.CompareTag("Player"))
        {
            // Load the next level by name
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
