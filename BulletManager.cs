using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject[] bulletImages;
    PlayerMovement playerMovement;
    private int ammo;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        ammo = playerMovement.ammo - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayBullets(int ammoToDisplay)
    {
        for (int i = 0; i < ammoToDisplay; i++)
        {
            bulletImages[i].SetActive(true);
        }
    }
    
    public void DeleteBullets()
    {
        Destroy(bulletImages[ammo].gameObject);
        ammo--;
    }
}
