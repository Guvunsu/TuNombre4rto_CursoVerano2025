using System.Collections;
using UnityEngine;

namespace SotomaYorch.Mechanics
{
    public class OnTimerCause : GenericCause
    {
        #region RuntimeVariables

        protected float _time;
        protected float _cronometer;
        protected Coroutine _timerCoroutine;

        #endregion

        #region PublicMethods

        public void BeginTimer(float value)
        {
            _time = value;
            _cronometer = _time;
            //Stop coroutine, in case there was any
            StopTimer();
            OnEnter();
            _timerCoroutine = StartCoroutine(TimerCoroutine());
        }

        public void StopTimer()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
            }
        }

        public void ResetTimer()
        {
            //the coroutine will continue
            if (_timerCoroutine != null )
            {
                _cronometer = _time;
            }
        }

        #endregion

        #region Coroutines

        protected IEnumerator TimerCoroutine()
        {
            //Wait for the next frame, giving priority to the OnEnter invocation
            yield return null; 
            while (_cronometer > 0f)
            {
                _cronometer -= Time.deltaTime;
                OnStay();
                yield return new WaitForSeconds(Time.deltaTime);
            }
            OnExit();
        }

        #endregion
    }
}
