using DG.Tweening;
using Interfaces;
using Signals;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TextMeshPro playerScoreText;
        [SerializeField] private TextMeshPro rivalScoreText;

        #endregion

        #region Private Variables

        private ushort _playerScore;
        private ushort _rivalScore;
        #endregion

        #endregion

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ScoreSignals.Instance.onUpdatePlayerScore += OnUpdatePlayerScore;
            ScoreSignals.Instance.onUpdateRivalScore += OnUpdateRivalScore;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onGameFailed += OnGameFailed;

        }

        private void UnsubscribeEvents()
        {
            ScoreSignals.Instance.onUpdatePlayerScore -= OnUpdatePlayerScore;
            ScoreSignals.Instance.onUpdateRivalScore -= OnUpdateRivalScore;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onGameFailed -= OnGameFailed;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnPlay()
        {
            
        }

        private void OnReset()
        {
            
        }

        private void OnUpdatePlayerScore()
        {
            _playerScore += 1;
            CheckWinner();
        }

        private void OnUpdateRivalScore()
        {
            _rivalScore += 1;
            CheckWinner();
        }

        private void CheckWinner()
        {
            if (_playerScore >= 3)
            {
                CoreGameSignals.Instance.onNextLevel?.Invoke();
            }
            else if(_rivalScore >=3)
            {
                CoreGameSignals.Instance.onGameFailed?.Invoke();
            }
        }

        private void OnGameFailed()
        {
           
        }
        
    }
}