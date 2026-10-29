using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EncounterDirector : MonoBehaviour
{
    [Header("Profiles")]
    [SerializeField] private List<SpawnProfile> spawnProfiles = new();

    [Header("Spawn Points")]
    [SerializeField] private List<EnemySpawnPoint> spawnPoints = new();

    [Header("Difficulty Setting")]
    [SerializeField] private float fastKillThreshold = 10f;
    [SerializeField] private float slowKillThreshold = 30f;
    [SerializeField] private int minDifficultyBonus = -3;
    [SerializeField] private int maxDifficultyBonus = 10;

    private readonly List<GameObject> activeEnemies = new();
    private float encounterStartTime;
    private int difficultyModifier;
    public int CurrentEncounter {get; private set;}
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
            EvaluatePerformance();
            yield return new WaitForSeconds(profile.cooldownAfterClear);
        }
    }

    private void SpawnEncounter(SpawnProfile profile)
    {
        if (profile == null)
        {
            return;
        }

        int enemyCount = Random.Range(profile.minEnemies, profile.maxEnemies +1);
        enemyCount += difficultyModifier;
        enemyCount = Mathf.Max(1, enemyCount);
        Debug.Log($"Encounter: {CurrentEncounter}" + $"Enemies: {enemyCount}" + $"Difficulty Bolus: {difficultyModifier}");

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(profile);
        }
        RefreshTargeting();
    }

    private void SpawnEnemy(SpawnProfile profile)
    {
        
    }

    private void EvaluatePerformance()
    {
        
    }

    private SpawnProfile GetRandomProfile()
    {
        return spawnProfiles[Random.Range(0, spawnProfiles.Count)];
    }

    private void RefreshTargeting()
    {
        
    }
}