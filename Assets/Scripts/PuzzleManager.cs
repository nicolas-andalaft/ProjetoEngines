using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject portal;
    private int correctQtd;
    private AudioSource sound;

    private void Awake()
    {
        portal.gameObject.SetActive(false);

        PuzzlePlataform pp;
        foreach (Transform child in transform)
        {
            child.gameObject.TryGetComponent(out pp);

            if (pp && pp.currentState == pp.requiredState)
                correctQtd++;
        }

        sound = GetComponent<AudioSource>();
    }

    public void PlataformChanged(bool isCorrect)
    {
        if (isCorrect) correctQtd++;
        else correctQtd--;

        if (correctQtd == transform.childCount)
        {
            sound.Play();
            portal.gameObject.SetActive(true);
        }
    }
}
