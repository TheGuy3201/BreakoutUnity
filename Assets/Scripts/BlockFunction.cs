using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class BlockFunction : MonoBehaviour
{
    int maxHits;
    int hitsTaken;
    Color blockColor;
    private void Start()
    {
        blockColor = GetComponent<SpriteRenderer>().color;
        maxHits = Random.Range(0, 2);
        hitsTaken = 0;
    }

    //For the Ball colliding with the top and bottomm
    public async void OnTriggerEnter2D(Collider2D other)
    {
        //Top Border
        if (this.gameObject.CompareTag("Top"))
        {
            await Task.Delay(200);
            GameObject.Find("Ball").GetComponent<BallSpawner>().Reset();
        }
        else if (this.gameObject.CompareTag("Bottom"))
        {
            //Bottom Border
            if (other.gameObject.CompareTag("Ball"))
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored(false);
                await Task.Delay(300);
                GameObject.Find("Ball").GetComponent<BallSpawner>().Reset();
            }
            else
                Destroy(other.gameObject);
        }
    }

    //For the ball colliding with the blocks
    public async void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Laser"))
        {
            if (other.gameObject.CompareTag("Laser"))
                Destroy(other.gameObject);

            if (hitsTaken >= maxHits)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored(true);
                GameObject.Find("GameManager").GetComponent<GameManager>().PowerSpawner(this.transform.position);
                await Task.Delay(200);
                Destroy(gameObject);
            }
            if(hitsTaken < maxHits)
                GetComponent<SpriteRenderer>().color = new Color(blockColor.r, blockColor.g-2,blockColor.b,blockColor.a);
            hitsTaken++;
        }
    }
}
