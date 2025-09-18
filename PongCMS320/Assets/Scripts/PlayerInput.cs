using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PaddleController paddleController1;
    [SerializeField] private PaddleController paddleController2;
    [SerializeField] private TextController textController;
    private KeyCode p1Up;
    private KeyCode p1Down;
    private KeyCode p2Up;
    private KeyCode p2Down;
    private KeyCode[] keyPool = {
        KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y,
        KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.A, KeyCode.S,
        KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J,
        KeyCode.K, KeyCode.L, KeyCode.Z, KeyCode.C, KeyCode.V,
        KeyCode.B, KeyCode.N, KeyCode.M, KeyCode.UpArrow, KeyCode.LeftArrow,
        KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.Alpha2, KeyCode.Alpha4,
        KeyCode.Alpha7, KeyCode.Alpha8
    };
    private int[] inUse = { 1, 10, 24, 27 };
    private bool gameOver = false;

    public void Awake()
    {
        p1Up = keyPool[1];
        p1Down = keyPool[10];
        p2Up = keyPool[24];
        p2Down = keyPool[27];
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;
        // PLAYER 2
        if (Input.GetKey(p2Up))
        {
            paddleController2.MovePlayer2("up");
        }
        else if (Input.GetKey(p2Down))
        {
            paddleController2.MovePlayer2("down");
        }


        // PLAYER 1
        if (Input.GetKey(p1Up))
        {
            paddleController1.MovePlayer1("up");
        }
        else if (Input.GetKey(p1Down))
        {
            paddleController1.MovePlayer1("down");
        }
    }

    public void RandomizeControls(string player)
    {
        Debug.Log("Randomizing controls for player " + player);
        int upOrDown = (int)Random.Range(0, 2);
        int randControl = inUse[0];
        while (randControl == inUse[0] || randControl == inUse[1] || randControl == inUse[2] || randControl == inUse[3])
            randControl = Random.Range(0, keyPool.Length);

        if (player == "1" && upOrDown == 0)
        {
            p1Up = keyPool[randControl];
            inUse[0] = randControl;
            Debug.Log("Player 1 UP now: " + keyPool[randControl]);
            textController.ChangeControlText("1", p1Up + "", p1Down + "");
        }
        else if (player == "1" && upOrDown == 1)
        {
            p1Down = keyPool[randControl];
            inUse[1] = randControl;
            Debug.Log("Player 1 DOWN now: " + keyPool[randControl]);
            textController.ChangeControlText("1", p1Up + "", p1Down + "");
        }
        else if (player == "2" && upOrDown == 0)
        {
            p2Up = keyPool[randControl];
            inUse[2] = randControl;
            Debug.Log("Player 2 UP now: " + keyPool[randControl]);
            textController.ChangeControlText("2", p2Up + "", p2Down + "");
        }
        else if (player == "2" && upOrDown == 1)
        {
            p2Down = keyPool[randControl];
            inUse[3] = randControl;
            Debug.Log("Player 2 DOWN now: " + keyPool[randControl]);
            textController.ChangeControlText("2", p2Up + "", p2Down + "");
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }
}
