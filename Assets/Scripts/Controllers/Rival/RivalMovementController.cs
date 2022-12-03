using Data.ValueObject;
using UnityEngine;

namespace Controllers.Rival
{
    public class RivalMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Rigidbody rb;

        #endregion

        #region Private Variables

        private bool _isMoveRightSide;
        private bool _isPressed;
        private bool _isPassedBall;
        private PlayerData _data;

        #endregion
        
        #endregion

        private void FixedUpdate()
        {
            ClampVelocity();
            if (!_isPressed || _isPassedBall ) 
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
            SetTapTime();
        }
        
        private void ClampVelocity()
        {
            if (rb.velocity.magnitude>_data.MaxVelocity)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, _data.MaxVelocity);
            }
        }

        private void SetTapTime()
        {
            if (transform.position.y >= 55f)
            {
                _isPassedBall = true;
            }
            else
            {
                _isPassedBall = false;
            }
        }
    }
}