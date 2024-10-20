using System.Collections;
using UnityEngine;

public class PlatformLogic : MonoBehaviour
{
    private Vector3 initalPosition;
    private Vector3 initialScale;
    private Quaternion initialRotation;
    private Transform parentTransform;

    public Rigidbody rb;
    public float scaleSpeed = 1.0f;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        rb.isKinematic = true;
        parentTransform = gameObject.transform.parent;

        initalPosition = parentTransform.position;
        initialScale = parentTransform.localScale;
        initialRotation = parentTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(parentTransform.position.y < -50f || parentTransform.position.y > 50f)
        {
            rb.useGravity = false;
            parentTransform.localScale -= Vector3.one;
            if(parentTransform.localScale == Vector3.zero)
            {
                parentTransform.SetPositionAndRotation(initalPosition, initialRotation);
                StartCoroutine(ScaleParent());
            }
            rb.isKinematic = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            StartCoroutine(PlatformFall());
    }

    IEnumerator PlatformFall(){
        yield return new WaitForSeconds(delay);
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    IEnumerator ScaleParent()
    {
        while(parentTransform.localScale != initialScale)
        {
            parentTransform.localScale = Vector3.MoveTowards(parentTransform.localScale, initialScale, scaleSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
