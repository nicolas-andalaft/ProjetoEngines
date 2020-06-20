using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Image lifeBar;
    public GameObject gameover;
    public GameObject loadingscreen;

    private void Awake()
    {
        ShowLoading(false);
    }

    public void UpdateLife(float amount)
    {
        lifeBar.fillAmount = amount;
    }

    public void ShowGameOver(bool state = true)
    {
        gameover.SetActive(state);
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }

    public void ShowLoading(bool state = true)
    {
        loadingscreen.SetActive(state);
    }
}
