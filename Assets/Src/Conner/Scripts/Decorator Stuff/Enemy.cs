using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //Set default values if data is not set
    protected int health = 100;
    protected int damage = 0;
    protected float maxSpeed = 2f;

    protected bool canDealDamage = true;

    [SerializeField]
    protected GameObject counter;

    [SerializeField]
    private AudioClip takeDamage;

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
                //TakeDamage(collider.GetComponent<Player>().attackstat);
                canDealDamage = false;
                StartCoroutine(DamageCooldown());
            }
            //Debug.Log("Player health: " + collider.GetComponent<Player>().health);
        }
    }

    virtual protected IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(1f);
        canDealDamage = true;
    }

    virtual public int TakeDamage(int playerDamage)
    {
        health = health - playerDamage;
        Debug.Log("Enemy health: " + health);
        AudioManager.Instance.PlaySound(takeDamage);

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

    public virtual int GetHealth()
    {
        return health;
    }

    public virtual int GetDamage()
    {
        return damage;
    }
}
