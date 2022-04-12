using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaisseauTrailleurScript : MonoBehaviour
{
    public Transform player;
    public Vector3 distance;
    public float movementSpeed = 1f;
    // Start is called befothe first frame update
    void Start()
    {
        distance = new Vector3(4f,4f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - player.transform.position.x >= distance.x || transform.position.y - player.transform.position.y >= distance.y)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            transform.LookAt(player);

            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        }
        else
        { 
            transform.position = player.transform.position + distance;
            transform.Translate(transform.position * Time.deltaTime);
        }

        var newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, -9, 9);
        newPos.y = Mathf.Clamp(newPos.y, -5, 5);
        transform.position = newPos;
        Debug.Log(player.transform.position);
        Debug.Log(transform.position);
    }
}
