using System;
using Data.ValueObject;
using UnityEngine;

namespace Controllers
{
    public class RivalMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private new Rigidbody rb;

        #endregion

        #region Private Variables

        private bool _isMoveRightSide;
        private bool _isPressed;
        private ushort _maxVelocityMagnitude;
        private PlayerData _data;

        #endregion
        #endregion

        
        private void FixedUpdate()
        {
            ClampVelocity();
            if (!_isPressed)
            {
                return;
            }
            ApplyForce();
            _isPressed = false;
        }
        
        private void ApplyForce()
        { 
            if (_isMoveRightSide)
            {
                rb.AddForce(new Vector3(_data.AppliedForce.x,_data.AppliedForce.y,0),ForceMode.Force);
            }
            else
            {
                rb.AddForce(new Vector3(-_data.AppliedForce.x,_data.AppliedForce.y,0),ForceMode.Force);
            }
        }

        public void SetData(PlayerData data)
        {
            _data = data;
        }
        
        public void ChangeDirection()
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

        public void SetSuitableSituation()
        {
            _isPressed = true;
        }
        
        private void ClampVelocity()
        {
            if (rb.velocity.magnitude>_maxVelocityMagnitude)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, _maxVelocityMagnitude);
            }
        }
    }
}