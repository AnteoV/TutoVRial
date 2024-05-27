using System.Collections;
using System.Collections.Generic;
using System.Threading;
using BNG;
using UnityEngine;

public class JetHands : MonoBehaviour
{
    [SerializeField] private float jetForce;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private ControllerHand hand;
    private CharacterController characterController;
    private float timerFlying;
    private float timerCooldown;
    private GameObject playerController;
    private SmoothLocomotion smoothLocomotion;
    private PlayerGravity playerGravity;
    private AudioSource audioSource;
    private Vector3 direction;
    private bool flying;
    private bool grounded;
    void Start()
    {
        playerController = GameObject.FindWithTag("Player");
        smoothLocomotion = playerController.GetComponent<SmoothLocomotion>();
        playerGravity = playerController.GetComponent<PlayerGravity>();
        audioSource = GetComponent<AudioSource>();
        characterController = playerController.GetComponent<CharacterController>();
        timerFlying = 3f;
    }

    void Update()
    {
        grounded = characterController.isGrounded;
        if(timerFlying >= 0f)
        {
            if (hand == ControllerHand.Left)
            {
                FlightCheck(InputBridge.Instance.LeftGrip);
            }
            if (hand == ControllerHand.Right)
            {
                FlightCheck(InputBridge.Instance.RightGrip);
            }
            if (flying)
            {
                timerFlying -= Time.deltaTime;
            }
            if (grounded)
            {
                timerFlying = 3f;
            }
        }
        else
        {
            NoJet();
            if (grounded)
            {
                timerFlying = 3f;
            }
        }
        
    }

    private void FlightCheck(float grip)
    {
        if(grip > 0.1f)
        {
            Jet(grip);
            flying = true;
        }
        else
        {
            NoJet();
            flying = false;
        }
    }

    private void Jet(float grip)
    {
        playerGravity.GravityEnabled = false;
        direction = -transform.forward * jetForce;
        smoothLocomotion.MoveCharacter(direction * Time.deltaTime * grip);
        if (!audioSource.isPlaying)
        {
            audioSource.pitch = Time.timeScale;
            audioSource.Play();
        }
        if (particleSystem != null && !particleSystem.isPlaying)
        {
            particleSystem.Play();
        }
    }

    private void NoJet()
    {
        playerGravity.GravityEnabled = true;
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        if (particleSystem != null && particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
    }
}
