using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTimeButton : MonoBehaviour
{
    private Button button;

    private float timeDelay = 15f;
    private float tmpTime = 0;
    private void Start()
    {
        button = GetComponent<Button>();
    }


    private void Update()
    {
        if (Time.time > timeDelay + tmpTime)
        {
            button.interactable = true;
            button.gameObject.GetComponent<Image>().color = new Color32(255,255,255,154);
        }
        else
        {
            button.interactable = false;
            button.gameObject.GetComponent<Image>().color = new Color32(51,30,30,255);
        }
    }


    public void UpdateTime()
    {
        tmpTime = Time.time;
    }
}
