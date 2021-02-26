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
            StartCoroutine(AmmoRegenerate());
            CanShoot = false;
        }
        if(ammo == 5)
        {
            CanShoot = true;
        }
    }

    public IEnumerator AmmoRegenerate()
    {
        if(ammo < 5)
        {
            yield return new WaitForSeconds(0.4f);
            ammo = 1;
            BulletBar.Play("Health1");
            yield return new WaitForSeconds(0.4f);
            ammo = 2;
            BulletBar.Play("Health2");
            yield return new WaitForSeconds(0.4f);
            ammo = 3;
            BulletBar.Play("Health3");
            yield return new WaitForSeconds(0.4f);
            ammo = 4;
            BulletBar.Play("Health4");
            yield return new WaitForSeconds(0.4f);
            ammo = 5;
            BulletBar.Play("HealthFull");
            

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
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
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
}
