using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioSource PAUSE_MUSIC;
    public AudioSource LEVEL_MUSIC;

    public static MusicManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static MusicManager Instance()
    {
        return instance;
    }
}