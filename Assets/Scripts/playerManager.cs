using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public float health;
    public bool isDead;

    public void GetDamage(float damage)
    {
        if((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }

        AmIDead();
    }

    public void AmIDead()
    {
        if(health <= 0)
        {
            isDead = true;
        }
    }
}
