using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaisseauBrigand : MonoBehaviour
{
    public float movementSpeed = 5f , rotationSpeed = 150f;
    public Transform target;
    public GameObject player, asteroid1,asteroid2;
    // Start is called before the first frame update
    void Start()
    {
        
       // rotationSpeed = player.rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
       target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);    
       transform.LookAt(target);
       transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }
}