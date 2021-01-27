using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    public float speed = 10;

    private bool hasKey = false;

    private bool canPickUp = false;

    private UnityEngine.Object key;
    private NavMeshAgent agent;


    public Transform shotPrefab;


    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if key
        if (other.tag == "Key")
        {
            key = other.gameObject;
            canPickUp = true;

        }
    }




    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Key")
        {
            canPickUp = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Door" && hasKey)
        {
            hasKey = false;
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        float var = Time.deltaTime * speed;

        transform.Translate(new Vector3((var * horizontalMovement)+ 0.00001f,(var * verticalMovement), 0));

        if(canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            hasKey = true;
            canPickUp = false;
            Destroy(key);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Transform shot = Instantiate(shotPrefab);

            shot.position = transform.position;
            Bullet s = shot.GetComponent<Bullet>();
            s.created();
        }
    }
}
