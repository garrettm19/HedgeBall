using UnityEngine;
using UnityEngine.InputSystem;

public class MazeControl : MonoBehaviour
{

    [SerializeField] private float tiltSpeed = 2.0f;
    [SerializeField] private float maxAngle = 10f;

    private Vector3 rotateInput;
    [SerializeField] private float yRotation;
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
        if (GameManager.manager.GetComponent<GameSM>().CurrentState is PlayState)
        {
            rotateInput = value.Get<Vector3>();
        }
    }

    void TiltMaze()
    {
        var targetRotation = Quaternion.Euler(maxAngle * rotateInput.x * Vector3.back)
                                    * Quaternion.Euler(maxAngle * rotateInput.z * Vector3.right)
                                    * Quaternion.Euler(yRotation * Vector3.up);
        maze.rotation = Quaternion.Lerp(maze.rotation, targetRotation, tiltSpeed * Time.deltaTime);

    }

    public void RotateLeft()
    {
        yRotation += 90;
    }
    
    public void RotateRight()
    {   
        yRotation -= 90;
    }
}
