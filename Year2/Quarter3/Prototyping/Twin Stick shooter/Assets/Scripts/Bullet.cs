using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector2 direction;
    private float lifeSpan = 5;

    private void Update()
    {
        lifeSpan -= Time.deltaTime;
        if(lifeSpan <= 0) Destroy(gameObject);
    }
    private void FixedUpdate()
    {
         transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }
}
