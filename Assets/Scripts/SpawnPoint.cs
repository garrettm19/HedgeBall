using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject ball;

    private GameObject currentBall = null;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        if (currentBall != null)
        {
            Destroy(currentBall);
        }
       currentBall = Instantiate(ball, transform.position, Quaternion.identity);
    }
}
