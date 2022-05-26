using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesText : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Lives : " + gameManager.gm.playerHp;
        GlobalEventManager.OnLiveIsDown += LostLives;
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnLiveIsDown -= LostLives;
    }

    private void LostLives()
    {
        GetComponent<Text>().text = "Lives : " + gameManager.gm.playerHp;
    }
}
