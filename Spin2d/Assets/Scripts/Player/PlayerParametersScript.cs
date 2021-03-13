using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParametersScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    float damageTime = 1.0f;
    float currentDamageTime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
          if (collision.gameObject.tag == "E2_Bullet")
        {
            currentHealth -= 10;
            healthBar.SetHealth(currentHealth);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {

            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                currentHealth -= 5;
                healthBar.SetHealth(currentHealth);
                currentDamageTime = 0.0f;
            }
        }
    }
}
