using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    bool turn = true;

    public int movSpeed = 10;

    public int score { get; set; } = 0;
    public int lastScore;

    public Text scoreText;
    public Transform Player;
    protected AudioSource hitWall;
    protected float lastYcoor;
    protected Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        hitWall = GetComponent<AudioSource>();
        Invoke("StartBouncing", 2f);
        rb2d.gravityScale = 0;
        LoadLastData(); //
    }

    private void LoadLastData()
    {
        Debug.Log(lastScore + " " + lastYcoor);
        lastScore = SaveLoadManager.Load("playerdata.txt").LastScore;
        lastYcoor = SaveLoadManager.Load("playerdata.txt").lastYcoor;

        scoreText.text = lastScore.ToString();
        if (lastScore > score) { score = lastScore; }

        Player.position = new Vector2(4.74f, lastYcoor);
    }

    void StartBouncing()
    {
        rb2d.velocity = new Vector2(1, 0) * movSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitWall.Play();
        rb2d.velocity = new Vector2(turn? -1:1, 0) * movSpeed;
        turn = !turn;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitWall.Play();
        MakeScore();    
        if (score > 0 && score % 5 == 0)
        {
            if (transform.position.y - Player.position.y > -2f)
            {
                Player.position += Vector3.up;
            }
            else
                Player.position = new Vector2(4.74f, 0.69f);
        }

        SaveLoadManager.Save("playerdata.txt", new PlayerData(score, Player.position.y));
        Destroy(collision.gameObject);

    }

    private void MakeScore()
    {
        score++;
        scoreText.text = score.ToString();
        if(score > lastScore) lastScore = score;

    }
}
