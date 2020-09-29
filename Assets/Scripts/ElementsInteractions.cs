using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ElementsInteractions : MonoBehaviour
{
    public enum intercationTypes // your custom enumeration
    {
        electrified = 0,
        poisened = 0,
        winning = 1,
        gatherInformation,
        chargeBatteries,
        stupidInteractions
    };

    public intercationTypes intercationType;


    //[DrawIf("intercationType", intercationTypes.winning, ComparisonType.Equals)]
    [SerializeField] GameObject winnerWindow;
    //[DrawIf("intercationType", intercationTypes.poisened, ComparisonType.SmallerOrEqual)]
    [SerializeField] GameObject looserWindow;

    //[DrawIf("intercationType", intercationTypes.winning, ComparisonType.SmallerOrEqual)]
    [SerializeField] Animator windowsAnimations;


    private void OnTriggerEnter(Collider collision)
    {
        //Debug%.Log(collision);
        if (intercationType == intercationTypes.winning)
        {
            winnerWindow.SetActive(true);
            windowsAnimations.SetTrigger("PopUp");
        }
        if (intercationType == 0)
        {
            looserWindow.SetActive(true);
            windowsAnimations.SetTrigger("PopUp");
        }
    }
}
