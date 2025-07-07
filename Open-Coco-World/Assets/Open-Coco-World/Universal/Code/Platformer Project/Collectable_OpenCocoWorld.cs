using PLAYERTWO.PlatformerProject;
using UnityEngine;

public class Collectable_OpenCocoWorld : Collectable
{
    public void ResetCollectable()
    {
        InitializeAudio();
        InitializeCollider();
        InitializeTransform();
        InitializeDisplay();
        InitializeVelocity();
        m_collider.enabled = true;
        m_vanished = false;
        m_ghosting = false;
    }
}
