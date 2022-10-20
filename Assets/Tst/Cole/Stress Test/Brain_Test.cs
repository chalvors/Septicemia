using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_Test : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "PLAYER") {
            Game_Manager_Test.collectedCounter++;

            Destroy(gameObject);
        }
    }
}
