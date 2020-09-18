using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMovement : MonoBehaviour
{

    Vector3 up = Vector3.zero,
    right = new Vector3(0, 90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, 270, 0),
    currentDirection = Vector3.zero;

    Vector3 nextPos, destination, direction;

    bool canMove = false;

    [SerializeField] float moveSpeed = 1f;

    float raylenght = 1f;

    [SerializeField] Animator cameraAnimations;

    void Start()
    {
        currentDirection = up;
        nextPos = Vector3.forward;
        destination = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotatePositive();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateLNegative();
        }
        MoveForward();
    }

    void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime* moveSpeed);

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentDirection == up)
            {
                nextPos = Vector3.forward;
                canMove = true;
            }
            else if (currentDirection == right)
            {
                nextPos = Vector3.right;
                canMove = true;
            }
            else if (currentDirection == left)
            {
                nextPos = Vector3.left;
                canMove = true;
            }
            else if (currentDirection == down)
            {
                nextPos = Vector3.back;
                canMove = true;
            }
        }

        if(Vector3.Distance(destination, transform.position) <= Mathf.Epsilon)
        {
            transform.localEulerAngles = currentDirection;
            if(canMove)
            {
                if (Valid())
                {
                    destination = transform.position + nextPos;
                    direction = nextPos;
                    canMove = false;
                }
            }
        }
    }

    void RotatePositive()
    {
        if (Vector3.Distance(destination, transform.position) <= Mathf.Epsilon)
        {
            transform.localEulerAngles += new Vector3(0, 90, 0);
            currentDirection = transform.localEulerAngles;
            canMove = false;
        }
    }
    void RotateLNegative()
    {
        if (Vector3.Distance(destination, transform.position) <= Mathf.Epsilon)
        {
            transform.localEulerAngles += new Vector3(0, -90, 0);
            currentDirection = transform.localEulerAngles;
            canMove = false;
        }
    }

    bool Valid()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if(Physics.Raycast(ray, out hit, raylenght))
        {
            if (hit.collider.tag == "border")
            {
                cameraAnimations.SetTrigger("shakeCamera");
                canMove = false;
                return false;
            }
        }
        return true;
    }
}
