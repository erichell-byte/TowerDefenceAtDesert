using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{

    private TowerManager _towerManager;
    [SerializeField] private TowerButton button1;
    [SerializeField] private TowerButton button2;
    [SerializeField] private TowerButton button3;

    private void Start()
    {
        _towerManager = GetComponent<TowerManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && gameManager.gm.playerEnergy >= button1.TowerObject.GetComponent<towerScript>().energy)
        {
            _towerManager.SelectedTower(button1);
            button1.BuyTower();
        }
        else if (Input.GetKeyDown(KeyCode.W) && gameManager.gm.playerEnergy >= button2.TowerObject.GetComponent<towerScript>().energy)
        {
            _towerManager.SelectedTower(button2);
            button2.BuyTower();
        }
        else if (Input.GetKeyDown(KeyCode.E) && gameManager.gm.playerEnergy >= button3.TowerObject.GetComponent<towerScript>().energy)
        {
            _towerManager.SelectedTower(button3);
            button3.BuyTower();
        }
    }
}
