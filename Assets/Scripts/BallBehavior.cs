using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private SphereCollider col;
    private Rigidbody rb;

    [SerializeField] private float raycastOffset = .01f;
    [SerializeField] private float gravity = 200f;
    [SerializeField] private LayerMask groundLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded().collider == null) rb.velocity += gravity * Time.deltaTime * Vector3.down;
        else transform.position = Vector3.up * (IsGrounded().point.y - col.radius);
    }

    private RaycastHit IsGrounded() 
    {
        bool hit = Physics.SphereCast(col.center, col.radius, Vector3.down, out RaycastHit hitInfo, col.radius + raycastOffset, groundLayerMask);
        Color rayColor = hit ? Color.green : Color.red;
        Debug.DrawRay(col.center, Vector3.up * 15f, rayColor);
        return hitInfo;
    }

}
