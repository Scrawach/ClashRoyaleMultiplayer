using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Units
{
    public class UnitSkinSwitcher : MonoBehaviour
    {
        [SerializeField] private List<Renderer> _renderers;
        
        public void SwitchSkin(Material target)
        {
            foreach (var meshRenderer in _renderers) 
                meshRenderer.material = target;
        }
    }
}