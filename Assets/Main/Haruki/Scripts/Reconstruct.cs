using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reconstruct : MonoBehaviour
{
    Animator animator;
    const string RESPAWN_TRIGGER = "respawn";

    [Tooltip("If activated, contact object will be destoryed.")]
    public bool destory = false;

    [Tooltip("Only objects with this tag trigger the fracture.")]
    public string triggerAllowedTag;

    [Tooltip("This callback is invoked when a reconstruct has been triggered. Not called for slicing and prefracturing.")]
    public UnityEvent<Collider, GameObject, Vector3> onReconstruct;

    private CustomFracture customFracture;
    // Start is called before the first frame update
    void Start()
    {
        this.customFracture = this.gameObject.GetComponent<CustomFracture>();

        animator = this.gameObject.GetComponent<Animator>();
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.contactCount > 0)
    //     {
    //         var contact = collision.contacts[0];

    //         bool tagAllowed = contact.otherCollider.gameObject.tag == this.triggerAllowedTag;

    //         // Object is unfrozen if the colliding object has the correct tag (if tag filtering is enabled)
    //         // and the collision force exceeds the minimum collision force.
    //         if (tagAllowed)
    //         {
    //             if (this.destory)
    //             {
    //                 Object.Destroy(contact.otherCollider.gameObject);
    //             }

    //             var renderer = this.gameObject.GetComponent<Renderer>();
    //             renderer.enabled = true;

    //             animator.SetTrigger(RESPAWN_TRIGGER);

    //             this.customFracture.isBroken = false;
    //         }
    //     }
    // }

    void OnTriggerEnter(Collider collider)
    {
        if (!this.customFracture.isBroken) return;
        if (collider.gameObject.tag != this.triggerAllowedTag)  return;
        var renderer = this.gameObject.GetComponent<Renderer>();
                renderer.enabled = true;

                animator.SetTrigger(RESPAWN_TRIGGER);

                this.customFracture.isBroken = false;

    }

    public void CallOnReconstruct(Collider instigator, GameObject fracturedObject, Vector3 point)
    {
        onReconstruct?.Invoke(instigator, fracturedObject, point);
    }
}
