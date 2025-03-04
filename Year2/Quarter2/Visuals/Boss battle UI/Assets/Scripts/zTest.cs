using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zTest : MonoBehaviour
{
    public Mana mana;
    public PlayerHp playerHp;
    public Exp exp;
    public EnemyHp enemyHp;

    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 3)
        {
            playerHp.LowerHp(30);
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && mana.currentMana >= 20)
        {
            playerHp.IncreaseHp(50);
            mana.LowerMana(20);
            timer++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && mana.currentMana >= 30)
        {
            playerHp.IncreaseHp(100);
            mana.LowerMana(30);
            timer++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && mana.currentMana >= 25)
        {
            playerHp.IncreaseMaxHp(50);
            mana.LowerMana(25);
            timer++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mana.IncreaseMaxMana(100);
            timer++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            mana.IncreaseMana(100);
            timer++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log(enemyHp.currentHp + "/" + enemyHp.maxHp);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) && mana.currentMana >= 50)
        {
            enemyHp.LowerHp(200);
            mana.LowerMana(50);
            timer++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("Still Locked");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("Still Locked");
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Still Locked");
        }


    }
}
