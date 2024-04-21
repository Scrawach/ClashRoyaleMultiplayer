using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerRegistry
{
    private readonly List<Tower> _towers;

    public TowerRegistry(IEnumerable<Tower> towers) => 
        _towers = towers.ToList();

    public void Add(Tower tower) => 
        _towers.Add(tower);

    public bool TryGetNearestTower(Vector3 position, out Tower nearestTower)
    {
        var minDistance = float.MaxValue;
        nearestTower = null;
        
        foreach (var tower in _towers)
        {
            var distance = Vector3.Distance(tower.transform.position, position);
            
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestTower = tower;
            }
        }

        return nearestTower != null;
    }
}