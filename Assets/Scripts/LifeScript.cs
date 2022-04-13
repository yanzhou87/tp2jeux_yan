using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public float temps = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        temps -= Time.deltaTime;

        if (temps < 0)
        {
            Destroy(gameObject);

        }
    }
}
