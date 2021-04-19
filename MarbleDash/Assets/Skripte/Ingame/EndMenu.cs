using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public static bool GameIsFinished = false;

    public GameObject EndMenuUI;
    public GameObject RedWin;
    public GameObject BlueWin;

    // Update is called once per frame
    void Update()
    {
        if (DestroyScript.scoreBlue == 2)
        {
            Debug.Log("Score BLUE 3" );
            EndMenuUI.SetActive(true);
            RedWin.SetActive(false);
            BlueWin.SetActive(true);
            Time.timeScale = 0f;
            GameIsFinished = true;

        }
        else if (DestroyScript.scoreRed == 2)
        {
            Debug.Log("Score RED 3");
            EndMenuUI.SetActive(true);
            RedWin.SetActive(true);
            BlueWin.SetActive(false);
            Time.timeScale = 0f;
            GameIsFinished = true;
        }
        
    }

    public void Restart()
    {
        DestroyScript.scoreBlue = 0;
        DestroyScript.scoreRed = 0;

        EndMenuUI.SetActive(false);
        GameIsFinished = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
       
    }

    public void Exit()
    {
        Debug.Log("QUIT");
        Application.Quit();    
    }
}
