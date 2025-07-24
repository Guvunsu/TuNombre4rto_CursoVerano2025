using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonTimer : MonoBehaviour
{

    [SerializeField] private float _timer = 0f;
    [SerializeField] private float _timeLimit = 0f;

    [SerializeField] protected List<SwitchButton> switchButtons;

    private bool _running = false;
    private void Start()
    {

        switchButtons = new List<SwitchButton>(transform.GetComponentsInChildren<SwitchButton>());
    }
    private void FixedUpdate()
    {
        if (_running  && _timer < _timeLimit)
        {
            _timer += Time.deltaTime;
        }
        if (_running && _timer >= _timeLimit)
        {
            timerOff();
        }
    }
    public void timerOff()
    {
        _running = false;

        foreach (SwitchButton block in switchButtons)
        {
            block.SwitchBlock();
        }
    }
    public void timerOn()
    {
        _running = true;
        _timer = 0f;

        foreach (SwitchButton block in switchButtons) {
            block.SwitchBlock();
        }
    }
   
}
