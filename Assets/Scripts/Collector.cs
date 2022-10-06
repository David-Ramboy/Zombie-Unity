using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject);

        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {

            Destroy(collision.gameObject);

        }

    }
}
