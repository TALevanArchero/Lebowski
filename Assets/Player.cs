using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
    private Animator anim;

    public int health;

    public Image[] cups;
    public Sprite fullCup;
    public Sprite emptyCup;

    public Animator hurtAnim;

    private SceneTransition sceneTransition;
    private Vector2 moveAmount;
	
	private void Start()
	{
        anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
        sceneTransition = FindObjectOfType<SceneTransition>();
    }
	
	private void Update()
	{
		Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveAmount = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
	}
	
	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
	}

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("hurt");

        if (health <= 0)
        {
            Destroy(gameObject);
            sceneTransition.LoadScene("Lose");
        }

    }

    void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < cups.Length; i++)
        {
            if (i < currentHealth)
            {
                cups[i].sprite = fullCup;
            } else
            {
                cups[i].sprite = emptyCup;
            }
        }
    }

    public void Heal(int healAmount)
    {
        if (health +healAmount > 5)
        {
            health = 5;
        } else
        {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }

}
