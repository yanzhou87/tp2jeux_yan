using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f, rotationSpeed = 150f;
    public GameObject missile, canon;
    public GameObject explosion, effetVB, effetPlayer, lifeObject, over, ast, ast1;
    public float createLife;
    public int life = 1;
    public float tempsMax;
    Collider lastOther;
    private bool estFini = false;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EndGame", tempsMax);
        InvokeRepeating("CreateLife", createLife, createLife);
        Invoke("Recommence",tempsMax + 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
      
        Debug.Log(estFini);
        tempsMax -= Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Rotate(0, 0, -rotation * Time.deltaTime);

        float translation = Input.GetAxis("Vertical") * movementSpeed;
        transform.Translate(0, translation*Time.deltaTime, 0, Space.Self);

        var newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, -9, 9);
        newPos.y = Mathf.Clamp(newPos.y, -5, 5);
        newPos.z = 0;
        transform.position = newPos;

        if (Input.GetKeyDown("space"))
        {
            Instantiate(missile, canon.transform.position, canon.transform.rotation);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != lastOther)
        {
            lastOther = other;

            //Instantiate(explosion, other.transform.position, other.transform.rotation);
            if (other.CompareTag("brigand"))
            {
                Instantiate(effetVB, other.transform.position, other.transform.rotation);
                life--;
                Destroy(other.gameObject);
            }
            if (other.CompareTag("life"))
            {
                life++;
                Destroy(other.gameObject);
            }

            if (other.CompareTag("MissileRose"))
            {
                life--;
            }

            if (life == 0)
            {
                Instantiate(effetPlayer, gameObject.transform.position, gameObject.transform.rotation);
                Instantiate(over, new Vector3(0f, 0f, 0f), transform.rotation);
                Invoke("Recommence", 3.0f);
            }
        }
    }
    private void EndGame()
    {
        Instantiate(over, new Vector3(0f, 0f, 0f), transform.rotation);
        Destroy(gameObject);
        
    }

    private void Recommence()
    {
        
        SceneManager.LoadScene("MenuScene");
        Destroy(gameObject);
    }

    private void CreateLife()
    {
        Instantiate(lifeObject, transform.position + new Vector3(3f, 3f, 0f), transform.rotation);
    }

}
