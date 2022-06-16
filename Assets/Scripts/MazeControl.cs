using UnityEngine;
using UnityEngine.InputSystem;

public class MazeControl : MonoBehaviour
{

    [SerializeField] private float tiltSpeed = 2.0f;
    [SerializeField] private float maxAngle = 10f;

    private Vector3 rotateInput;
    private Transform maze;

    private void Awake()
    {
        maze = GetComponent<Transform>();
    }

    private void Update()
    {
        TiltMaze();
    }

    private void OnRotate(InputValue value) 
    {
        rotateInput = value.Get<Vector3>();
    }

    void TiltMaze()
    {
        var targetRotation = Quaternion.Euler(maxAngle * rotateInput.x * Vector3.back)
                                    * Quaternion.Euler(maxAngle * rotateInput.z * Vector3.right);
        maze.rotation = Quaternion.Lerp(maze.rotation, targetRotation, tiltSpeed * Time.deltaTime);
    }

    /*
    public void RotateLeft()
    {
        maxRotation -= 90f;
        Debug.Log(Quaternion.Euler(maxRotation * Vector3.up));
    }
    
    public void RotateRight()
    {   
        maxRotation += 90f;
        Debug.Log(Quaternion.Euler(maxRotation * Vector3.up));
    }*/
}
