using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PAUSE_MENU;
    private bool isPaused;

    public void Awake()
    {
        PAUSE_MENU.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
            PAUSE_MENU.SetActive(isPaused);

            if (isPaused)
                Time.timeScale = 0F;
            else
                Time.timeScale = 1F;
        }
    }
}
