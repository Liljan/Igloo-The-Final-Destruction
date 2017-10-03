using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject lockObject;

    public Node UP;
    public Node DOWN;
    public Node LEFT;
    public Node RIGHT;

    public string[] unlockConditions;
    public bool lockUp = false;
    public bool lockDown = false;
    public bool lockLeft = false;
    public bool lockRight = false;

    private static int LOCKED = 0;
    private static int UNLOCKED = 1;

    private void Awake()
    {
        CheckUnlockConditions();
    }

    private void CheckUnlockConditions()
    {
        for (int i = 0; i < unlockConditions.Length; i++)
        {
            int status = PlayerPrefs.GetInt(unlockConditions[i]);
            if (status == LockStatus.LOCKED)
            {
                lockObject.SetActive(true);
                return;
            }
        }

        // unlock if all unlock conditions have been met.
        Unlock();
    }

    private void Unlock()
    {
        lockUp = lockDown = lockLeft = lockRight = false;
        lockObject.SetActive(false);
    }
}
