using System;
using Cinemachine;
using DG.Tweening;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CinemachineVirtualCamera levelCam;

        #endregion

        #endregion

        #region Event Supscirption

        private void OnEnable()
        { 
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ScoreSignals.Instance.onActivePerfectScoreEffect += OnCameraShake;
        }

        private void UnsubscribeEvents()
        {
            ScoreSignals.Instance.onActivePerfectScoreEffect -= OnCameraShake;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnCameraShake()
        {
            levelCam.transform.DOShakePosition(.5f, .5f);
        }
    }
}