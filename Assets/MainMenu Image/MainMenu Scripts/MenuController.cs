using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;
    public string level1;
    public string level2;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadLevelOneDialog()
    {
        SceneManager.LoadScene(level1);
    }

    public void LoadLevelTwoDialog()
    {
        SceneManager.LoadScene(level2);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
