using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    //private SphereCollider col;
    private Rigidbody rb;
    private Transform currMaze;

    [SerializeField] private float linearForce = 5f;
    [SerializeField] private LayerMask groundLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
    }
}
