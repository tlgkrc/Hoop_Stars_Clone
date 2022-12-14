using System;
using System.Collections.Generic;
using Controllers;
using Controllers.UI;
using DG.Tweening;
using Enums;
using Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private List<GameObject> panels;
        [SerializeField] private GameObject settingsGameObject;
        [SerializeField] private GameObject oneSidePanel;
        [SerializeField] private GameObject twoSidePanel;

        #endregion

        #region Private Variables
        
        private UIPanelController _uiPanelController;
        
        #endregion

        #endregion

        private void Awake()
        {
            _uiPanelController = new UIPanelController(ref panels);
        }

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onGameFailed += OnGameFailed;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onSetScoreText += OnSetScoreText;
            UISignals.Instance.onSetBestScore += OnSetBestScore;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onGameFailed -= OnGameFailed;
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onSetScoreText -= OnSetScoreText;
            UISignals.Instance.onSetBestScore -= OnSetBestScore;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Start()
        {
            InputSignals.Instance.onActiveInputType?.Invoke(InputTypes.OneSide);
        }

        private void OnOpenPanel(UIPanels panelParam)
        {
            _uiPanelController.Execute(panelParam , true);
        }

        private void OnClosePanel(UIPanels panelParam)
        {
            _uiPanelController.Execute(panelParam , false);
        }

        private void OnPlay()
        {
           // timeController.ResetTime();
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.LevelPanel);
        }

        private void OnGameFailed()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.FailPanel);
        }

        private void OnNextLevel()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.NextLevel);
        }

        public void Play()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        private void OnSetScoreText(ushort score,ushort increaseFactor,bool isPerfect)
        {
            //timeController.ResetTime();
            // scoreText.transform.DOScale(Vector3.one * 1.3f, .3f).SetEase(Ease.InOutElastic).OnComplete(
            //     () => scoreText.transform.DOScale(Vector3.one, .3f));
            // scoreText.text = score.ToString();
        }

        private void ResetIncreaseText()
        {
            
        }

        private void OnSetBestScore(ushort best)
        {
            //bestScore.text = "BEST " + best.ToString();
        }

        private void OnReset()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.FailPanel);
        }

        public void TryAgain()
        {
            CoreGameSignals.Instance.onReset?.Invoke();
        }

        public void Settings()
        {
            settingsGameObject.gameObject.SetActive(!settingsGameObject.activeSelf);
        }

        public void ActivateOneSideInput()
        {
            oneSidePanel.SetActive(true);
            twoSidePanel.SetActive(false);
            InputSignals.Instance.onActiveInputType?.Invoke(InputTypes.OneSide);
        }

        public void ActivateTwoSideInput()
        {
            oneSidePanel.SetActive(false);
            twoSidePanel.SetActive(true);
            InputSignals.Instance.onActiveInputType?.Invoke(InputTypes.TwoSide);
        }


    }
}