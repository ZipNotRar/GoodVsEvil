using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HeroHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public HeroHealth healthBarHero;

    public Slider slider;
    private Object explosionRef;

    void FixedUpdate()
    {
        if (currentHP <= 0)
        {
            GameOver();
        }
    }
    void Start()
    {
        currentHP = maxHP;
        healthBarHero.setMaxHealth(maxHP);


        explosionRef = Resources.Load("Explosion");
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
    public void TakeDamage(int Damage)
    {
        currentHP -= Damage;
        healthBarHero.setHealth(currentHP);
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Initiate Gameover");
    }
}