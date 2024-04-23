using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StaticData
{
    public class StaticDataService
    {
        private const string UnitDataPath = "StaticData/Units";
        private Dictionary<UnitTypeId, UnitStaticData> _unitData;

        public void Load() => 
            _unitData = Resources
                .LoadAll<UnitStaticData>(UnitDataPath)
                .ToDictionary(key => key.Type, value => value);

        public UnitStaticData ForUnit(UnitTypeId id) => 
            _unitData[id];
    }
}