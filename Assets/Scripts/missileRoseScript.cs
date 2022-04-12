using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileRoseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 2f * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid") || other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
