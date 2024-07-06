using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using Oculus.Interaction.Input.Filter;
using UnityEngine;
using UnityEngine.Events;

public class PokeInteractableSideDetector : MonoBehaviour
{
    private PokeInteractable pokeInteractable;

    public UnityEvent OnRightHandPoked; 
    public UnityEvent OnLeftHandPoked;

  
    void Start()
    {
        pokeInteractable = GetComponent<PokeInteractable>();
        pokeInteractable.WhenPointerEventRaised += OnPointerEventRaised;
    }

    private void OnPointerEventRaised(PointerEvent pointerEvent)
    {

        var pokeInteractor = pointerEvent.Data as PokeInteractor; 
        if(!pokeInteractor) return; 

          Debug.Log($"<color=yellow>{pointerEvent.Data}</color>");
           var hand = pokeInteractor.GetComponentInParent<Hand>();

        Handedness handedness = hand.Handedness;
        
        if(handedness == Handedness.Right)
        {
            OnRightHandPoked.Invoke();
        }
        else if(handedness == Handedness.Left)
        {
            OnLeftHandPoked.Invoke();
        }
        
    
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
