using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            /*Destroy(other.gameObject);
            Debug.Log("You Win");
            SceneManager.LoadScene(0);*/
            GameEnv.Instance.ball.GetComponent<Rigidbody>().isKinematic = true;
            GameEnv.Instance.HUDCanvas.gameObject.GetComponentInChildren<HUDController>().SetWinBanner();    
            GameEnv.Instance.HUDCanvas.gameObject.GetComponentInChildren<HUDController>().ToggleButtons(true);    
        }
    }
}
