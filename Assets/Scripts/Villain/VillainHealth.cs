using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VillainHealth : MonoBehaviour
{
    public int maxHPVillain = 100;
    public int currentHPVillain;

    public VillainHealth healthBarVillain;

    public Slider slider;

    void FixedUpdate()
    {
        if (currentHPVillain <= 0)
        {
            villainDeath();
        }
    }
    void Start()
    {
        currentHPVillain = maxHPVillain;
        healthBarVillain.setMaxHealth(maxHPVillain);
    }
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void setHealth(int health)
    {
        slider.value = health;

    }
    public void TakeDamageVillain(int villainDamage)
    {
        currentHPVillain -= villainDamage;
        healthBarVillain.setHealth(currentHPVillain);
    }
    public void villainDeath()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Initiate villain Gameover");
    }
}