using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalEventManager : MonoBehaviour
{
    public static Action OnLiveIsDown;

    public static Action EnergyWasChange;

    public static Action<bool> GameWasEnd;

    public static Action<towerScript> SetRadInterface;


    public static void SendOnLiveIsDown()
    {
        if (OnLiveIsDown != null) OnLiveIsDown.Invoke();
    }

    public static void SendEnergyWasChange()
    {
        if (EnergyWasChange != null) EnergyWasChange.Invoke();
    }

    public static void SendGameWasEnd(bool isVictory)
    {
        if (GameWasEnd != null) GameWasEnd.Invoke(isVictory);
    }

    public static void SendSetRadInterface(towerScript targetTower)
    {
        if (SetRadInterface != null) SetRadInterface.Invoke(targetTower);
    }
}
