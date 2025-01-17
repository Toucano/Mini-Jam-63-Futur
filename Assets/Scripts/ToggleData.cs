﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleData : MonoBehaviour
{
    public enum movement // your custom enumeration
    {
        forward,
        turnRight,
        turnLeft
    };
    public movement movementValue;
    [Range(1,25)] public int steps;
    [SerializeField] public int indexOfInstruction; //Debbugage

    void Start()
    {
        TextToggleToInstructionName();
    }

    public void TextToggleToInstructionName()
    {
        if (movementValue == movement.forward)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = "Go Forward by " + steps.ToString() + " blocks";
        }
        if (movementValue == movement.turnRight)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = "Turn Right " + steps.ToString() + " times";
        }
        if (movementValue == movement.turnLeft)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = "Turn Left " + steps.ToString() + " times";
        }
    }
}
