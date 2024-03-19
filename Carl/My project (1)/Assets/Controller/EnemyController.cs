using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Enemy Stats
    public int attackDamage = 20;
    public int armor = 0;

    // Detection and Movement
    public float lookRadius = 10f;
    public float attackCooldown = 2f; // Cooldown duration in seconds
    private float nextAttackTime = 0f; // Time when the enemy can attack again
    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // Attack target if cooldown is over
                if (Time.time >= nextAttackTime)
                {
                    FaceTarget();
                    Attack();
                    nextAttackTime = Time.time + attackCooldown; // Set next attack time
                }
            }
        }
    }

    void Attack()
    {
        // Ensure the player object has a CharacterStats component
        CharacterStats playerStats = target.GetComponent<CharacterStats>();

        if (playerStats != null)
        {
            // Deal damage to the player
            int damageDealt = attackDamage - playerStats.armor;
            damageDealt = Mathf.Clamp(damageDealt, 0, int.MaxValue);
            playerStats.TakeDamage(damageDealt);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

