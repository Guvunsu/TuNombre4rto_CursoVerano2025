using System.Collections;
using SotomaYorch.Game;
using UnityEngine;
using UnityEngine.Events;

namespace SotomaYorch.Mechanics.Game
{
    #region Structs

    [System.Serializable]
    public struct BasicGameEntityParameters
    {
        [SerializeField] public bool isAutomaticallyBegun;
        [SerializeField] public bool isAlwaysActive;
        [SerializeField] public bool isForceStateTransitionable;
        [SerializeField] public bool canBeReplayed;
        [SerializeField] public int subGameMechanicEntityFulfillments;
    }

    #endregion

    #region Enums

    public enum GameStateMechanic
    {
        RESET = 0,
        BEGIN = 1,
        WIN = 2,
        FAIL = 3
    }

    public enum GameMechanicStatus
    {
        IDLE = 0,           //For the game not operating, is preparing to be started
        IN_PROGRESS = 1,    //The game is in progress
        SOLVED = 2,         //Game solved
        FAILED = 3          //Game failed
    }

    #endregion

    public class GameMechanicEntity : MonoBehaviour
    {
        #region Parameters

        [Header("Persistance")]
        [SerializeField] GameMechanicEntity_SO persistantData;

        [Header("Runtime Parameters")]
        [SerializeField] BasicGameEntityParameters basicParameters;

        [Header("Game Mechanic State Effects")]
        [SerializeField] UnityEvent previouslyCompletedEvents;
        [SerializeField] UnityEvent resetGameEvents;
        [SerializeField] UnityEvent beginGameEvents;
        [SerializeField] UnityEvent fulfillmentEvents;
        [SerializeField] UnityEvent failureEvents;

        #endregion

        #region RuntimeVariables

        [Header("Debug")]
        [SerializeField] protected GameMechanicStatus _currentStatus;
        protected bool _gameStateMechanicSuccessful;
        [SerializeField] protected int _subGameMechanicEntityFulfillmentCount;

        #endregion

        #region UnityEvents

        protected virtual void Start()
        {
            InitializeGameMechanicEntity();
        }

        protected virtual void OnDrawGizmos()
        {
            if (persistantData == null)
            {
                Debug.LogWarning(gameObject.name + " - " + this.name + " - " +
                    "There are any assigned persistant data Scriptable Object. Please assign one if you want to this game mechanic entity to be data persistent.",
                    gameObject);
            }
        }

        #endregion

        #region PublicMethods

        public void GameStateMechanic(GameStateMechanic value)
        {
            _gameStateMechanicSuccessful = false;

            if (basicParameters.isForceStateTransitionable)
            {
                _currentStatus = (Game.GameMechanicStatus)value;
                _gameStateMechanicSuccessful = true;
                //In order to trigger the state and reset (if needed) the time contrain coroutine 
            }

            if (!_gameStateMechanicSuccessful)
            {
                switch (_currentStatus)
                {
                    case GameMechanicStatus.IDLE:
                        if (value == Game.GameStateMechanic.BEGIN)
                        {
                            _currentStatus = Game.GameMechanicStatus.IN_PROGRESS;
                            _gameStateMechanicSuccessful = true;
                        }
                        break;
                    case GameMechanicStatus.IN_PROGRESS:
                        if (value == Game.GameStateMechanic.WIN || value == Game.GameStateMechanic.FAIL)
                        {
                            _currentStatus = (GameMechanicStatus)value;
                            if (value == Game.GameStateMechanic.WIN)
                            {
                                if (persistantData != null)
                                {
                                    persistantData.completed = true; //independently it was previously solved
                                }
                            }
                            _gameStateMechanicSuccessful = true;
                        }
                        break;
                    case GameMechanicStatus.FAILED:
                        if (basicParameters.canBeReplayed && (value == Game.GameStateMechanic.BEGIN || value == Game.GameStateMechanic.RESET))
                        {
                            _currentStatus = (Game.GameMechanicStatus)value;
                            _gameStateMechanicSuccessful = true;
                        }
                        break;
                    case GameMechanicStatus.SOLVED:
                        if (basicParameters.canBeReplayed && (value == Game.GameStateMechanic.BEGIN || value == Game.GameStateMechanic.RESET))
                        {
                            _currentStatus = (Game.GameMechanicStatus)value;
                            _gameStateMechanicSuccessful = true;
                        }
                        break;
                }
            }

            if (_gameStateMechanicSuccessful)
            {
                switch (_currentStatus)
                {
                    case GameMechanicStatus.IDLE:
                        ResetGame();
                        break;
                    case GameMechanicStatus.IN_PROGRESS:
                        BeginGame();
                        break;
                    case GameMechanicStatus.SOLVED:
                        FulfilledGame();
                        break;
                    case GameMechanicStatus.FAILED:
                        FailedGame();
                        break;
                }
            }
        }

        public void ResetGameMechanicEntity()
        {
            GameStateMechanic(Game.GameStateMechanic.RESET);
        }

        public void ResetAndBeginGameMechanicEntity()
        {
            GameStateMechanic(Game.GameStateMechanic.RESET);
            GameStateMechanic(Game.GameStateMechanic.BEGIN);
        }

        public void BeginGameMechanicEntity()
        {
            GameStateMechanic(Game.GameStateMechanic.BEGIN);
        }

        public void FulfillGameMechanicEntity()
        {
            GameStateMechanic(Game.GameStateMechanic.WIN);
        }

        public void FailGameMechanicEntity()
        {
            GameStateMechanic(Game.GameStateMechanic.FAIL);
        }

        public void PreviouslyCompletedGameMechanicEntity()
        {
            previouslyCompletedEvents.Invoke();
        }

        public void SubGameMechanicEntityFulfillment()
        {
            if (_currentStatus == GameMechanicStatus.IN_PROGRESS)
            {
                _subGameMechanicEntityFulfillmentCount++;
                if (_subGameMechanicEntityFulfillmentCount >= basicParameters.subGameMechanicEntityFulfillments)
                {
                    GameStateMechanic(Game.GameStateMechanic.WIN);
                }
            }
        }

        #endregion

        #region LocalMethods

        protected virtual void InitializeGameMechanicEntity()
        {
            if (persistantData != null && persistantData.completed)
            {
                previouslyCompletedEvents.Invoke();
            }
            if (basicParameters.isAutomaticallyBegun)
            {
                GameStateMechanic(Game.GameStateMechanic.BEGIN);
            }
            else
            {
                if (!basicParameters.isAlwaysActive)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        protected virtual void ResetGame()
        {
            gameObject.SetActive(basicParameters.isAlwaysActive);
            _subGameMechanicEntityFulfillmentCount = 0;
            resetGameEvents.Invoke();
        }

        protected virtual void BeginGame()
        {
            gameObject.SetActive(true);
            _subGameMechanicEntityFulfillmentCount = 0;
            beginGameEvents.Invoke();
        }

        protected virtual void FulfilledGame()
        {
            fulfillmentEvents.Invoke();
            //gameObject.SetActive(basicParameters.isAlwaysActive);
        }

        protected virtual void FailedGame()
        {
            failureEvents.Invoke();
            if (gameObject.activeSelf)
            {
                StartCoroutine(FailureFrameCoroutine());
            }
            else
            {
                GameStateMechanic(Game.GameStateMechanic.RESET);
            }
        }

        #endregion

        #region Coroutines

        protected IEnumerator FailureFrameCoroutine()
        {
            //Give it a frame, so the previous state events run properly and don't overlap with this new state
            yield return null;
            GameStateMechanic(Game.GameStateMechanic.RESET);
        }

        #endregion

    }
}