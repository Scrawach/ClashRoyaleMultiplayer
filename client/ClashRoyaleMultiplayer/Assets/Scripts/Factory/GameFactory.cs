using Gameplay;
using Gameplay.Common;
using Gameplay.Units;
using Gameplay.Units.AI;
using Gameplay.Units.Attacks;
using Gameplay.Units.Components;
using StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Factory
{
    public class GameFactory
    {
        private readonly StaticDataService _staticData;
        private readonly GameRegistry _gameRegistry;

        public GameFactory(StaticDataService staticData, GameRegistry gameRegistry)
        {
            _staticData = staticData;
            _gameRegistry = gameRegistry;
        }

        public Unit CreateUnit(UnitTypeId typeId, TeamId teamId, Vector3 position, Quaternion rotation = default)
        {
            var data = _staticData.ForUnit(typeId);
            var stats = data.Stats;
            var unit = Object.Instantiate(data.Prefab, position, rotation).GetComponent<Unit>();
            var (enemyUnits, enemyTowers) = _gameRegistry.ForEnemy(teamId);
            var (playerUnits, playerTowers) = _gameRegistry.For(teamId);
        
            unit.Construct(enemyTowers, enemyUnits);
            unit.GetComponent<UnitMovement>().SetSpeed(stats.Speed);
            unit.GetComponent<UnitAttack>().Construct(stats.ModelSize, stats.AttackDamage, stats.AttackCooldownInSeconds, 
                stats.AttackRange, stats.AttackAnimationInfo);
            unit.GetComponent<Health>().Construct(stats.Health);
            unit.GetComponent<DestroyUnitAfterDeath>().Construct(playerUnits);
            unit.GetComponent<NavMeshAgent>().stoppingDistance = stats.ModelSize + stats.AttackRange.Min;
            unit.IsFlying = data.Stats.IsFlying;
            
            if (unit.TryGetComponent(out UnitSkinSwitcher skinSwitcher))
                skinSwitcher.SwitchSkin(data.SkinForTeam(teamId));
            
            InitializeAI(unit);
            
            playerUnits.Add(unit);
            return unit;
        }

        private static void InitializeAI(Unit unit)
        {
            var stateMachine = new UnitStateMachine(unit);
            unit.GetComponent<UnitAI>().Construct(stateMachine);
        }
    }
}