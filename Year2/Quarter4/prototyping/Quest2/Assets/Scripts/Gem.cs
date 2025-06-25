using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            ColorChanger cc = collision.GetComponent<ColorChanger>();
            cc.ChangeColor(GetComponent<ColorChanger>().color);
        }
    }
}
