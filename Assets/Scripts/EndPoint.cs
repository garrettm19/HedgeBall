using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        GameEnv.Instance.ball.GetComponent<Rigidbody>().isKinematic = true;
        GameEnv.Instance.HUDCanvas.gameObject.GetComponentInChildren<HUDController>().SetWinLoseBanner("YOU WIN");
    }
}
