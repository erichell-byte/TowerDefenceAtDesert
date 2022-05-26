using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            gameManager.gm.pause(true);
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.gm.pause(false);
            pauseMenu.SetActive(false);
        }
    }


    public void ExitApp()
    {
        Application.Quit();
        Debug.Log("Quit application");
    }
}
