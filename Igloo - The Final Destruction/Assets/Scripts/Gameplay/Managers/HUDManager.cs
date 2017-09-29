using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text TEXT_LIVES;
    public Text TEXT_HEALTH;
    public Text TEXT_TOKENS;
    public Text TEXT_AMMO;

    private static HUDManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static HUDManager Instance()
    {
        return instance;
    }

    public void SetLives(int i)
    {
        string msg = Mathf.Abs(i) > 9 ? i + "" : "0" + i;
        TEXT_LIVES.text = msg;
    }

    public void SetHealth(int i)
    {
        string msg = Mathf.Abs(i) > 9 ? i + "" : "0" + i;
        TEXT_HEALTH.text = msg;
    }

    public void SetTokens(int i)
    {
        string msg = Mathf.Abs(i) > 9 ? i + "" : "0" + i;
        TEXT_TOKENS.text = msg;
    }

    public void SetAmmo(int clip, int clipSize)
    {
        string c = Mathf.Abs(clip) > 9 ? clip + "" : "0" + clip;
        string cs = Mathf.Abs(clipSize) > 9 ? clipSize + "" : "0" + clipSize;
        TEXT_AMMO.text = c + "/" + cs;
    }
}
