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
        var enemyUnits = new UnitRegistry(ArraySegment<Unit>.Empty);
        var playerUnits = new UnitRegistry(ArraySegment<Unit>.Empty);
        var gameRegistry = new GameRegistry(playerUnits, enemyUnits, playerTowers, enemyTowers);
        var staticData = new StaticDataService();
        var gameFactory = new GameFactory(staticData, gameRegistry);
        
        staticData.Load();
        
        foreach (var enemyTower in _enemyTowers)
            enemyTower.GetComponent<DestroyTowerAfterDeath>().Construct(enemyTowers);

        foreach (var playerTower in _playerTowers) 
            playerTower.GetComponent<DestroyTowerAfterDeath>().Construct(playerTowers);
        
        foreach (var point in SpawnPointsOnLevel()) 
            gameFactory.CreateUnit(point.TypeId, point.TeamId, point.transform.position, point.transform.rotation);
    }

    private static IEnumerable<DebugSpawnPoint> SpawnPointsOnLevel() => 
        FindObjectsByType<DebugSpawnPoint>(FindObjectsSortMode.None);
}