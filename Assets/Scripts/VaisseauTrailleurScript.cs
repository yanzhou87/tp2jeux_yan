using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VaisseauTrailleurScript : MonoBehaviour
{
    public Transform player;
    public Vector3 distance;
    public float movementSpeed = 1f;
    public GameObject missile, tete;

    // Start is called befothe first frame update
    void Start()
    {
        distance = new Vector3(3f,3f,0f);
        InvokeRepeating("createMissile", 5, 5);

    }

    // Update is called once per frame
   
    void Update()
    {
       
        if (player != null) {
            if (transform.position.x - player.transform.position.x >= distance.x || transform.position.y - player.transform.position.y >= distance.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
                transform.LookAt(player, new Vector3(transform.position.x, transform.position.y, 0));
                transform.Rotate(0f, -90f, -123f);
            }
            if (transform.position.x - player.transform.position.x <= distance.x || transform.position.y - player.transform.position.y <= distance.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position + ( distance - player.position), movementSpeed * Time.deltaTime);
                transform.LookAt(player, new Vector3(transform.position.x, transform.position.y, 0));
                transform.Rotate(0f, -90f, -123f);
            }
            else
            {
                transform.LookAt(player, new Vector3(transform.position.x, transform.position.y, 0));
                transform.Rotate(0f, -90f, -123f);
            }

            var newPos = transform.position;
            newPos.x = Mathf.Clamp(newPos.x, -9, 9);
            newPos.y = Mathf.Clamp(newPos.y, -5, 5);
            transform.position = newPos;
        }
           
    }
    void createMissile()
    {
        Vector3 direction = transform.position - player.position;
        direction.z = 0;
        var rot = transform.rotation.eulerAngles;
        rot.x = 0;
        rot.y = 0;
        var nouveauMissille =
        Instantiate(missile, new Vector3(transform.position.x, transform.position.y, 0),  Quaternion.LookRotation(direction));
        
        nouveauMissille.transform.LookAt(player.position, Vector3.up);
        nouveauMissille.transform.Rotate(90f, 0,0f);
    }
} 


