using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject BulletPoint;
    public GameObject bullet;

    public Animator BulletBar;

    public int ammo;
    public bool CanShoot;

    Vector3 cameraInitialPosition;
    public float shakeMagnitude = 0.05f, shakeTime = 0.5f;
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

            rb.AddForce(transform.up * 1000f);
            ammo--;
            BulletBar.SetTrigger("Ammo--");
            Shake();
        }

        if(ammo == 0)
        {
            StartCoroutine(WaitForReload());
            CanShoot = false;
        }
        if(ammo == 5)
        {
            CanShoot = true;
        }
    }

    public IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(1.4f);
        StartCoroutine(AmmoRegenerate());
    }
      public IEnumerator AmmoRegenerate()
      {
        
        while (ammo < 5)
        {
            ammo++;
            BulletBar.SetTrigger("Ammo++");
            yield return new WaitForSeconds(0.7f);
        }
       
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
            ammo++;
            BulletBar.SetTrigger("Ammo++");
            Destroy(collision.gameObject);
        }
    }
}
