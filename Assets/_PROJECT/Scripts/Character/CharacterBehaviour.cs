using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : EntityCore
{

    public override void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player touched a zombie
        if (collision.CompareTag("Zombie")) 
        {
            //deal damage
            DealDamage(1);
            //disable a health bar
            GameManager.Instance.healthUI[(int)_health].enabled = false;
            //deactivate that zombie
            collision.gameObject.SetActive(false);
        }
    }

    public override void OnDeath()
    {
        GameManager.Instance.menuManager.Restart();
        base.OnDeath();
    }
}
