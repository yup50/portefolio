using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : Enemy
{

    private new void Start()
    {
        base.Start();
        scorePoints *= 2.25f;
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage/2);
        GetComponent<SpriteRenderer>().color = new Color(1f, 0, 0, 0.5f);
    }
}
