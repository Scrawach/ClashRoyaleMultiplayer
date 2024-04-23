using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay;
using Gameplay.Units.Stats;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "Unit Static Data", menuName = "Unit Data", order = 0)]
    public class UnitStaticData : ScriptableObject
    {
        [field: SerializeField] public UnitTypeId Type { get; private set; } 
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public UnitStats Stats { get; private set; }
        [field: SerializeField] public List<TeamSkin> Skins { get; private set; }

        public Material SkinForTeam(TeamId id)
        {
            foreach (var teamSkin in Skins.Where(teamSkin => teamSkin.TeamId == id))
                return teamSkin.SkinMaterial;
            throw new ArgumentOutOfRangeException($"Not found skin for {id}");
        }
    }
}