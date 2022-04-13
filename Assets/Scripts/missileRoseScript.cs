using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileRoseScript : MonoBehaviour
{
    public GameObject missileRoseEffet;
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
        if (other.CompareTag("Asteroid"))
        {
            Instantiate(missileRoseEffet,other.transform.position, other.transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(missileRoseEffet, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
           
        }

    }
}
