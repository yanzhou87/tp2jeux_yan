using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float movementSpeed = 5f;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, movementSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(gameObject); // Detruire le missile
            Instantiate(explosion, other.transform.position, other.transform.rotation); // Creer une explosion

            other.transform.GetComponent<Asteroid>()?.Explode(); // Est equivalent a:
            //var asteroid = other.transform.GetComponent<Asteroid>();
            //if (asteroid != null)
            //    asteroid.Explode();
        }

        if (other.CompareTag("brigand"))
        {
            Destroy(gameObject);
        }
    }
}
