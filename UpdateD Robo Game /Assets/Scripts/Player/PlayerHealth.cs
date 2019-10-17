using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth instance;

    public float MaxHealth;
    public float currentHealth;

    public Image damageScreen;

    public Slider playerHealthSlider;

    PlayerController myPC;
    private bool isDamaged = false;

    Color damageColor = new Color(0f, 0f, 0f, .7f);

    float smoothColor = 5f;

    public GameObject damagePopUpText;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        playerHealthSlider.maxValue = MaxHealth;
        playerHealthSlider.value = currentHealth;

        myPC = GetComponent<PlayerController>();

        isDamaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDamaged)
        {
            damageScreen.color = damageColor;
        }
        else 
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor*Time.deltaTime);
        }
        isDamaged = false;
    }

    public void AddDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        isDamaged = true;

        if(currentHealth<=0)
        {
            MakeDead();
        }

    }

    public void MakeDead()
    {
        Destroy(gameObject, 1.1f);
    }
}
