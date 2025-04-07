using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference moveActionToUse, shootActionToUse;
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    private Vector2 moveDirection, shootDirection;

    private float fireRate, nextFire;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Screenmanager sm;


    [SerializeField]
    private Buffs buffs;



    private void Start()
    {
        nextFire = 0;
        fireRate = 0.5f;
        buffs = GetComponent<Buffs>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Reads both stick directions and checks if right stick axis isn't zero to shoot
    void Update()
    {
        moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        shootDirection = shootActionToUse.action.ReadValue<Vector2>();

        if (shootDirection != Vector2.zero && Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            ShootBullet(shootDirection);
        }
    }

    // Moves player in direction of left stick

    private void FixedUpdate()
    {
        if (buffs.moreSpeed)
        {
            speed = 9f;
        }
        else
        {
            speed = 3f;
        }
        transform.Translate(moveDirection * speed * Time.fixedDeltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, sm.minX, sm.maxX);
        float clampedY = Mathf.Clamp(transform.position.y, sm.minY, sm.maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        if (moveDirection.x < 0) // Links bewegen
        {
            transform.localScale = new Vector3(-10, transform.localScale.y, transform.localScale.z);
        }
        else if (moveDirection.x > 0) // Rechts bewegen
        {
            transform.localScale = new Vector3(10, transform.localScale.y, transform.localScale.z);
        }
    }

    // Spawns new bullet and gives it a direction
    public void ShootBullet(Vector2 direction)
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Bullet newBulletScript = newBullet.GetComponent<Bullet>();
        newBulletScript.SetDirection(direction);

        if (buffs.moreBullet)
        {
            GameObject newBullet2 = Instantiate(bullet, transform.position, Quaternion.identity);
            Bullet newBulletScript2 = newBullet2.GetComponent<Bullet>();
            newBulletScript2.SetDirection(-direction);
            
            GameObject newBullet3 = Instantiate(bullet, transform.position, Quaternion.identity);
            Bullet newBulletScript3 = newBullet3.GetComponent<Bullet>();
            newBulletScript3.SetDirection(direction + new Vector2(0.5f, 0f));

            GameObject newBullet4 = Instantiate(bullet, transform.position, Quaternion.identity);
            Bullet newBulletScript4 = newBullet4.GetComponent<Bullet>();
            newBulletScript4.SetDirection(direction + new Vector2(-0.5f, 0f));
        }

    }

    public void TakeDamage(int damage)
    {
        GetComponent<LivesSystem>().TakeDamage(damage);
    }
}
