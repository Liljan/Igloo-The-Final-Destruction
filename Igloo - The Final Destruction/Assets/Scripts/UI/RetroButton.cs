using UnityEngine.UI;
using UnityEngine;

public class RetroButton : MonoBehaviour
{
    private Text TEXT_OBJECT;
    private string originalText;

    private bool isSelected;

    private void Awake()
    {
        TEXT_OBJECT = GetComponent<Text>();

        originalText = TEXT_OBJECT.text;
        isSelected = false;
    }

    public void SetSelected(bool b)
    {
        isSelected = b;

        if (isSelected)
            TEXT_OBJECT.text = '<' + originalText + '>';
        else
            TEXT_OBJECT.text = originalText;

    }

    private void OnDisable()
    {
        TEXT_OBJECT.text = originalText;
    }
}
