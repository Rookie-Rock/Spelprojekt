using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Kontrollera om det kolliderade objektet �r marken
        if (collision.gameObject.CompareTag("Mark"))
        {
            // Om det �r marken, f�rst�r bara kulan
            Destroy(gameObject);
        }
        else
        {
            // Om det inte �r marken, f�rst�r det kolliderade objektet och kulan
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}