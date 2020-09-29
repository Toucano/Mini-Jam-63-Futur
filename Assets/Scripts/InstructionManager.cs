using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] int instructionIndex = 1;
    Toggle instructionsToggles;

    public static List<string> instructionsList = new List<string>();

    [SerializeField] List<string> instructionsListDebug = new List<string>(); //Debuggage


    private void Start()
    {
        instructionIndex = 1;
    }

    private void Update()
    {
        instructionsListDebug = instructionsList;
        //string result = "List contents: ";
        //foreach (var item in instructionsList)
        //{
        //    result += item.ToString() + ", ";
        //}
        //Debug.Log(result);
    }

    public void OnClickToggle(bool toggleValue)
    {
        var clickedToggle = EventSystem.current.currentSelectedGameObject;
        var steps = clickedToggle.GetComponentInParent<ToggleData>().steps;
        var clickedToggleData = clickedToggle.GetComponentInParent<ToggleData>();
        instructionIndex = instructionsList.Count;
        if (toggleValue == true)
        {
            clickedToggleData.indexOfInstruction = instructionIndex;
            for (int i = 0; i < steps; i++)
            {
                instructionsList.Add(clickedToggleData.movementValue.ToString());
            }
            clickedToggle.GetComponentInChildren<TextMeshProUGUI>().text = "Index of instruction : " + instructionsList.Count;
        }
        if (toggleValue == false)
        {
            for (int i = clickedToggleData.indexOfInstruction; i < clickedToggleData.indexOfInstruction + steps; i++)
            {
                //Debug.Log("yay");
                instructionsList[i] = "";
            }
            //instructionsList.RemoveRange(clickedToggleData.indexOfInstruction , steps);
            //clickedToggleData.indexOfInstruction = 0;
            clickedToggleData.TextToggleToInstructionName();
        }
        instructionIndex = instructionsList.Count;
    }
}
