using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;

public class AnimationRagdoll : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    [SerializeField] private float respawnTime = 5f;
    Rigidbody[] rigidbodies;
    private bool isRagdoll = false;
    [SerializeField] Rigidbody encounter;

    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        ToggleRagdoll(false);
        transform.forward = encounter.position * 30;
    }

    private void ToggleRagdoll(bool isAnimation)
    {
        isRagdoll = !isAnimation;
        myCollider.enabled = isAnimation;

        foreach (Rigidbody ragdollBody in rigidbodies)
        {
            ragdollBody.isKinematic = isAnimation;

            GetComponent<Animator>().enabled = isAnimation;

            if (isAnimation) RandomAnimation();
        }
    } 

    private void RandomAnimation()
    {
        int randomNum = UnityEngine.Random.Range(0, 2);

        Animator animator = GetComponent<Animator>();

        if (randomNum == 0)
        {
            animator.SetTrigger("walk");
        }
        else animator.SetTrigger("idle");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC") && !isRagdoll)
        {
            ToggleRagdoll(false);
            StartCoroutine(GetBackup());
        }
    }

    private IEnumerator GetBackup()
    {
        yield return new WaitForSeconds(respawnTime);
        ToggleRagdoll(true);
    }
    void Update()
    {

    }
}
