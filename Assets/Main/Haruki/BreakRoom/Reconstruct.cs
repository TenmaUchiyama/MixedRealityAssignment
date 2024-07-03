using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reconstruct : MonoBehaviour
{
    Animator animator;
    const string RESPAWN_TRIGGER = "respawn";

    [Tooltip("If activated, contact object will be destoryed.")]
    public bool destory = false;

    [Tooltip("Only objects with this tag trigger the fracture.")]
    public string triggerAllowedTag;

    private CustomFracture customFracture;
    // Start is called before the first frame update
    void Start()
    {
        this.customFracture = this.gameObject.GetComponent<CustomFracture>();

        animator = this.gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contactCount > 0)
        {
            var contact = collision.contacts[0];

            bool tagAllowed = contact.otherCollider.gameObject.tag == this.triggerAllowedTag;

            // Object is unfrozen if the colliding object has the correct tag (if tag filtering is enabled)
            // and the collision force exceeds the minimum collision force.
            if (tagAllowed)
            {
                if (this.destory)
                {
                    Object.Destroy(contact.otherCollider.gameObject);
                }

                var renderer = this.gameObject.GetComponent<Renderer>();
                renderer.enabled = true;

                animator.SetTrigger(RESPAWN_TRIGGER);

                this.customFracture.isBroken = false;
            }
        }
    }
}
