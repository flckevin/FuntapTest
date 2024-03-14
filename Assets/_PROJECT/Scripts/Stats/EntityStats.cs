using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "ScriptableObjects/EntityStats")]
public class EntityStats : ScriptableObject
{
    public float health;
    public float speed;
}
