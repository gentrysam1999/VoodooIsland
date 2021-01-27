using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    private float healthPoint;
    [SerializeField] private float maxHealthPoint;

    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        healthPoint = maxHealthPoint;
        sp = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            healthPoint -= 10;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(healthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
