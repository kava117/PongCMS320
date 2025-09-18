using UnityEngine;
public class PaddleController : MonoBehaviour
{
    Rigidbody2D p1Pad;
    Rigidbody2D p2Pad;
    Vector2 p1Initial;
    Vector2 p2Initial;

    private double screenBottom = -4;
    private double screenTop = 4;

    // BASICALLY THIS IS THE SPEED
    [SerializeField] private float displacement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // PADDLES
        p1Pad = GetComponent<Rigidbody2D>();
        p2Pad = GetComponent<Rigidbody2D>();

        // VECTORS
        p1Initial = p1Pad.transform.localPosition;
        p2Initial = p2Pad.transform.localPosition;
    }

    public void MovePlayer1(string direction)
    {
        if (direction == "up")
        {
            if (p1Initial.y < screenTop)
                p1Initial.y = p1Initial.y + displacement;
        }

        else if (direction == "down")
        {
            if (p1Initial.y > screenBottom)
                p1Initial.y = p1Initial.y - displacement;
        }      
        p1Pad.MovePosition(p1Initial);
    }


    public void MovePlayer2(string direction)
    {
        if (direction == "up")
        {
            if (p2Initial.y < screenTop)
                p2Initial.y = p2Initial.y + displacement;
        }
        else if (direction == "down")
        {
            if (p2Initial.y > screenBottom)
                p2Initial.y = p2Initial.y - displacement;
        }
        p2Pad.MovePosition(p2Initial);
    }

}
// inspector sets the displacement value

