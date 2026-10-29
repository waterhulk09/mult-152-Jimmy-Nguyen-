using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "SpawnProfile", menuName = "Scriptable Objects/SpawnProfile")]
public class SpawnProfile : ScriptableObject
{
    public string profileName;
    [Header("Enemy types")]

    public List<EnemyType> enemyTypes;

    public int minEnemies = 1;

    public int maxEnemies = 5;

    [Header("timing")]

    public float cooldownAfterClear = 10f;
}
