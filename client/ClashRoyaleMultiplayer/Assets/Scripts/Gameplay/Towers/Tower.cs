using UnityEngine;

namespace Gameplay.Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private float _modelSize;

        public float GetDistance(Vector3 point) => 
            Vector3.Distance(transform.position, point) - _modelSize;
    }
}