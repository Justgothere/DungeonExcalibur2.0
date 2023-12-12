using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{
    // sceneBuildIndex can be used instead of Level2 (safer if level name is changed down the line)
    public int Level2;

    // Level move zoned enter, if collider is a player
    // Move game to another scene

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Entered");

        if(other.tag == "Player")
        {
            print("Switching Scene to " + Level2);
            SceneManager.LoadScene(Level2, LoadSceneMode.Single);
        }
    }
}