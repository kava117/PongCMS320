using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextController textController;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject paddle1;
    [SerializeField] private GameObject paddle2;

    private int range = 10;

    private int p1Score;
    private int p2Score;

    public void ScoreAdd(string player)
    {
        if (player == "1")
        {
            p1Score++;
            textController.ChangeScoreText("1", p1Score);
            if (p1Score == 5)
            {
                GameComplete("1");
    
            }
        }
        else
        {
            p2Score++;
            textController.ChangeScoreText("2", p2Score);
            if (p2Score == 5)
            {
                GameComplete("2");
            }
        }
    }

    public void ChanceControls()
    {
        int chance = Random.Range(0, range--);
        Debug.Log("Range is between " + range);
        string player = Random.Range(1, 3) + "";

        if (chance == 0 || range == 1)
        {
            range = 10;
            playerInput.RandomizeControls(player);
            Debug.Log("CHANGING CONTROLS FOR PLAYER " + player);
        }  
    }

    void GameComplete(string winner)
    {
        textController.GameCompleteText(winner);
        Destroy(ball);
        Destroy(paddle1);
        Destroy(paddle2);
        playerInput.GameOver();
    }
}
