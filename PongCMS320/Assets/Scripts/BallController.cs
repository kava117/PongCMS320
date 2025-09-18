using UnityEngine;
public class Ball : MonoBehaviour
{
    [SerializeField] GameController gameController;
    Rigidbody2D rb;
    public float speed;
    public Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized; //(1,1)
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * speed;
    }

    void ResetBall()
    {
        transform.position = new Vector3(0, 0, 0);
        direction.x = -direction.x;
        direction.y = -direction.y;
    }

    void OnTriggerEnter2D(Collider2D collison)
    {
        gameController.ChanceControls();
        
        if (collison.gameObject.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
        }
        else if (collison.gameObject.CompareTag("Floor"))
        {
            direction.y = -direction.y;
        }
        // hitting player 1 wall, point to player 2
        else if (collison.gameObject.CompareTag("Wall1"))
        {
            gameController.ScoreAdd("2");
            ResetBall();
        }
        // hitting player 2 wall, point to player 1
        else if (collison.gameObject.CompareTag("Wall2"))
        {
            gameController.ScoreAdd("1");
            ResetBall();
        }
            
    }
    
}