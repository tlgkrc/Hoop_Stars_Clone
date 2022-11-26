using Managers;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerPhysicExitController : MonoBehaviour
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
                manager.ExitInteractionWithTarget(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Target"))
            {
                manager.ExitInteractionWithTarget(false);
            }
        }
    }
}