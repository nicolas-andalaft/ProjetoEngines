using UnityEngine;

public class ForceField : MonoBehaviour
{
    public GameObject gbForceField;
    public float duration;
    public float cooldown;

    private bool isEnabled;
    private float timer = 0;

    private void Awake()
    {
        timer = cooldown;    
    }

    private void Update()
    {
        if (isEnabled)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                timer = 0;
                isEnabled = false;
                gbForceField.SetActive(false);
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= cooldown)
                if (Input.GetButtonDown("Fire2"))
                {
                    timer = 0;
                    isEnabled = true;
                    gbForceField.SetActive(true);
                }
        }
    }
}
