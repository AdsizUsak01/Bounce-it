using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject WholeTank;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateToMouse();
    }

    private void RotateToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        direction.z = 0;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (direction.x < 0)
        {
            WholeTank.transform.rotation = Quaternion.Euler(0, 180f, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        {
            WholeTank.transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
