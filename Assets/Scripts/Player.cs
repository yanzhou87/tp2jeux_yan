using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f, rotationSpeed = 150f;

    public GameObject missile, canon;
    public GameObject explosion, effetVB, effetPlayer, lifeObject;
    public float createLife = 10f;
    public int life = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Rotate(0, 0, -rotation * Time.deltaTime);

        float translation = Input.GetAxis("Vertical") * movementSpeed;
        transform.Translate(0, translation*Time.deltaTime, 0, Space.Self);

        var newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, -9, 9);
        newPos.y = Mathf.Clamp(newPos.y, -5, 5);
        transform.position = newPos;

        if (Input.GetKeyDown("space"))
        {
            Instantiate(missile, canon.transform.position, canon.transform.rotation);
        }

        createLife -= Time.deltaTime;

        if (createLife < 0)
        {
            Instantiate(lifeObject, transform.position + new Vector3(3f,3f, 0f), transform.rotation);
            createLife = 10f;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Instantiate(explosion, other.transform.position, other.transform.rotation);
        if (other.CompareTag("brigand"))
        {
            Instantiate(effetVB, other.transform.position, other.transform.rotation);
            Instantiate(effetPlayer, gameObject.transform.position, gameObject.transform.rotation);
            life--;
            if (life == 0) { Destroy(gameObject); }
            Debug.Log(life);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("life"))
        {
            life++;
            Destroy(other.gameObject);
        }
           
    }

}
