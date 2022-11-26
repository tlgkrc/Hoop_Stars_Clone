using Managers;
using UnityEngine;

namespace Controllers.Rival
{
    public class RivalPhysicEntryController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private RivalManager manager;

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