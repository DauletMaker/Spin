using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject BulletPoint;
    public GameObject bullet;

    

    public int ammo;
    public bool CanShoot;

    Vector3 cameraInitialPosition;
    public float shakeMagnitude = 0.04f, shakeTime = 0.5f;
    public Camera mainCamera;

    void Start()
    {
        ammo = 5;
        CanShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && ammo > 0 && CanShoot == true)
        {
            Instantiate(bullet, BulletPoint.transform.position, BulletPoint.transform.rotation);
            Debug.Log("tRUBI");

            rb.AddForce(transform.up * 1500f);
            
                ammo--;
            
           
          
            Shake();
        }

        if(ammo == 0)
        {
          
            CanShoot = false;
            ammo = 5;
            StartCoroutine(AmmoRegenerate());
        }
       
        if(ammo > 5)
        {
            ammo = 5;
        }

        
      
    }

      public IEnumerator AmmoRegenerate()
      {

        yield return new WaitForSeconds(1.8f);
       
        CanShoot = true;
       
      }

    public void Shake()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);

    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 3.1f - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 3.1f - shakeMagnitude;
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;
        cameraIntermediatePosition.x += cameraShakingOffsetX;
        cameraIntermediatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermediatePosition;

    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ammo_Dropped")
        {
            if(ammo < 5)
            {
                ammo++;
            }
            
            Destroy(collision.gameObject);
        }
    }
}
