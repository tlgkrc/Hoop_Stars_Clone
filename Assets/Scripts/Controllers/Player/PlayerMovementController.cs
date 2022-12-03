using Data.ValueObject;
using Enums;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Rigidbody rb;

        #endregion

        #region Private Variables

        private bool _isMoveRightSide;
        private bool _isSuitableForNewForce; 
        private PlayerData _playerData;
        
        #endregion

        #endregion

        private void Awake()
        {
            _isMoveRightSide = true;
        }

        public void SetData(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public void SetSuitableSituation(bool isSuit)
        {
            _isSuitableForNewForce = isSuit;
        }


        private void FixedUpdate()
        {
            ClampVelocity();
            if (!_isSuitableForNewForce) return;
            ApplyForce();
            _isSuitableForNewForce = false;
        }

        public void StopPlayer()
        {
            rb.velocity =Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        private void ClampVelocity()
        {
            if (rb.velocity.magnitude>_playerData.MaxVelocity)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, _playerData.MaxVelocity);
            }
        }

        public void SetMoveDirection()
        {
            if (_isMoveRightSide)
            {
                _isMoveRightSide = false;
            }
            else
            {
                _isMoveRightSide = true;
            }
        }

        private void ApplyForce()
        { 
            if (_isMoveRightSide)
            {
                rb.AddForce(new Vector3(_playerData.AppliedForce.x,_playerData.AppliedForce.y,0),ForceMode.Force);
            }
            else
            {
                rb.AddForce(new Vector3(-_playerData.AppliedForce.x,_playerData.AppliedForce.y,0),ForceMode.Force);
            }
        }
    }
}