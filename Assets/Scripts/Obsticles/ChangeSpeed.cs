using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    [SerializeField] float changeValue = 2.0f;
    [SerializeField] float duration = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<BallBehavior>().ChangeSpeed(changeValue, duration);
        }
    }
}
