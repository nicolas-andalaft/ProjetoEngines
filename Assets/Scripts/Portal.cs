using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string targetScene;
    public bool returnToWorld;
    public GameUI gameui;
    public static Transform returnLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        gameui.ShowLoading();

        if (returnToWorld)
        {
            SceneManager.LoadScene("MainScene");
            Transform playerLocation = GameObject.FindGameObjectWithTag("Player")
                .GetComponent<Transform>();
            playerLocation = returnLocation;
        }
        else
        {
            SceneManager.LoadScene(targetScene);
            returnLocation = gameObject.GetComponent<Transform>();
        }
    }
}
