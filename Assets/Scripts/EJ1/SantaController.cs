using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SantaController : MonoBehaviour
{

    private PlayerInput playerInput; 
    private Rigidbody rb;
    private Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Caramelito"))
        {
            GameManager.Instance.RecogerCaramelito();
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector = playerInput.actions["Moverse"].ReadValue<Vector2>();
        rb.velocity = new Vector3(vector.x, 0,vector.y) * 3;
        animator.SetFloat("Velocidad x",vector.x);
        animator.SetFloat("Velocidad z", vector.y);
    }
}
