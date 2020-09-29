using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoverScript : MonoBehaviour
{
    Vector3 up = Vector3.zero,
    right = new Vector3(0, 90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, 270, 0),
    currentDirection = Vector3.zero,
    currentPosition = Vector3.zero;
    Sequence movementSequence;

    [SerializeField] float movingDelay = 1f;
    [SerializeField] float turninDelay = 1f;
    [SerializeField] float delayBetweenMovements = 1f;
    [SerializeField] bool dontAnimateMovement = false;
    [SerializeField] RotateMode rotateAnimation = RotateMode.Fast;
    
    float raylenght = 1f;

    [SerializeField] Animator cameraAnimations;

    private void Start()
    {

        currentDirection = up;
        currentPosition = new Vector3(0, .8f, 0);
    }

    private void Update()
    {
        //string result = "List contents: ";
        //foreach (var item in InstructionManager.instructionsList)
        //{
        //    result += item.ToString() + ", ";
        //}
        //Debug.Log(result);
    }

    IEnumerator PreparingInstructions(List<string> instructions)
    {
        foreach (string instruction in instructions)
        {
            currentDirection = transform.localEulerAngles;
            currentPosition = transform.position;
            //Debug.Log(currentDirection);
            if (instruction == "forward")
            {
                if (IsMovingForwardValid())
                {
                    if (currentDirection == up)
                    {
                        movementSequence.Append(transform.DOMoveZ(currentPosition.z + 1, movingDelay, dontAnimateMovement));
                    }
                    else if (currentDirection == right)
                    {
                        movementSequence.Append(transform.DOMoveX(currentPosition.x + 1, movingDelay, dontAnimateMovement));
                        //Debug.Log("MoveRight");
                    }
                    else if (currentDirection == left)
                    {
                        movementSequence.Append(transform.DOMoveX(currentPosition.x - 1, movingDelay, dontAnimateMovement));
                        //Debug.Log("MoveLeft");
                    }
                    else if (currentDirection == down)
                    {
                        movementSequence.Append(transform.DOMoveZ(currentPosition.z - 1, movingDelay, dontAnimateMovement));
                    }
                }
            }
            if (instruction == "turnRight")
            {
                movementSequence.Append(transform.DORotate(currentDirection + new Vector3(0, 90, 0), turninDelay, rotateAnimation));
            }
            if (instruction == "turnLeft")
            {
                movementSequence.Append(transform.DORotate(currentDirection + new Vector3(0, -90, 0), turninDelay, rotateAnimation));
            }
            yield return new WaitForSeconds(delayBetweenMovements);
        }
    }

    public void RoverStartProgram()
    {
        movementSequence = DOTween.Sequence();
        StartCoroutine(PreparingInstructions(InstructionManager.instructionsList));
    }

    bool IsMovingForwardValid()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out hit, raylenght))
        {
            if (hit.collider.tag == "border")
            {
                CinemachineShake.Instance.ShakeCamera(10f, .25f);
                return false;
            }
        }
        return true;

    }
}