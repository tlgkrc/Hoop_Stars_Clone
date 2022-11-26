using System;
using System.Collections;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class RivalManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private RivalMovementController movementController;

        #endregion

        #region Private Variables

        private PlayerData _data;

        #endregion
        #endregion

        private void Awake()
        {
            GetReferences();
            SendDataToControllers();
        }

        #region Event Supscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;

        }

        private void OnDisable()
        {
            StopAllCoroutines();
            UnsubscribeEvents();
        }

        #endregion

        public void ChangeMoveDirection()
        {
            movementController.ChangeDirection();
        }
        
        private PlayerData GetPlayerData() => Resources.Load<CD_Player>("Data/CD_PlayerData").Data;

        private void GetReferences()
        {
            _data = GetPlayerData();
        }

        private void SendDataToControllers()
        {
            movementController.SetData(_data);
        }

        private void OnPlay()
        {
            StartCoroutine(Press());
        }

        IEnumerator Press()
        {
            float waiting = Random.Range(1, 3);
            yield return new WaitForSeconds(waiting);
            movementController.SetSuitableSituation();
        }
    }
}