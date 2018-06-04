using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private GameObject _laserPrefab;

    public bool canTriple = false;

    private float fireRate = 0.25f;
    private float nextRate = 0.0f;

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
            shoot();
        }
    }

    private void shoot()
    {
        if (Time.time > nextRate)
        {
            if (canTriple == true)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.95f, 0), Quaternion.identity);
                Instantiate(_laserPrefab, transform.position + new Vector3(-0.55f, -0.03f, 0), Quaternion.identity);
                Instantiate(_laserPrefab, transform.position + new Vector3(0.57f, -0.04f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.95f, 0), Quaternion.identity);
            }
            nextRate = Time.time + fireRate;
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
 
