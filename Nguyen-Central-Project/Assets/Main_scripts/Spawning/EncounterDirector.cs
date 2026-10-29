using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
public class EncounterDirector : MonoBehaviour
{
   
    [Header("Profiles")]
    [SerializeField] private List<SpawnProfile> spawnProfiles = new();
    
    [Header("SpawnPoint")]
     [SerializeField] private List<EnemySpawnPoint> spawnPoints = new();
    
    [Header("Difficulty settings")]
     [SerializeField] private float fastKillThreshold = 10f;
     [SerializeField] private float slowKillThreshold = 30f;
     [SerializeField] private int minDifficultyBonus = -3;
     [SerializeField] private int maxDifficultyBonus = 10;

private readonly List<GameObject> activeEnemies = new();
private float encounterStartTime;
private int difficultyModifier;
public int Current {get; private set;}
public int AliveEnemies => activeEnemies.Count;

private void Start()
    {
        
    }

    private IEnumerator EncounterRoutine()
    {
        while (true)
        {
            CurrentEncounter++;
            SpawnProfile profile = GetRandomProfile();
            SpawnEncounter(profile);
            encounterStartTime = Time.time;
           yield return new WaitUntil(() => activeEnemies.Count == 0);
            EvaluatePreformance();
            yield return new WaitForSeconds(ProfiledSegment.cooldownAfterClear);
        }
    }

    private void SpawnEncounter()
    {
        if (profile == null)
        {
            return;
        }

        int enemyCount = Random.Range(ProfiledSegment.minEnemies, profile.maxEnemies +1 );
        enemyCount += difficultyModifier;
        enemyCount = Mathf.Max(1, enemyCount);

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(profile);

        }
        RefreshTargeting();
    }

}
