using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    public float speed = 5f;
    
    public string movementAxisName = "Vertical";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        if (isPlayer)
        {
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveController.Instance.colorEnemy;
        }
    }
    void Update()
    {
        float moveInput = Input.GetAxis(movementAxisName);
    
        // Calculate new position based on speed and input
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        
        // Limit vertical position so that paddle does not leave screen
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);
        
        // Update paddle position
        transform.position = newPosition;
    }
}
