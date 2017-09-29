using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PAUSE_MENU;
    private bool isPaused;

    public RetroButton[] BUTTONS;
    private int btnIdx;

    private AxisAsButton horizontal;

    private static PauseManager instance;

    public void Awake()
    {
        PAUSE_MENU.SetActive(false);
        isPaused = false;

        horizontal = AxisAsButton.CreateAxisAsButton("Horizontal");

        instance = this;
    }

    public static PauseManager Instance()
    {
        return instance;
    }

    private void OnUnPaused()
    {
        BUTTONS[btnIdx].SetSelected(false);
    }

    private void ScrollRight()
    {
        BUTTONS[btnIdx].SetSelected(false);
        btnIdx++;

        if (btnIdx == BUTTONS.Length)
            btnIdx = 0;

        BUTTONS[btnIdx].SetSelected(true);
    }

    private void ScrollLeft()
    {
        BUTTONS[btnIdx].SetSelected(false);
        btnIdx--;

        if (btnIdx < 0)
            btnIdx = BUTTONS.Length - 1;

        BUTTONS[btnIdx].SetSelected(true);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            SetPaused(!isPaused);
        }

        if (!isPaused)
            return;

        float xAxis = horizontal.IsDown();

        if (xAxis > 0.0f)
            ScrollRight();
        if (xAxis < 0.0f)
            ScrollLeft();

        if (Input.GetButtonDown("Jump"))
        {
            BUTTONS[btnIdx].Select();
        }
    }

    public void SetPaused(bool b)
    {
        isPaused = b;

        PAUSE_MENU.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0F;
            MusicManager.Instance().PAUSE_MUSIC.Play();
            MusicManager.Instance().LEVEL_MUSIC.Pause();

            btnIdx = 0;
            BUTTONS[btnIdx].SetSelected(true);
        }
        else
        {
            Time.timeScale = 1F;
            MusicManager.Instance().PAUSE_MUSIC.Stop();
            MusicManager.Instance().LEVEL_MUSIC.Play();
        }
    }
}
