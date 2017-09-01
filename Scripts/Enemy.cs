using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject block;
    private BoxCollider2D enemyCollider;
    private float speed;
    private float lengthOfRay;
    private float margin = 1.015f;
    private Vector3 startPoint;
    private Vector3 origin;
    private Ray ray;
    private float direction;
    private RaycastHit HitInfo;
    private float debugX;


    // Use this for initialization
    void Start () {
        enemyCollider = GetComponent<BoxCollider2D>();
        lengthOfRay = enemyCollider.bounds.extents.y + 1f;
        speed = -1.2f;
        direction = -1f;
        debugX = transform.position.x;
	}

    private void Move()
    {
        debugX = transform.position.x;
        startPoint = new Vector3(enemyCollider.bounds.min.x + margin, transform.position.y, transform.position.z);
        IsCollidingVertically();
        transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));
        
    }

    private bool IsCollidingVertically()
    {
        origin = startPoint;
        // Ray to be casted.
        ray = new Ray(origin, new Vector3(lengthOfRay * direction,0f,0f));
            //Draw ray on screen to see visually. Remember visual length is not actual length.
            Debug.DrawRay(origin, new Vector3(lengthOfRay * direction, 0f, 0f), Color.yellow);
            if (Physics.Raycast(ray, out HitInfo, lengthOfRay))
            {
                // Negate the Directionfactor to reverse the moving direction of colliding cube(here cube2)
                direction = -direction;
                speed = -speed;
                return true;
            }
        
        return false;
    }

    void OnCollisionEnter(Collision col)
    {

        foreach (ContactPoint contact in col.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }


        if (col.gameObject.tag == "Block")
        {
            
            if (transform.position.y - col.transform.position.y <= 0.7)
                speed = -speed;
        }
    }

    // Update is called once per frame
    void Update () {
        
        Move();
	}
}
