using Managers;
using Signals;
using UnityEngine;

namespace Controllers.Rival
{
    public class RivalPhysicController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private RivalManager manager;

        #endregion

        #region Private Variables

        private bool _isEnterRival;
        private bool _isExitRival;

        #endregion
        #endregion


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
            {
                manager.ChangeMoveDirection();
            }
            
            if (other.CompareTag("Target") && (_isEnterRival || !_isExitRival))
            {
                ScoreSignals.Instance.onUpdatePlayerScore?.Invoke();
            }
        }

        public void SetEntrySituation(bool isInEntry)
        {
            _isEnterRival = isInEntry;
        }

        public void SetExitSituation(bool isInExit)
        {
            _isExitRival = isInExit;
        }
    }
}