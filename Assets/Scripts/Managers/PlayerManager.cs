using UnityEngine;
using Controllers.Player;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        [Header("Data")] public PlayerData Data;

        #endregion

        #region Serialized Variables

        [SerializeField] private PlayerMeshController meshController;
        [SerializeField] private PlayerPhysicsController physicsController;
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerParticleController particleController;

        #endregion

        #region Private Variables

        private InputTypes _inputTypes;
        private float _prePos;

        #endregion

        #endregion

        private void Awake()
        {
            GetReferences();
            SendDataToControllers();
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += OnActivateMovement;
            InputSignals.Instance.onInputReleased += OnDeactivateMovement;
            InputSignals.Instance.onActiveInputType += OnActivateMovementType;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            ScoreSignals.Instance.onGetPecfectCount += OnGetPerfectCount;
            PlayerSignals.Instance.onChangeMoveDirection += OnChangeMoveDirection;
        }

        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= OnActivateMovement;
            InputSignals.Instance.onInputReleased -= OnDeactivateMovement;
            InputSignals.Instance.onActiveInputType -= OnActivateMovementType;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            ScoreSignals.Instance.onGetPecfectCount -= OnGetPerfectCount;
            PlayerSignals.Instance.onChangeMoveDirection -= OnChangeMoveDirection;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private PlayerData GetPlayerData() => Resources.Load<CD_Player>("Data/CD_PlayerData").Data;

        private void GetReferences()
        {
            Data = GetPlayerData();
        }

        private void SendDataToControllers()
        {
            movementController.SetData(Data);
        }

        private void OnPlay()
        {
            movementController.SetMoveDirection();
        }
        private void OnReset()
        {
            movementController.StopPlayer();
        }

        private void OnActivateMovement(float inputPosX)
        {
            if (_inputTypes == InputTypes.TwoSide && (inputPosX/_prePos)<0)
            {
                OnChangeMoveDirection();
            }
            movementController.SetSuitableSituation(true);
            _prePos = inputPosX;
        }

        private void OnDeactivateMovement()
        {
            movementController.SetSuitableSituation(true);
        }

        private void OnChangeMoveDirection()
        {
            movementController.SetMoveDirection();
        }

        private void OnGetPerfectCount(ushort count)
        {
            particleController.SetPerfectCount(count);
        }

        private void OnActivateMovementType(InputTypes inputType)
        {
            _inputTypes = inputType;
            physicsController.SetInteractionType(inputType);
        }
    }
}
