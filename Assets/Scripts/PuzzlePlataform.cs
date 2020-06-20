using UnityEngine;

public class PuzzlePlataform : MonoBehaviour
{
    public bool currentState;
    public bool requiredState;
    private AudioSource sound;
    private PuzzleManager puzzleManager;
   
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        puzzleManager = transform.parent.GetComponent<PuzzleManager>();

        transform.GetChild(0).gameObject.SetActive(currentState);
        transform.GetChild(1).gameObject.SetActive(!currentState);
    }

    public void ChangeState()
    {
        sound.Play();

        currentState = !currentState;
        transform.GetChild(0).gameObject.SetActive(currentState);
        transform.GetChild(1).gameObject.SetActive(!currentState);

        puzzleManager.PlataformChanged(currentState == requiredState);
    }
}
