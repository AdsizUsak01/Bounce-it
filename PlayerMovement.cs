using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed;
    public GameObject Bullet;
    public GameObject BulletSpawnPoint;
    Rigidbody2D rb;
    public int ammo;
    private int currentAmmo;
    // public TextMeshProUGUI ammoText;
    public AudioSource auidoShoot;
    private GameObject[] bullets;
    BulletManager bulletManager;
    public GameObject DeathScreen;
    private GameObject[] Enemy;
    private GameObject WinScreenScene;
    private GameObject LoseScreenScene;
    public bool BulletOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentAmmo = ammo;
        bulletManager = GameObject.FindGameObjectWithTag("BulletManager").GetComponent<BulletManager>();
        bulletManager.DisplayBullets(ammo);
        LoseScreenScene = GameObject.FindGameObjectWithTag("EndGame");
        WinScreenScene = GameObject.FindGameObjectWithTag("WinGame");

        LoseScreenScene.SetActive(false);
        WinScreenScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(BulletOnScreen);  
        if (currentAmmo <= 0 && !BulletOnScreen)
        {
            LoseScreenScene.SetActive(true);
        }

        Movement();

        if (currentAmmo > 0 && Input.GetMouseButtonDown(0) && !BulletOnScreen)
        {
            ShootBullet();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }
    }



    private void ShootBullet()
    {
        BulletOnScreen = true;
        auidoShoot.Play();
        Instantiate(Bullet, BulletSpawnPoint.transform.position, Quaternion.identity);
        currentAmmo--;
        bulletManager.DeleteBullets();
    }

    //private void DisplayAmmo()
    //{
    //ammoText.text = currentAmmo.ToString();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DeathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void Movement()
    {
        float movement = Input.GetAxis("Horizontal");

        Vector2 moveVector = new Vector2(movement * PlayerSpeed, 0);
        rb.velocity = moveVector;
    }
}
