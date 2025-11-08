using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public EnemyType enemyType;
    public int maxHealth = 100;
    protected int currentHealth;

    [Header("Pathfinding")]
    public NavMeshAgent agent;
    public Transform player;
    public float sightRange = 15f;     
    public LayerMask obstacleMask;     

    [Header("Attack")]
    public int damageAmount = 10;
    public float attackCooldown = 1f;

    private float lastAttackTime;

    protected virtual void OnEnable()
    {
        currentHealth = maxHealth;

        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }

        // Make sure collider is trigger for attack
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    public virtual void OnSpawn(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
        currentHealth = maxHealth;
    }

    public virtual void OnDespawn()
    {
        gameObject.SetActive(false);
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        EnemyPoolManager.Instance?.ReturnEnemy(enemyType, gameObject);
    }

    private void Update()
    {
        if (player == null || agent == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= sightRange && HasLineOfSight())
        {
            ChasePlayer();
        }
        else
        {
            agent.ResetPath();
        }
    }

    private void ChasePlayer()
    {
        if (agent.isOnNavMesh && agent.isActiveAndEnabled)
        {
            agent.SetDestination(player.position);
        }
    }

    private bool HasLineOfSight()
    {
        if (player == null)
            return false;

        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        // Raycast to check for obstacles
        return !Physics.Raycast(transform.position, direction, distance, obstacleMask);
    }

    private void OnTriggerStay(Collider other)
    {
        // Damage the player via GameManager
        if (other.CompareTag("Player") && Time.time >= lastAttackTime + attackCooldown)
        {
            GameManager.Instance?.TakeDamage(damageAmount);
            lastAttackTime = Time.time;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
