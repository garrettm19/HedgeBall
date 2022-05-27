using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeControl : MonoBehaviour
{

    [SerializeField] float tiltSpeed = 2.0f;
    [SerializeField] float maxAngle = 10f;

    Vector3 rotateInput; 
    Transform maze;

    void Awake()
    {
        maze = GetComponent<Transform>();
    }

    void Update()
    {
        TiltMaze();
    }

    void OnRotate(InputValue value) 
    {
        rotateInput = value.Get<Vector3>();
    }

    void TiltMaze()
    {
        var targetRotation = Quaternion.Euler(maxAngle * rotateInput.x * Vector3.back) * Quaternion.Euler(maxAngle * rotateInput.z * Vector3.right);
        maze.rotation = Quaternion.Lerp(maze.rotation, targetRotation, tiltSpeed * Time.deltaTime);
    }
}
