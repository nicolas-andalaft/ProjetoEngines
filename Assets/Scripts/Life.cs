using UnityEngine;

public class Life : MonoBehaviour
{
    public GameUI hud;
    [SerializeField]
    private float life;

    public float getLife()
    {
        return life;
    }

    public void decreaseLife(float value)
    {
        life -= value;
        hud?.UpdateLife(life/1000);
        if (life < 0 && gameObject.CompareTag("Player"))
        {
            hud.ShowGameOver();
        }
    }
}
