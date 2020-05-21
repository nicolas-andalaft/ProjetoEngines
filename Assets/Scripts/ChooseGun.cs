using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGun : MonoBehaviour
{
    public GameObject[] gunList;
    public int currentGun = 0;

    private void Awake()
    {
        gunList[0].SetActive(true);
        for (int i = 1; i < gunList.Length; i++)
        {
            gunList[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            gunList[currentGun].SetActive(false);
            currentGun = ++currentGun % gunList.Length;
            gunList[currentGun].SetActive(true);

        }
    }
}
