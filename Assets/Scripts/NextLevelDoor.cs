using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{
    // sceneBuildIndex can be used instead of Level2 (safer if level name is changed down the line)
    public int Level2;

    // Level move zoned enter, if collider is a player
    // Move game to another scene

    void OnTriggerEnter(Collider other)
        {
            SceneManager.LoadScene(2);
        }
      
}