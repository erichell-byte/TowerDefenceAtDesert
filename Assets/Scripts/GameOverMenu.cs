using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject gameLosePanel;
    
    [SerializeField] private GameObject gameWinPanel;
    
    [SerializeField] private RankResult rankResult;
    
    
    void Start()
    {
        GlobalEventManager.GameWasEnd+= ActivateGameOverMenu;
    }

    private void OnDestroy()
    {
        GlobalEventManager.GameWasEnd -= ActivateGameOverMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartThisLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ActivateGameOverMenu(bool isVictory)
    {
        if (isVictory)
        {
            gameWinPanel.SetActive(true);
            rankResult.SetRank();
        }
        else
        {
            gameLosePanel.SetActive(true);
        }
    }
    
}

