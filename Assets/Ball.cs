using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed;
    public float lifeTime;

    public GameObject explosion;

    public int damage;

	private void Start ()
    {
        Invoke("DestroyBall", lifeTime);
		
	}
	
	private void Update ()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
		
	}

    void DestroyBall()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            DestroyBall();
        }

        if (collision.tag == "boss")
        {
            collision.GetComponent<Boss>().TakeDamage(damage);
            DestroyBall();
        }

    }
}
