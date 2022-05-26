using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeMovement : MonoBehaviour
{
    // variables
    [SerializeField] float tiltSpeed = 2.0f;
    [SerializeField] int maxAngle = 15;
    private float tiltInputY = 0.0f;
    private float tiltInputX = 0.0f;


    void Update()
    {

        if (Keyboard.current.wKey.isPressed)
        {
            tiltInputX -= 1;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            tiltInputX += 1;
        }
        else
        {
            if (tiltInputX > 0)
            {
                tiltInputX -= 1;
            }
            else if (tiltInputX < 0)
            {
                tiltInputX += 1;
            }
        }

        if (Keyboard.current.dKey.isPressed)
        {
            tiltInputY -= 1;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            tiltInputY += 1;
        }
        else
        {
            if (tiltInputY > 0)
            {
                tiltInputY -= 1;
            }
            else if (tiltInputY < 0)
            {
                tiltInputY += 1;
            }
        }


        tiltInputX = Mathf.Clamp(tiltInputX, -maxAngle, maxAngle);
        tiltInputY = Mathf.Clamp(tiltInputY, -maxAngle, maxAngle);

        var targetRotation = Quaternion.Euler(Vector3.forward * tiltInputY) * Quaternion.Euler(Vector3.left * tiltInputX);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);
    }

    void RotateLevel()
    {

    }
}
