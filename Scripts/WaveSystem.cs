using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [Header("---Components")]
    [SerializeField] private Spawner _enemySpawner;
    [Header("---Props")]
    [SerializeField] private List<WaveType> _waves = new();
    [SerializeField] private List<PackType> _packs = new();
    //    [Header("---UI")]

    private int _waveIndex;


    public void Initialize()
    {
        _waveIndex = SaveManager.GetWave();
    }
    public void NextWave()
    {

    }
}