using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator m_animatorPlayer;
    private PlayerMovement m_playerMovement;

    private void Awake()
    {
        this.m_animatorPlayer = GetComponent<Animator>();
        this.m_playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        SetJumpingAnimation();
        SetWalkingAnimation();
        SetRunningAnimation();
    }

    public void SetRunningAnimation()
    {
        if (this.m_playerMovement.fMoveInput != 0 && this.m_playerMovement.bIsJumping == false && this.m_playerMovement.bIsWalking == true)
        {
            this.m_animatorPlayer.SetBool("bIsRunning", true);
        }
        else
        {
            this.m_animatorPlayer.SetBool("bIsRunning", false);
        }
    }

    public void SetWalkingAnimation()
    {
        if (this.m_playerMovement.fMoveInput != 0 && this.m_playerMovement.bIsJumping == false && this.m_playerMovement.bIsRunning == false)
        {
            this.m_animatorPlayer.SetBool("bIsWalking", true);
        }
        else
        {
            this.m_animatorPlayer.SetBool("bIsWalking", false);
        }
        if (this.m_playerMovement.bIsJumping == true)
        {
            this.m_animatorPlayer.SetBool("bIsWalking", false);
        }
    }

    public void SetJumpingAnimation()
    {
        if(this.m_playerMovement.bIsJumping == true)
        {
            this.m_animatorPlayer.SetBool("bIsJumping", true);
        }
        else
        {
            this.m_animatorPlayer.SetBool("bIsJumping", false);
        }
    }
}
