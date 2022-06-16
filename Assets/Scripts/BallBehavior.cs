using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    //private SphereCollider col;
    public Rigidbody rb { get; private set; }
    private SphereCollider sCol;
    private Transform currMaze;

    [SerializeField] private float linearForce = 5f;
    [SerializeField] private float raycastOffset = 0.01f;
    [SerializeField] private LayerMask groundLayerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sCol = GetComponent<SphereCollider>();
        currMaze = GameEnv.Instance.maze.transform;
    }

    void Update()
    {
        //Add Linear Force
        if (Vector3.Angle(Vector3.up, currMaze.up) > 1f)
        {
            Vector3 direction = Vector3.ProjectOnPlane(currMaze.up, Vector3.up).normalized;
            rb.AddForce(linearForce * direction, ForceMode.Acceleration);
        }

        if (IsGrounded() & rb.isKinematic == false)
        {
            Vector3 velocity = rb.velocity;
            velocity = new Vector3(velocity.x, 0f, velocity.z);
            rb.velocity = velocity;
        }
    }

    private bool IsGrounded() 
    {
        //Debug.DrawRay(transform.position, -transform.up * (gameObject.GetComponent<SphereCollider>().radius + raycastOffset), Color.red);
        return Physics.Raycast(rb.position, -currMaze.up, out _, sCol.radius + raycastOffset, groundLayerMask);
    }
}
