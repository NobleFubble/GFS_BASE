using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private enum RagdollState
    {
        Typing,
        Ragdoll,
        StandingUp
    }
    [SerializeField]
    private Rigidbody[] _ragdollRigidbodies;
    private RagdollState _currentState = RagdollState.Typing;

    private Animator _animator;
    private CharacterController _characterController;



    [SerializeField]
    private float _timeToWakeUp;

    [SerializeField]
    private string _standUpStateName;
    [SerializeField]
    private string _typeStateName;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();

        DisableRagdoll();    
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case RagdollState.Typing:
                TypingBehaviour();
                break;
            case RagdollState.Ragdoll:
                RagdollBehaviour();
                break;
            case RagdollState.StandingUp:
                break;
        }
    }

    public void TriggerRagdoll(Vector3 force, Vector3 hitPoint)
    {
        EnableRagdoll();
        _currentState = RagdollState.Ragdoll;
        
        
        Rigidbody rb = _ragdollRigidbodies.OrderBy(r => Vector3.Distance(r.transform.position, hitPoint)).First();
        rb.AddForceAtPosition(force, hitPoint, ForceMode.Impulse);

        _timeToWakeUp = Random.Range(2, 5);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            TriggerRagdoll(Vector3.zero, other.transform.position);
        }
    }

    public void EnableRagdoll()
    {

        foreach (Rigidbody rb in _ragdollRigidbodies)
        {
            rb.isKinematic = false;
        }

        _characterController.enabled = false;
        _animator.enabled = false;
    }

    public void DisableRagdoll()
    {

        foreach (Rigidbody rb in _ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }
        
        _characterController.enabled = true;
        _animator.enabled = true;
    }

    private void TypingBehaviour()
    {
        
    }

    private void RagdollBehaviour()
    {
        _timeToWakeUp -= Time.deltaTime;
        if (_timeToWakeUp <= 0)
        {

            DisableRagdoll();
            _currentState = RagdollState.StandingUp;
            _animator.Play(_standUpStateName);
        }
    }
    
    private void StandingUpBehaviour()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_typeStateName))
        {
            _currentState = RagdollState.Typing;
        }
    }
 
}
