using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float life;

    public float getLife()
    {
        return life;
    }

    public void decreaseLife(float value)
    {
        life -= value;
        if (life < 0) life = 0;
    }
}
