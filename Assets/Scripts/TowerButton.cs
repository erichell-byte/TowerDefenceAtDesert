using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField] 
    private GameObject towerObject;

    private towerScript towerScript;
    
    [SerializeField] private Sprite dragSprite;

    private Button button;

    private void Start()
    {
        Text text = GetComponentInChildren<Text>();
        button = GetComponent<Button>();
        towerScript = towerObject.GetComponent<towerScript>();
        text.text = "damage : " + towerScript.damage + "\n" + "cost : " + towerScript.energy + "\n"
               + "range : " + towerScript.range + "\n" + "fire rate : " + towerScript.fireRate;
        
    }

    private void Update()
    {
        
        if (gameManager.gm.playerEnergy >= towerScript.energy)
        {
            GetComponent<Image>().color = new Color32(169,231,117,154);
            button.interactable = true;
            
        }
        else
        {
            GetComponent<Image>().color = new Color32(243,128,128,154);
            button.interactable = false;
        }
        // Debug.Log(gm.playerEnergy);
    }

    public GameObject TowerObject
    {
        get
        {
            return towerObject;
        }
    }
    
    public Sprite DragSprite
    {
        get
        {
            return dragSprite;
        }
    }

    
    public void BuyTower()
    {
        gameManager.gm.playerEnergy -= towerScript.energy;
        GlobalEventManager.SendEnergyWasChange();
    }

}



