using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject ball;
    public Transform shotPoint;
    public float timeBetweenShots;

    //Animator cameraAnim;

    private float shotTime;
    /*
    private void Start()
    {
        cameraAnim = Camera.main.GetComponent<Animator>();
    }*/


    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        if (Input.GetMouseButton(0))
        {
            if( Time.time >= shotTime)
            {
                Instantiate(ball, shotPoint.position, transform.rotation);
                //cameraAnim.SetTrigger("shake");
                shotTime = Time.time + timeBetweenShots;
            }
        }
	}
}
