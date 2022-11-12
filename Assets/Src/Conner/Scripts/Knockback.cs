using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float strength = 16, delay = 0.15f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    //Calculates the direction to push the enemy
    public void PlayFeedback(GameObject sender)
    {
        //Normalized so that it can be called by the Rigidbody
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * strength, (ForceMode)ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
    }
}
