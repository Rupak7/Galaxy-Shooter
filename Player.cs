using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject laserPrefab;

    public float speed = 5.0f;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

        movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (Time.time > nextRate)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.95f, 0), Quaternion.identity);
                nextRate = Time.time + fireRate;
            }
        }
    }

    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.1f)
        {
            transform.position = new Vector3(transform.position.x, -4.1f, 0);
        }

        if (transform.position.x > 6.0f)
        {
            transform.position = new Vector3(6.0f, transform.position.y, 0);
        }
        else if (transform.position.x < -6.3f)
        {
            transform.position = new Vector3(-6.3f, transform.position.y, 0);
        }   

    }
}
 
