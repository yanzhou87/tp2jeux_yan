using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaisseauTrailleurScript : MonoBehaviour
{
    public Transform player;
    public Vector3 distance;
    public float movementSpeed = 1f;
    public GameObject missile, tete;
    public float temps = 5f;

    // Start is called befothe first frame update
    void Start()
    {
        distance = new Vector3(3f,3f,0f);
       
    }

    // Update is called once per frame
    /*    void Update()
        {
            if (player != null)
            { 

            temps -= Time.deltaTime;

            if (transform.position.x - player.transform.position.x >= distance.x || transform.position.y - player.transform.position.y >= distance.y)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);

                transform.LookAt(player, new Vector3(transform.position.x, transform.position.y , 0));
                transform.Rotate(0f, -90f , -123f);

                transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed *2f );

            }
            else
            { 
                transform.position = player.transform.position + distance;
                transform.Translate(transform.position * Time.deltaTime * movementSpeed *2f);
            }
                var newPos = transform.position;
                newPos.x = Mathf.Clamp(newPos.x, -9, 9);
                newPos.y = Mathf.Clamp(newPos.y, -5, 5);
                transform.position = newPos;
            }



            var rot = transform.rotation.eulerAngles;
               rot.x = 0;
               rot.y = 0;
            if (temps < 0)
            {
                Instantiate(missile, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(rot));
                temps = 5f;

            }

     }*/

    void Update()
    {
       
        if (player != null) {
            temps -= Time.deltaTime;
            if ((transform.position.x - player.transform.position.x >= distance.x) || (transform.position.y - player.transform.position.y >= distance.y))
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
                transform.LookAt(player, new Vector3(transform.position.x, transform.position.y, 0));
                transform.Rotate(0f, -90f, -123f);
             

            }
          
            var rot = transform.rotation.eulerAngles;
            rot.x = 0;
            rot.y = 0;
            if (temps < 0)
            {
                Instantiate(missile, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(rot));
                temps = 5f;

            }
            var newPos = transform.position;
            newPos.x = Mathf.Clamp(newPos.x, -9, 9);
            newPos.y = Mathf.Clamp(newPos.y, -5, 5);
            transform.position = newPos;
        }
           
    }
}
