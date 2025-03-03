using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    // Gezondheidsinstellingen
    public int currentHealth = 3;

    // Referenties naar speler en NavMeshAgent
    public Transform player;
    public NavMeshAgent agent;

    // Instellingen voor zicht- en aanvalsbereik
    public float sightRange = 15f;
    public float attackRange = 2f;
    public float roamRadius = 10f;
    public int attackDamage = 3;
    public float attackCooldown = 2f;

    // Statussen
    private bool playerInSightRange;
    private bool playerInAttackRange;

    // Tijdelijke doelpositie voor roaming
    private Vector3 roamTarget;

    // Referentie naar het gezondheidssysteem van de speler
    private VitalsController playerVitals;

    // Cooldown timer voor aanvallen
    private float lastAttackTime;

    // Animator voor het aansturen van animaties
    private Animator animator;

    private bool isDead = false;  // Check of de zombie dood is

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();  // Haal de Animator component op
    }

    void Start()
    {
        // Zorg ervoor dat de agent en speler zijn toegewezen
        if (!agent) agent = GetComponent<NavMeshAgent>();
        if (!player) player = GameObject.FindWithTag("Player").transform;

        playerVitals = player.GetComponent<VitalsController>();

        lastAttackTime = -attackCooldown;
    }

    void Update()
    {
        if (isDead) return;  // Als de zombie dood is, doe 

        // Check afstanden tussen zombie en speler
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        playerInSightRange = distanceToPlayer <= sightRange;
        playerInAttackRange = distanceToPlayer <= attackRange;

        // Gedragskeuzes op basis van de afstand tot de speler
        if (playerInAttackRange)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.Play("Z_Attack");
            AttackPlayer();  // Val de speler aan
        }
        else if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();  // Achtervolg de speler
        }
        else if ((!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && animator.GetBool("Idle") == false) || (animator.GetBool("Run") == true && !playerInAttackRange))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            animator.Play("Z_Idle");
        }
        
        
    }

    public void Roam()
    {
            roamTarget = GetRandomRoamPosition();
            agent.SetDestination(roamTarget);
            animator.SetBool("Walk", true);
            animator.Play("Z_Walk_InPlace");
            animator.SetBool("Idle", false);
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);

        // Achtervolg animatie
        animator.SetBool("Walk", false);
        animator.SetBool("Run", true);
    }

    void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        if (Time.time > lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            // Zorg dat de speler schade ontvangt via zijn gezondheidssysteem
            if (playerVitals != null)
            {
                playerVitals.Decrease(attackDamage, "health");
            }

            Debug.Log("Zombie valt aan!");
        }        
    }

    Vector3 GetRandomRoamPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        return hit.position;
    }

    public void Damage(int damageAmount)
    {
        // Breng schade toe aan de zombie
        currentHealth -= damageAmount;
        Debug.Log(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            Die();  // Roep sterfmechanisme aan als de gezondheid op is
        }
    }

    void Die()
    {
        isDead = true;
        animator.Play("Z_FallingForward");
        
        // Na een korte vertraging verdwijnt de zombie
        Destroy(gameObject, 1.5f); 
    }

    // Debugging: laat de zicht- en aanvalsbereiken zien in de Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
