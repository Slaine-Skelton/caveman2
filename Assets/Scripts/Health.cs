using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth = 100;

    public void Add(int amount)
    {
        currentHealth += amount;
    }

    public void Subtract(int amount)
    {
        currentHealth += amount;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
