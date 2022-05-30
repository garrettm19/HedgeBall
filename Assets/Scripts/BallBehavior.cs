using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    //private SphereCollider col;
    private Rigidbody rb;
    private SphereCollider sCol;
    private Transform currMaze;

    [SerializeField] private float linearForce = 5f;
    [SerializeField] private float raycastOffset = 0.5f;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private HUDController hudController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sCol = GetComponent<SphereCollider>();
        currMaze = GameObject.FindGameObjectWithTag("Maze").GetComponent<Transform>();
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
        return Physics.Raycast(rb.position, -currMaze.up, out _, sCol.radius + raycastOffset, groundLayerMask);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            hudController.setWinBanner();
        }
    }
}
