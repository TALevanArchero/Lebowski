using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesusEnemy : Enemy {

    public float stopDistance;

    private float timer;

    public float jesusAttackSpeed;

    private void Update()
    {
        if(player != null)
        {

            if(Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed *Time.deltaTime);
            }
            else
            {
                if(Time.time >= timer)
                {
                    StartCoroutine(JesusAttack());
                    timer = Time.time + timeBetweenAttacks;
                }
            }
        }
    }

    IEnumerator JesusAttack()
    {
        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0;
        while(percent <= 1)
        {
            percent += Time.deltaTime * jesusAttackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
         
        }
    }
}
