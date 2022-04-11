using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaisseauBrigand : MonoBehaviour
{
    public float movementSpeed = 1f , rotationSpeed = 100f;
    public Transform target;
    public GameObject player, asteroid1,asteroid2;
    public int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        
       // rotationSpeed = player.rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {

         target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 0);
         transform.LookAt(target);
   
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

     //   var newPos = transform.position;
      //  newPos.x = Mathf.Clamp(newPos.x, -9, 9);
      //  newPos.y = Mathf.Clamp(newPos.y, -5, 5);
       // transform.position = newPos;

        if (Mathf.Abs(transform.position.x) > 9f)
        {
            var newPos = transform.position;
            newPos.x = -transform.position.x;
            transform.position = newPos;
        }
        if (Mathf.Abs(transform.position.y) > 5f)
        {
            var newPos = transform.position;
            newPos.y = -transform.position.y;
            transform.position = newPos;
        }
        Debug.Log(life) ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid") || other.CompareTag("Missile") || other.CompareTag("Player"))
        {
            if (life != 0)
            {
                life--;
                Destroy(other.gameObject);
            }
            else
            { 
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
      
    }

}
