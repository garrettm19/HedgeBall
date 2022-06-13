using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour
{
    //private SphereCollider col;
    private Rigidbody rb;
    public Rigidbody getRb { get { return rb; } }
    private SphereCollider sCol;
    private Transform currMaze;

    [SerializeField] private float linearForce = 5f;
    [SerializeField] private float raycastOffset = 0.01f;
    [SerializeField] private LayerMask groundLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sCol = GetComponent<SphereCollider>();
        currMaze = GameEnv.Instance.maze.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Add Linear Force
        if (Vector3.Angle(Vector3.up, currMaze.up) > 1f)
        {
            Vector3 direction = Vector3.ProjectOnPlane(currMaze.up, Vector3.up).normalized;
            rb.AddForce(linearForce * direction, ForceMode.Acceleration);
        }

        if (IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }
    }

    private bool IsGrounded() 
    {
        //Debug.DrawRay(transform.position, -transform.up * (gameObject.GetComponent<SphereCollider>().radius + raycastOffset), Color.red);
        return Physics.Raycast(rb.position, -currMaze.up, out _, sCol.radius + raycastOffset, groundLayerMask);
    }

    public void ChangeSpeed(float value, float time)
    {
        StartCoroutine(ChangeSpeedDuration(value, time));
    }

    IEnumerator ChangeSpeedDuration(float value, float time)
    {
        linearForce += value;
        yield return new WaitForSeconds(time);
        linearForce -= value;
    }
}
