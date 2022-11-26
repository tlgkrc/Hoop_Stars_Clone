using System;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class RivalPhysicController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private RivalManager manager;

        #endregion

        #region Private Variables

        

        #endregion
        #endregion


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
            {
                manager.ChangeMoveDirection();
            }
        }
    }
}