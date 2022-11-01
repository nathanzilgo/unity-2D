using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] public int moveSpeed;
    [SerializeField] Transform weaponsArm;
    private Camera mainCamera;
    private Vector2 moveInput;

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        playerRigidBody.velocity = moveInput * moveSpeed;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = mainCamera.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);    
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        weaponsArm.rotation = Quaternion.Euler(0, 0, angle);

        if (mousePosition.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            weaponsArm.localScale = new Vector3(-1f, -1f, 1f);
        } 
        else 
        {
            transform.localScale = Vector3.one;
            weaponsArm.localScale = Vector3.one;
        }
    }
}
