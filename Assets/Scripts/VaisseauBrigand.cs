using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaisseauBrigand : MonoBehaviour
{
    public float movementSpeed = 1f , rotationSpeed = 100f;
    public Transform target;
    public GameObject player, asteroid1,asteroid2, effetVB;
    public int life = 3;
    
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {

         target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);
         transform.LookAt(target);
   
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        var newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, -9, 9);
        newPos.y = Mathf.Clamp(newPos.y, -5, 5);
        transform.position = newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid") || other.CompareTag("Missile"))
        {
            if (life > 0)
            {
                life--;
                Destroy(other.gameObject);
            }
            else
            {
                Instantiate(effetVB, gameObject.transform.position, gameObject.transform.rotation); 
               
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
          
                 
            
        }

        if (other.CompareTag("Player"))
        {
            life = 0;
        }
      
    }

}
