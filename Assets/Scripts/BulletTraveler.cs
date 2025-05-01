using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BulletTraveler : MonoBehaviour
{
    public float beamSpeed = 12f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, beamSpeed);
    }

    // Update is called once per frame
    async void Update()
    {
        await Task.Delay(2500);
        Destroy(gameObject);
    }
}
