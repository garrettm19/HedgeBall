using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] float knockBackForce = 3000;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            Vector3 dir = transform.position - other.transform.position;
            dir.Normalize();
            Debug.Log(dir);
            dir.y = 0;
            other.GetComponent<BallBehavior>().getRb.velocity = Vector3.zero;
            other.GetComponent<BallBehavior>().getRb.AddForce(knockBackForce * -dir, ForceMode.Acceleration);
        }
    }
}
