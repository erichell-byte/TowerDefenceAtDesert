using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRadInterface : MonoBehaviour
{
    [SerializeField] private GameObject buttonUpgrade;
    [SerializeField] private GameObject buttonDowngrade;
    [SerializeField] private GameObject buttonSell;

    private towerScript towerScriptTmp;
    private bool isHaveMoney = false;
    void Awake()
    {
        GlobalEventManager.SetRadInterface += SetUpRadInterface;
    }

    private void OnDestroy()
    {
        GlobalEventManager.SetRadInterface -= SetUpRadInterface;
    }

    public void SetUpRadInterface(towerScript towerScript)
    {
        towerScriptTmp = towerScript;
        if (towerScript.upgrade != null)
        {
            buttonUpgrade.SetActive(true);
            buttonUpgrade.GetComponentInChildren<Text>().text = "-" + towerScript.upgrade.GetComponent<towerScript>().energy;
            if (gameManager.gm.playerEnergy < towerScript.upgrade.gameObject.GetComponent<towerScript>().energy)
            {
                NotMoneyColor();
                isHaveMoney = false;
            }
            else
            {
                HaveMoneyColor();
                isHaveMoney = true;
            }
        }
        else
            buttonUpgrade.SetActive(false);

        if (towerScript.downgrade != null)
        {
            buttonDowngrade.SetActive(true);
            buttonDowngrade.GetComponentInChildren<Text>().text = "+" + towerScript.energy / 2;
            buttonSell.SetActive(false);
        }
        else
        {
            buttonDowngrade.SetActive(false);
            buttonSell.SetActive(true);
            buttonSell.GetComponentInChildren<Text>().text = "+" + towerScript.energy / 2;
        }
    }

    public void UpgradeTower()
    {
        if (isHaveMoney)
        {
            GameObject newTower = Instantiate(towerScriptTmp.upgrade);
            newTower.transform.position = towerScriptTmp.gameObject.transform.position;
            Destroy(towerScriptTmp.gameObject);
            towerScriptTmp = null;
            gameManager.gm.playerEnergy -= newTower.GetComponent<towerScript>().energy;
            GlobalEventManager.SendEnergyWasChange();
        }

    }

    public void DownGradeTower()
    {
        GameObject newTower = Instantiate(towerScriptTmp.downgrade);
        newTower.transform.position = towerScriptTmp.gameObject.transform.position;
        Destroy(towerScriptTmp.gameObject);
        gameManager.gm.playerEnergy += towerScriptTmp.energy / 2;
        GlobalEventManager.SendEnergyWasChange();
    }

    public void NotMoneyColor()
    {
        buttonUpgrade.GetComponentInChildren<Image>().color = new Color32(243,128,128,154);
    }

    public void HaveMoneyColor()
    {
        buttonUpgrade.GetComponentInChildren<Image>().color = new Color32(169,231,117,154);
    }

    public void SellTower()
    {
        Destroy(towerScriptTmp.gameObject);
        gameManager.gm.playerEnergy += towerScriptTmp.energy / 2;
        GlobalEventManager.SendEnergyWasChange();
        Transform backTowerPosition = towerScriptTmp.gameObject.transform;
        RaycastHit2D hit = Physics2D.Raycast(backTowerPosition.position, Vector2.zero);
        if (hit)
            hit.collider.tag = "empty";
    }
}
