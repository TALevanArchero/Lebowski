using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;

    public int healthPickupChance;
    public GameObject healthPickup;

    public GameObject deathEffect;

    [HideInInspector]
    public Transform player;

    Animator cameraAnim;


    public float timeBetweenAttacks;

    public int damage;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cameraAnim = Camera.main.GetComponent<Animator>();
    }


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            int randHealth = Random.Range(0, 101);
            if (randHealth < healthPickupChance)
            {
                Instantiate(healthPickup, transform.position, transform.rotation);
            }
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
            cameraAnim.SetTrigger("shake");
        }
     
    }
}
