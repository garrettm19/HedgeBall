using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    //private SphereCollider col;
    private Rigidbody rb;
    public Rigidbody getRb { get { return rb; } }
    private SphereCollider sCol;
    private Transform currMaze;
    private GameObject camera;

    [SerializeField] private float linearForce = 5f;
    [SerializeField] private float raycastOffset = 0.5f;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private HUDController hudController;

    [SerializeField] private Vector3 cameraOffset = new Vector3(0, -6, 16);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sCol = GetComponent<SphereCollider>();
        currMaze = GameObject.FindGameObjectWithTag("Maze").GetComponent<Transform>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = transform.position - cameraOffset;
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
        //if (other.CompareTag("End"))
        //{
        //    hudController.setWinBanner();
        //}
    }
}
