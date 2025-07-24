using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] protected GameObject onGameObject, offGameObject;

    protected bool state;

    public void SwitchBlock()
    {
        state = !state; //flipping the state
        onGameObject.SetActive(state);
        offGameObject.SetActive(!state);
    }
}
