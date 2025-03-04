using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public bool moreBullet;
    public bool moreSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Temp temp = collision.GetComponent<Temp>(); // Eén keer ophalen en hergebruiken

        if (temp == null) return; 

        if (temp.type == "speed")
        {
            moreSpeed = true;
            Invoke("ChangeSpeed", 10f);
            Destroy(collision.gameObject);
        }
        if (temp.type == "bullet")
        {
            moreBullet = true;
            Invoke("ChangeBullet", 10f);
            Destroy(collision.gameObject);
        }
        if (temp.type == "heal")
        {
            GetComponent<PlayerController>().TakeDamage(-1);
            Destroy(collision.gameObject);
        }
    }

    void ChangeBullet()
    {
        moreBullet = false;
    }

    void ChangeSpeed()
    {
        moreSpeed = false;
    }
}
