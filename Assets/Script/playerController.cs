using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; //velocidad player

    private Rigidbody2D rb; //referencia rigibody2d unity
    private Vector2 movement; //direccion movimiento

     void Start()
    {
        //inicializar el Rigibody2d untity
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //obtener el input del player
        movement.x = Input.GetAxisRaw("Horizontal"); //flechas o teclas A/D
        movement.y = Input.GetAxisRaw("Vertical"); // flechas o teclas W/S

        movement = movement.normalized;
    }

     void FixedUpdate()
    {
        //aplicar mivimiento al player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D colission)
    {
        if (colission.CompareTag("CollectibleObject"))
        {
            Debug.Log("Puntos Obtenidos");
        }
        if (colission.CompareTag("DamageObject"))
        {
            Debug.Log("Daño recivido");
        }
    }
}
