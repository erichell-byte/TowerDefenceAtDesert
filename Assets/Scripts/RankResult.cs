using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankResult : MonoBehaviour
{
    // C, B, A, S, SS, SSS

    private Text rankText;
    private void Awake()
    {
        rankText = GetComponent<Text>();
    }

    public void SetRank()
    {
        if (gameManager.gm.score > 30000 && gameManager.gm.playerHp > 19)
            rankText.text = "SSS";
        else if (gameManager.gm.score > 25000 && gameManager.gm.playerHp > 15)
            rankText.text = "SS";
        else if(gameManager.gm.score > 20000 && gameManager.gm.playerHp > 12)
            rankText.text = "S";
        else if (gameManager.gm.score > 15000 && gameManager.gm.playerHp > 9)
            rankText.text = "A";
        else if (gameManager.gm.score > 10000 && gameManager.gm.playerHp > 6)
            rankText.text = "B";
        else if (gameManager.gm.score > 5000 && gameManager.gm.playerHp > 3)
            rankText.text = "C";
    }
    
   
}
