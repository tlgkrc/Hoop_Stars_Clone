using System;
using Enums;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;

        #endregion

        #region Private Variables

        private bool _isEnterPlayer;
        private bool _isExitPlayer;
        private InputTypes _interactionType;

        #endregion

        #endregion
        
        private void OnTriggerExit(Collider other)
        {
            // if (other.CompareTag("Hook") && _isEnterPlayer && _isExitPlayer)
            // {
            //     ScoreSignals.Instance.onGetHookPos.Invoke(other.transform.position);
            //     ScoreSignals.Instance.onUpdateScore?.Invoke();
            //     _isEnterPlayer = false;
            // }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall") && _interactionType ==InputTypes.OneSide)
            { 
                PlayerSignals.Instance.onChangeMoveDirection?.Invoke();
            }
        }

        public void SetEntrySituation(bool isInEntry)
        {
            _isEnterPlayer = isInEntry;
        }

        public void SetExitSituation(bool isInExit)
        {
            _isExitPlayer = isInExit;
        }

        public void SetInteractionType(InputTypes inputType)
        {
            _interactionType = inputType;
        }
    }
}