using System;
using UnityEngine;

namespace Gameplay.UI
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _camera;

        private void Awake() => 
            _camera = Camera.main;

        private void Update()
        {
            transform.LookAt(_camera.transform);
        }
    }
}