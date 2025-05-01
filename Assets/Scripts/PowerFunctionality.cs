using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFunctionality : MonoBehaviour
{
    public Vector3 playerSize;
    public bool isGrow;
    // Start is called before the first frame update
    void Start()
    {
        playerSize = GameObject.Find("Player").GetComponent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckPowerType();
            Destroy(this.gameObject);
        }
    }

    //Checks the type of powerUp it is
    void CheckPowerType()
    {
        if (isGrow)
            Grow();
        else
            Laser();
    }

    //Grow by 25% code
    private void Grow()
    {
        GameObject.Find("Player").GetComponent<Transform>().localScale = new Vector3 (playerSize.x*1.25f,playerSize.y,playerSize.z);
    }

    //Laser PowerUp Code
    private void Laser()
    {
        GameObject.Find("Player").GetComponent<Player1Controller>().canShoot = true;
    }

    
}
