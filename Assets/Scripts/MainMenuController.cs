using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;
    void Start()
    {
        SaveController.Instance.Reset();
    
        string lastWinner = SaveController.Instance.GetLastWinner();
        if (lastWinner != "")
            uiWinner.text = "Last winner: " + lastWinner;
        else
            uiWinner.text = "";
    }
}
