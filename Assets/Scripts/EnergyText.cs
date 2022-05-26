using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergyText : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Energy : " + gameManager.gm.playerEnergy;
        GlobalEventManager.EnergyWasChange += TowerIsBuy;
    }
    private void OnDestroy()
    {
        GlobalEventManager.EnergyWasChange -= TowerIsBuy;
    }

    public void TowerIsBuy()
    {
        if (GetComponent<Text>().text != null)
            GetComponent<Text>().text = "Energy : " + gameManager.gm.playerEnergy;
        
    }
    void Update()
    {
        
    }
}
