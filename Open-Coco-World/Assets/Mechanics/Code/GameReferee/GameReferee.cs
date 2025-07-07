using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SotomaYorch.Game
{
    #region DelegateStructure

    public delegate void PauseDelegate(bool value);

    #endregion

    #region Interfaces

    public interface IGameState
    {
        public void InitializeState();

        public void FinishState();

        public IEnumerator ExecutingStateCoroutine();
    }

    public interface IRefereedEntity
    {
        public void Pause(bool hasBeenPaused);
        public void EndedGame();
        //multiple methods in which the game referee will mandate to this type of entity in the game
    }

    #endregion

    #region Enums

    public enum GameStateType
    {
        STARTING = 5,
        PLAYING = 1,
        WINNING = 2,
        PAUSING = 3,
        LOSING = 4,
        NONE = 0
    }

    public enum GameStateMechanicType
    {
        PREPARE_GAME = 5,
        BEGIN_GAME = 1,
        WON = 2,
        PAUSED = 3,
        LOSE = 4,
        NONE = 0
    }

    #endregion

    #region Classes

    [System.Serializable]
    public class GameState : IGameState
    {
        #region Parameters

        [SerializeField] public GameStateType gameState; 

        #endregion

        #region UnityEvents

        [SerializeField] public UnityEvent startState;
        [SerializeField] public UnityEvent executingState;
        [SerializeField] public UnityEvent finishState;

        #endregion

        #region PublicMethods

        public virtual void InitializeState()
        {
            startState.Invoke();
        }

        public virtual void FinishState()
        {
            finishState.Invoke();
        }

        #endregion

        #region Coroutines

        public virtual IEnumerator ExecutingStateCoroutine()
        {
            while (GameReferee.Instance.GetCurrentGameState == gameState)
            {
                Debug.Log(GameReferee.Instance.GetGameObject.name + " - " + " Executing " + GameReferee.Instance.GetCurrentGameState.ToString(), GameReferee.Instance.GetGameObject);
                executingState.Invoke();
                yield return new WaitForSeconds(GameReferee.coroutineDeltaTime);
            }
        }

        #endregion
    }

    #endregion

    public class GameReferee : MonoBehaviour, IRefereedEntity
    {
        #region Parameters

        [SerializeField] public static float coroutineDeltaTime = 1f / 30f; //30 FPS -> 0.0388888 seg
        [SerializeField] protected GameState[] _gameStates;

        #endregion

        #region Delegates

        public delegate void IntializeStateDelegate(); //ADN for this delegate: return type + Parameters
        public IntializeStateDelegate _intializeStateDelegate; //variable from this type of delegate
        public delegate void FinalizeStateDelegate();
        public FinalizeStateDelegate _finishStateDelegate;

        //B) Delegate which will run as a coroutine
        public delegate IEnumerator CoroutineStateDelegate();
        public CoroutineStateDelegate _executingCoroutineStateDelegate;


        protected PauseDelegate _pauseDelegate;

        public PauseDelegate GetSetPauseDelegate
        {
            get {return _pauseDelegate;}
            set {_pauseDelegate = value;}
        }


        #endregion

        #region RuntimeVariables

        protected static GameReferee _instance;
        protected GameStateType _gameStateTypeToTransition;
        protected GameStateType _currentGameState;
        protected float _stateCronometer;
        protected GameState _gameStateToExecute;


        #endregion

        #region UnityMethods

        void Awake()
        {
            Initialize();
        }

        #endregion

        #region PublicMethods

        public void GameStateMechanic(GameStateMechanicType value)
        {
            if ((int)_currentGameState != (int)value)
            {
                _gameStateTypeToTransition = ConvertStateMechanicToState(value);

                if (IncludesGameState(_gameStateTypeToTransition))
                {
                    //A) Finish the previous state
                    _finishStateDelegate?.Invoke();

                    //B) Set the new current State according to the previous search
                    _currentGameState = _gameStateTypeToTransition;

                    //C) Assign delegates for further execution
                    _gameStateToExecute = GetGameState(_currentGameState);
                    _intializeStateDelegate = _gameStateToExecute.InitializeState;
                    _executingCoroutineStateDelegate = _gameStateToExecute.ExecutingStateCoroutine;
                    _finishStateDelegate = _gameStateToExecute.FinishState;

                    //D) Execute the initialization method of the new current state
                    _intializeStateDelegate?.Invoke();
                    
                    //E) we will start the execution of its own "Update()" method
                    //but as a coroutine
                    StartCoroutine(_executingCoroutineStateDelegate?.Invoke());
                }
                else
                {
                    Debug.LogWarning(gameObject.name + " - " + this.name + " - Attemping to transition to STATE: " +
                        _gameStateTypeToTransition.ToString() + ", but it doesn't exist in the list. Please add it.");
                }
            }
        }

        #region BroadcastMessages

        public void Victory(string value)
        {
            Debug.Log(gameObject.name + ": Victory(): " + value);
        }

        public void OnPause(InputValue value) //InputAction.CallbackContext value
        {
            Debug.Log(gameObject.name + ": OnPause(): " + value.isPressed);
            if (value.isPressed) //Action->Interaction: Press //(value.performed)
            {
                if (_currentGameState == GameStateType.PLAYING)
                {
                    GameStateMechanic(SotomaYorch.Game.GameStateMechanicType.PAUSED);
                } 
                else if (_currentGameState == GameStateType.PAUSING)
                {
                    GameStateMechanic(SotomaYorch.Game.GameStateMechanicType.BEGIN_GAME);
                }
            }
            // else if (!value.isPressed) //Action->Interaction: Release //(value.canceled)
            // {
                
            // }
            //value.Get<Vector2>() -> value.ReadValue<Vector2>()
        }

        public void Pause(bool hasBeenPaused)
        {
            if (hasBeenPaused)
            {
                Debug.Log("The GAME REFEREE has sensed a pause");
                //TODO: Pending instructions for this needle
            }
            else
            {
                Debug.Log("The GAME REFEREE has sensed an unpause");
            }
        }

        public void EndedGame()
        {
            //TODO: inactivate this entity
        }

        #endregion BroadcastMessages

        #endregion PublicMethods

        #region LocalMethods

        protected virtual void Initialize()
        {
            if (_instance != null && _instance != this)
            {
                DestroyImmediate(this.gameObject);
                return;
            }
            _instance = this;

            _pauseDelegate += Pause;

            if (_gameStates.Length > 0)
            {
                if (IncludesGameState(GameStateType.STARTING))
                {
                    GameStateMechanic(SotomaYorch.Game.GameStateMechanicType.PREPARE_GAME);
                }
                else if (IncludesGameState(GameStateType.PLAYING))
                {
                    GameStateMechanic(SotomaYorch.Game.GameStateMechanicType.BEGIN_GAME);
                }
                else
                {
                    GameStateMechanic(ConvertStateToStateMechanic(_gameStates[0].gameState));
                }
            }
            else
            {
                Debug.LogWarning(gameObject.name + " - " + this.name + " - There are no STATES assigned to the Game Referee " +
                    "please assign them to the proper functionality of the game");
            }
        }

        protected virtual GameStateType ConvertStateMechanicToState(GameStateMechanicType value)
        {
            switch (value)
            {
                case GameStateMechanicType.PREPARE_GAME:
                    return GameStateType.STARTING;
                case GameStateMechanicType.BEGIN_GAME:
                    return GameStateType.PLAYING;
                case GameStateMechanicType.PAUSED:
                    return GameStateType.PAUSING;
                case GameStateMechanicType.WON:
                    return GameStateType.WINNING;
                case GameStateMechanicType.LOSE:
                    return GameStateType.LOSING;
            }
            return GameStateType.NONE;
        }

        protected virtual GameStateMechanicType ConvertStateToStateMechanic(GameStateType value)
        {
            switch (value)
            {
                case GameStateType.STARTING:
                    return GameStateMechanicType.PREPARE_GAME;
                case GameStateType.PLAYING:
                    return GameStateMechanicType.BEGIN_GAME;
                case GameStateType.PAUSING:
                    return GameStateMechanicType.PAUSED;
                case GameStateType.WINNING:
                    return GameStateMechanicType.WON;
                case GameStateType.LOSING:
                    return GameStateMechanicType.LOSE;
            }
            return GameStateMechanicType.NONE;
        }

        protected bool IncludesGameState(GameStateType value)
        {
            foreach (GameState gameState in _gameStates)
            {
                if (gameState.gameState == value)
                {
                    return true;
                }
            }
            return false;
        }

        protected GameState GetGameState(GameStateType value)
        {
            foreach (GameState gameState in _gameStates)
            {
                if (gameState.gameState == value)
                {
                    return gameState;
                }
            }
            return null;
        }

        #endregion LocalMethods

        #region GettersAndSetters

        public static GameReferee Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<GameReferee>();

                    if (_instance == null)
                    {
                        GameObject go = new GameObject();
                        _instance = go.AddComponent<GameReferee>();
                    }
                }
                return _instance;
            }
        }

        public GameStateType GetCurrentGameState
        {
            get
            {
                return _currentGameState;
            }
        }

        public GameObject GetGameObject
        {
            get
            {
                return gameObject;
            }
        }

        #endregion
    }
}