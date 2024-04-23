using System;
using System.Collections.Generic;
using Factory;
using Gameplay.Common;
using Gameplay.Towers;
using Gameplay.Units;
using StaticData;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private List<Tower> _enemyTowers;
    [SerializeField] private List<Tower> _playerTowers;
    
    private void Awake()
    {
        var enemyTowers = new TowerRegistry(_enemyTowers);
        var playerTowers = new TowerRegistry(_playerTowers);
        var gameRegistry = new GameRegistry(new UnitRegistry(ArraySegment<Unit>.Empty),
            new UnitRegistry(ArraySegment<Unit>.Empty), playerTowers, enemyTowers);
        var staticData = new StaticDataService();
        var gameFactory = new GameFactory(staticData, gameRegistry);
        
        staticData.Load();
        
        var spawnPoints = FindObjectsByType<DebugSpawnPoint>(FindObjectsSortMode.None);

        foreach (var enemyTower in _enemyTowers)
            enemyTower.GetComponent<DestroyTowerAfterDeath>().Construct(enemyTowers);

        foreach (var playerTower in _playerTowers) 
            playerTower.GetComponent<DestroyTowerAfterDeath>().Construct(playerTowers);
        
        foreach (var point in spawnPoints) 
            gameFactory.CreateUnit(point.TypeId, point.TeamId, point.transform.position, point.transform.rotation);
    }
}