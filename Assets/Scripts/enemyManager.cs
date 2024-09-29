using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public float damage;
    public bool isColliderBusy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isColliderBusy)
        {
            other.GetComponent<playerManager>().GetDamage(damage);
            isColliderBusy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isColliderBusy = false;
        }
    }
}
