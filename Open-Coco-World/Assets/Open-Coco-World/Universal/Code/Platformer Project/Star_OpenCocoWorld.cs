using PLAYERTWO.PlatformerProject;
using UnityEngine;

public class Star_OpenCocoWorld : Star
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

    public override void HandleAutoDisable()
		{
			// if (m_score.stars[index])
			// 	gameObject.SetActive(false);
		}
}