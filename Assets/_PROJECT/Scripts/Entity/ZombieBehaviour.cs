using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class ZombieBehaviour : EntityCore
{
    // Start is called before the first frame update

    public GameObject zombieGraphic;
    
    // Update is called once per frame
    void Update()
    {
        //make zombie look directly to the player
        zombieGraphic.transform.up = (Vector2)GameManager.Instance.player.transform.position - (Vector2)this.transform.position;
        //move toward to player
        transform.position = Vector3.MoveTowards(this.transform.position, GameManager.Instance.player.transform.position, entityStats.speed * Time.deltaTime);
    }

    public override void OnInitiate()
    {
        _health = entityStats.health;
        _sprite.color = Color.white;
        base.OnInitiate();
    }

    public override void OnDeath()
    {
        base.OnDeath();
        EventDispatcherExtension.FireEvent(EventID.OnzombieDie);
        GameManager.Instance.CurrentHighScore++;
        GameManager.Instance.scoreUI.text = GameManager.Instance.CurrentHighScore.ToString();
    }

}
