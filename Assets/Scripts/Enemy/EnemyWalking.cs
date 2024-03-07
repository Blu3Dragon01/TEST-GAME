using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyWalking : MonoBehaviour
{
    public bool TestMode = true;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask isGroundLayer;
    [SerializeField] float groundCheckRadius = 0.02f;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Animator anim;
    private SpriteRenderer sr;
    private Transform currentPoint;
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        currentPoint = pointB.transform;
        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.02f;
            if (TestMode) Debug.Log("Groundcheck radius value has been defaulted on " + gameObject.name);
        }


        if (GroundCheck == null)
        {
            //GroundCheck = GameObject.FindGameObjectWithTag("GroundCheck").transform;
            GameObject obj = new GameObject();
            obj.transform.SetParent(gameObject.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.name = "GroundCheck";
            GroundCheck = obj.transform;
            if (TestMode) Debug.Log("Groundcheck object was created on " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform && isGrounded)
        {
            anim.SetBool("isRunning", true);
            rb.velocity = new Vector2(-speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0f);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
        if (isFacingRight() && isGrounded)
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool isFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
    }
}