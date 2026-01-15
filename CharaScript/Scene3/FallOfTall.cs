using UnityEngine;

public class FallOfTall : MonoBehaviour
{
    private float startpos;
    private float fallDistance;
    public Rigidbody rb;
    private bool isFalling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startpos = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.y < 0.1f && !isFalling)
        {
            isFalling = true;
            startpos = 0f;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (isFalling && other.gameObject.CompareTag("Ground"))
        {
            fallDistance = startpos - transform.position.y;
            Debug.Log("落下距離：" + fallDistance.ToString("F2"));
            if (fallDistance >= 0.3f)
            {
                rb.angularVelocity = Vector3.zero;
                rb.linearVelocity = Vector3.zero;
                //rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
            isFalling = false;
        }
    }
}
