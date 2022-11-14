using System.Collections;
using UnityEngine;

//These are the stats of every enemy upon instantiation
public class EnemyStats
{
    public virtual int getDamage()
    {
        return 0;
    }

    public virtual int getHealth()
    {
        return 30;
    }
}

public class EnemyStatsUpgrade : EnemyStats
{
    public EnemyStats wrapee;

    public override int getDamage()
    {
        return wrapee.getDamage();
    }

    public override int getHealth()
    {
        return wrapee.getHealth();
    }
}

public class EnemyStatsUpgradeDamage : EnemyStatsUpgrade
{
    public EnemyStatsUpgradeDamage(EnemyStats wrapee)
    {
        this.wrapee = wrapee;
    }

    public override int getDamage()
    {
        return wrapee.getDamage() + 2;
    }
}

public class EnemyStatsUpgradeHealth : EnemyStatsUpgrade
{
    public EnemyStatsUpgradeHealth(EnemyStats wrapee)
    {
        this.wrapee = wrapee;
    }

    public override int getHealth()
    {
        return wrapee.getHealth() + 5;
    }
}

public abstract class Enemy : MonoBehaviour
{
    //Set default values if data is not set
    protected int health = 50;
    public int damage = 0;
    protected float maxSpeed = 2f;

    protected bool canDealDamage = true;

    [SerializeField]
    protected GameObject counter;

    [SerializeField]
    private AudioClip takingDamage;

    [SerializeField]
    private GameObject brain;

    [SerializeField]
    private AudioClip death;

    virtual protected void OnCollisionStay2D(Collision2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.CompareTag("PLAYER"))
        {
            //Deal Damage to Player if enemy collides with Player GameObject
            if(collider.gameObject.GetComponent<Player>() != null && canDealDamage)
            {
                Vector2 direction = (transform.position - collider.transform.position).normalized;
                gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 1600f, ForceMode2D.Impulse);
                collider.gameObject.GetComponent<Player>().TakeDamage(damage);
                canDealDamage = false;
                StartCoroutine(damageCooldown());
            }
            //Debug.Log("Player health: " + collider.GetComponent<Player>().health);
        }
    }

    virtual protected IEnumerator damageCooldown()
    {
        yield return new WaitForSeconds(1f);
        canDealDamage = true;
    }

    virtual public int takeDamage(int playerDamage)
    {
        health = health - playerDamage;
        Debug.Log("Enemy health: " + health);
        AudioManager.Instance.PlaySound(takingDamage);

        if (health <= 0)
        {
            AudioManager.Instance.PlaySound(death);
            GameObject newObj = Instantiate(brain, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            Destroy(gameObject);
            counter.GetComponent<SpawnScript>().enemiesRemaining--;
            Debug.Log("Enemies remaining: " + counter.GetComponent<SpawnScript>().enemiesRemaining);
        }

        return health;
    }

    public virtual int getHealth()
    {
        return health;
    }

    public virtual int getDamage()
    {
        return damage;
    }
}
