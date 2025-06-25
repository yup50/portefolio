using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool isRunning;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (collision.gameObject.GetComponent<ColorChanger>().color == GetComponent<ColorChanger>().color)
            {
                Destroy(gameObject);
            }
            else
            {
                if(!isRunning) StartCoroutine(WrongColor(collision));
            }
            
        }
    }

    IEnumerator WrongColor(Collider2D collision)
    {
        isRunning = true;
        SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
        Color c = sr.color;
        c.a = 0.25f;
        sr.color = c; 
        yield return new WaitForSeconds(3);
        c = sr.color;
        c.a = 1f;
        sr.color = c;
        isRunning = false;

    }
}
