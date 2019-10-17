using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{

    public static LevelSystem instance;

    public int XP;
    public int currentLevel;

    PlayerHealth playerHealth;


    public GameObject levelUpEffect;

    [SerializeField]
    private Transform leveleffectTranform;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateXP(0);
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateXP(int exp)
    {
        XP += exp;
        int ourLvl = (int)(0.1f * Mathf.Sqrt(XP));

        if (ourLvl != currentLevel)
        {
            currentLevel = ourLvl;
            //you have leveled up
            Debug.Log("You have leveld up");
            playerHealth.MaxHealth += .25f;
            playerHealth.currentHealth = playerHealth.MaxHealth;
            playerHealth.playerHealthSlider.value = playerHealth.currentHealth;

            Instantiate(levelUpEffect, leveleffectTranform.position, leveleffectTranform.rotation);

            //Destroy(levelUpEffect, 1f);

            int xpNxtLevel = 100 * (currentLevel + 1) * (currentLevel + 1);
            int differenceXp = xpNxtLevel - XP;

            int totalDifference = xpNxtLevel - (100 * currentLevel * currentLevel);
        }
    }
}
