using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<VillainAI>())
        {
            other.GetComponentInChildren<VillainHealth>().TakeDamageVillain(20);
            Debug.Log("Enemy is hit");
        }
    }
}
