using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenerizer : MonoBehaviour
{
    public void loadlevel(string level)
    {
        SceneManager.LoadScene(level);

    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
