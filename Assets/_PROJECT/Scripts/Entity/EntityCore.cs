using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCore : MonoBehaviour
{
    public EntityStats entityStats; //stats of zombie
    public SpriteRenderer _sprite;
    protected float _health; //current health of zombie
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        //*************** GET **************************
        
        //*************** SET **************************
        //set entity health
        _health = entityStats.health;
    }

    public void DealDamage(int _damage)
    {
        //decrease health
        _health -= _damage;
        //flash red
        StartCoroutine(FlashRed());
        //if health reached to 0
        if (_health <= 0)
        {
            //deactivate gameobject
            this.gameObject.SetActive(false);
            OnDeath();
        }

    }

    public virtual void OnDeath() { }
    public virtual void OnInitiate() { }

    /// <summary>
    /// function to flash red
    /// </summary>
    /// <returns></returns>
    protected IEnumerator FlashRed() 
    {
        if (_sprite == null) yield return null;
        //change to red
        _sprite.color = Color.red;
        //wait for few sec
        yield return new WaitForSeconds(0.1f);
        //change to white
        _sprite.color = Color.white;
    }
}
