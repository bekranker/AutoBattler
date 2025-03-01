using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private NPC _prefab;
    [SerializeField] private List<NPCType> _types = new();
    [SerializeField] private Holder _enemyHolder;
    [SerializeField] private GameManager _gameManager;

    [Button("Spawn")]
    public void SpawnAnEnemy(int count)
    {
        if (_enemyHolder.IsFullBusy) return;
        int randEnemy = Random.Range(0, _types.Count);
        for (int i = 0; i < count; i++)
        {
            NPC spawnedEnemy = Instantiate(_prefab);
            spawnedEnemy.Init(_types[randEnemy], _gameManager, _enemyHolder);
            _enemyHolder.TakeASeat(spawnedEnemy); // Pass the spawned enemy
            if (_enemyHolder.IsFullBusy) return;
        }
    }
}