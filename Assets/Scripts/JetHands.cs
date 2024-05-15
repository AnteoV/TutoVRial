using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class JetHands : MonoBehaviour
{
    [SerializeField] private float jetForce;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private ControllerHand hand;
    private GameObject playerController;
    private SmoothLocomotion smoothLocomotion;
    private PlayerGravity playerGravity;
    private AudioSource audioSource;
    private Vector3 direction;
    private bool flying;
    private bool falling;
    void Start()
    {
        playerController = GameObject.FindWithTag("Player");
        smoothLocomotion = playerController.GetComponent<SmoothLocomotion>();
        playerGravity = playerController.GetComponent<PlayerGravity>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (hand == ControllerHand.Left)
        {
            FlightCheck(InputBridge.Instance.LeftGrip);
        }
        if (hand == ControllerHand.Right) 
        {
            FlightCheck(InputBridge.Instance.RightGrip);
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
        if (particleSystem != null && !particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
    }
}
