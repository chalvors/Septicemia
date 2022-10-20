using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_Door_A : MonoBehaviour
{
    private Collider2D door;

    void Start()
    {
        door = gameObject.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            SceneManager.LoadScene("Matias Stress Test B");
        }
    }
}