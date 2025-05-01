using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float playerSpeed;
    float fireRate;
    public float shots;
    private float timer = 0;
    public GameObject laserBeam;
    public bool canShoot;

    void Start()
    {
        fireRate = 0.25f;
        shots = 10;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector2 newVelocity = new Vector2(horizontalMove, 0);
        GetComponent<Rigidbody2D>().velocity = newVelocity * playerSpeed;
        if (canShoot)
        {
            if (Input.GetAxis("Fire1") > 0 && timer > fireRate && shots > 0)
            {
                Shoot();
            }
            else if (shots <= 0)
            {
                canShoot = false;
                shots = 10;
            }
            timer += Time.deltaTime;
        }
    }

    private void Shoot()
    {
        GameObject goObj;
        goObj = GameObject.Instantiate(laserBeam, new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + 2, GetComponent<Transform>().position.z), transform.rotation);
        goObj.transform.Rotate(0.0f, 0.0f, 0.0f);

        shots--;
        timer = 0;
    }
}
