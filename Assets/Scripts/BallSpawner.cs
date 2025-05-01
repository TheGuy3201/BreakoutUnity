using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallSpawner : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 ballPoint;
    // Start is called before the first frame update
    void Start()
    {
        Begin();
    }

    //Resets the Ball
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(ballPoint.x, ballPoint.y+2, ballPoint.z);
        Begin();
    }

    private void Begin()
    {
        ballPoint = GameObject.Find("Player").GetComponent<Player1Controller>().transform.position;
        transform.position = new Vector3(ballPoint.x, ballPoint.y + 2, ballPoint.z);
        float x = Random.Range(1, 3);
        float y = Random.Range(1, 3);
        rb.velocity = new Vector2(speed * x, speed * y);
    }
}
