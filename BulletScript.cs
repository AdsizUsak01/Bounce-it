using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    private Vector2 direction;
    public int life = 20;
    Rigidbody2D rb;
    public AudioSource audioBounce;
    public SceneLoader sceneLoader;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        audioBounce = GameObject.FindGameObjectWithTag("ShootSFX").GetComponent<AudioSource>();
        sceneLoader = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneLoader>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        CalculateDirection();
        RotateBullet();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    private void OnBecameInvisible()
    {
        playerMovement.BulletOnScreen = false;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        life--;
        if (life <= 0)
        {
            Destroy(gameObject);
            return;
        }

        direction = Vector2.Reflect(direction, collision.contacts[0].normal);

        rb.velocity = bulletSpeed * direction;
        audioBounce.Play(); 
        RotateBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Debug.Log("You Lose");
            // Destroy(collision.gameObject);
            playerMovement.BulletOnScreen = false;
            sceneLoader.LoseScreen();
            Destroy(gameObject);
            return;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            playerMovement.BulletOnScreen = false;
            // Debug.Log("You Win!");
            sceneLoader.WinScreen();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }
    }

    private void CalculateDirection()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        // Calculate direction
        direction = (mouseWorldPosition - transform.position).normalized;

        // Set initial velocity
        rb.velocity = bulletSpeed * direction;
    }

    private void RotateBullet()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void MoveBullet()
    {
        // Ensure the bullet continues to move in the same direction
        rb.velocity = bulletSpeed * direction;
    }
}
