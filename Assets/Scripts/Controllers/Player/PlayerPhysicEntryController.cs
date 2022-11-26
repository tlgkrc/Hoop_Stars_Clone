using System;
using Managers;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerPhysicEntryController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;

        #endregion

        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Target"))
            {
                manager.EntryInteractionWithTarget(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Target"))
            {
                manager.EntryInteractionWithTarget(false);
            }
        }
    }
}