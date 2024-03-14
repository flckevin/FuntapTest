using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Spawn info")]
    public float spawnRate; // rate of spawning zombie
    public int spawnAmount; // limitation of avalible zombie
    public ZombieBehaviour zombie; //zombie prefab to spawn and use in pool

    private int _activeZombie;

    float _SpawnRate 
    {

        get { return spawnRate; }

        set 
        {
            if (spawnRate < 0.2f)
            {
                spawnRate = 0.2f;
            }
            else 
            {
                spawnRate = value;
            }
        }
        
    }

    int _CurrentSpawnPos
    {
        get { return _currentSpawnPos; }

        set 
        {
            if (_currentSpawnPos >= GameManager.Instance.spawnPosition.Length - 1)
            {
                _currentSpawnPos = 0;
            }
            else 
            {
                _currentSpawnPos = value;
            }
        
        }
    }

    float time; // spawn rate time
    int _currentSpawnPos = 0; // current spawn position



    private void Start()
    {
        //************ GET ***************************
        PoolExtension.AddPool(zombie, spawnAmount, zombie.name);

        //************ SET ***************************
        EventDispatcherExtension.RegisterListener(EventID.OnzombieDie, (n) => { _activeZombie--; });

        InvokeRepeating("IncreaseRate", 120f, 1);
        InvokeRepeating("Spawn", spawnRate, 1);
    }

    /// <summary>
    /// function to spawn zombie
    /// </summary>
    private void Spawn() 
    {
        if (_activeZombie == spawnAmount) return;
        //get new zombie in list
        ZombieBehaviour _zombie = (ZombieBehaviour)PoolExtension.GetPoolDict(zombie.name);
        //move zombie to position
        _zombie.transform.position = GameManager.Instance.spawnPosition[_currentSpawnPos].position;
        //activate zombie
        _zombie.gameObject.SetActive(true);
        //call on initiate of zombie function
        _zombie.OnInitiate();
        //increase spawn position
        _CurrentSpawnPos++;
        //increase active zombie amount
        _activeZombie++;

    }

    /// <summary>
    /// function to increase difficulty
    /// </summary>
    private void IncreaseRate() 
    {
        //decrease spawn rate so it can spawn faster
        _SpawnRate -= 0.35f;

    
    }
}
