using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gost : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform location;
    private GameObject player;
    
    private float dirX = 0f;
    private float dirY = 0f;
    
    [SerializeField] private float x_speed = 7f;
    [SerializeField] private float y_speed = 7f;
    [SerializeField] private float maxDistance = 10f;

    private bool isActive;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        player = GameObject.Find("Player");
        location = GetComponent<Transform>();
        isActive = false;
        
        ToggleCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            isActive = !isActive;
            ToggleCharacter();
        }

        if (isActive)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(dirX * x_speed, dirY * y_speed);
            
            Vector2 offset = location.position - player.transform.position;
            if (offset.magnitude > maxDistance)
            {
                offset = offset.normalized * maxDistance;
                location.position = player.transform.position + (Vector3)offset;
            }
        }
    }
    
    private void ToggleCharacter()
    {
        location.position = player.transform.position;
    }
}
