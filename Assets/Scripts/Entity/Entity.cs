using UnityEngine;
public abstract class Entity : MonoBehaviour, IDamageable
{
    public int life;
    public int damageAttack;
    public int visionRange;
    public int actionRange;
    public float rotationSpeed;
    public Vector3 directionTarget;
    public Transform Player;
    public LayerMask detectableLayers;

    public AttackDelegate OnAttack; // Delegate para manejar ataques

    public delegate void AttackDelegate();
    protected virtual void Start()
    {
        // Cada enemigo asignar� su propio ataque en su clase espec�fica
    }

    protected virtual void Update()
    {
        bool playerInRange = Vector3.Distance(transform.position, Player.position) < visionRange;

        if (playerInRange)
        {
            LookPlayer(); // Mira al jugador
        }
    }

    public virtual void LookPlayer()
    {
        Vector3 directionToPlayer = (Player.position - transform.position).normalized;
        directionToPlayer.y = 0;

        Quaternion desiredRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
