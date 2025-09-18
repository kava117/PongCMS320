using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    [SerializeField] private TMP_Text p1Score;
    [SerializeField] private TMP_Text p2Score;
    [SerializeField] private TMP_Text p1Controls;
    [SerializeField] private TMP_Text p2Controls;
    [SerializeField] private TMP_Text gameComplete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1Score.text = "0";
        p2Score.text = "0";

        p1Controls.text = "W + S";
        p2Controls.text = "UpArrow + DownArrow";
    }

    public void ChangeScoreText(string player, int score)
    {
        if (player == "1")
        {
            p1Score.text = score + "";
        }
        else
        {
            p2Score.text = score + "";
        }
    }

    public void GameCompleteText(string player)
    {
        if (player == "1")
        {
            gameComplete.text = "PLAYER 1 WINS!";
        }
        else
        {
            gameComplete.text = "PLAYER 2 WINS!";
        }
    }

    public void ChangeControlText(string player, string cntrl1, string cntrl2)
    {
        if (player == "1")
        {
            Debug.Log("Chaning p1 control text to " + cntrl1 + " + " + cntrl2);
            p1Controls.text = cntrl1 + " + " + cntrl2;
        }
        else if (player == "2")
        {
            Debug.Log("Chaning p2 control text to " + cntrl1 + " + " + cntrl2);
            p2Controls.text = cntrl1 + " + " + cntrl2;
        }
        
    }
}
