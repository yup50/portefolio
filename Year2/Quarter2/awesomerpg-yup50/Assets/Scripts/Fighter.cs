using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private float weaponRange = 2f;
    [SerializeField] private float timeBetweenAttacks = 1f;
    [SerializeField] private float weaponDamage = 20f;
    private BaseStats stats;

    private float timeSinceLastAttack = 0;
    private Transform target;


    private void Start()
    {
        stats = GetComponentInParent<BaseStats>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) AttackAnimation();
        timeSinceLastAttack += Time.deltaTime;

        if (target == null) return;

        if (!GetIsInRange())
        {
            GetComponentInParent<Mover>().Move(target.position);
        }
        else
        {
            GetComponentInParent<Mover>().Stop();
            AttackAnimation();
        }
    }

    private void AttackAnimation()
    {
        if (timeSinceLastAttack > timeBetweenAttacks)
        {
            GetComponent<Animator>().SetTrigger("Attack");
            timeSinceLastAttack = 0f;
        }
    }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.position) < weaponRange;
    }

    public void Attack(CombatTarget combatTarget)
    {
        print("Take that you dirty peasant!");
        target = combatTarget.transform;
        print(target.name);
    }

    public void Cancel()
    {
        target = null;
    }

    public void Hit()
    {
        Health health = target.GetComponent<Health>();
        if (health != null) health.TakeDamage(weaponDamage + stats.GetStat(Stats.Strength));
    }
}
