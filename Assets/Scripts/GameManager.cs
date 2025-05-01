using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject grow;
    public GameObject laser;

    public GameObject ball;

    public GameObject ScoreText;

    public int score;

    public void PlayerScored(bool isPositive)
    {
        if (isPositive)
        {
            score++;
        }
        else
        {
            score--;
        }
        ScoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    public void PowerSpawner(Vector3 blockLocation)
    {
        int powerChance = Random.Range(0, 10);

        if (powerChance == 1)
        {
            Instantiate(grow, new Vector3(blockLocation.x, blockLocation.y-2), grow.transform.rotation);
        }
        else if (powerChance == 2)
        {
            Instantiate(laser, new Vector3(blockLocation.x, blockLocation.y-2), laser.transform.rotation);
        }
    }
}
