using Signals;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class ScoreTimeController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TextMeshPro timeText;

        #endregion

        #region Private Variables
        
        private float _currentTime;
        private const float _timeBorder = 60;

        #endregion
        
        #endregion

        private void Awake()
        {
            _currentTime = _timeBorder;
        }
        
        private void Update()
        {
            SetTimer();
        }
        
        private void SetTimer()
        {
            if (_currentTime>0)
            {
                _currentTime -= Time.deltaTime;
                DisplayTimer(_currentTime);
            }
            else
            {
                CoreGameSignals.Instance.onGameFailed?.Invoke();
                ResetTime();
            }
        }

        private void DisplayTimer(float remainingTime)
        {
            float minutes = Mathf.FloorToInt(remainingTime / 60);//const  
            float seconds = Mathf.FloorToInt(remainingTime % 60); 
            timeText.text = $"{minutes:00}:{seconds:00}";
        }

        private void ResetTime()
        {
            _currentTime = _timeBorder;
        }
    }
}