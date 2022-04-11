using UnityEngine;

public class Cloud : MonoBehaviour
{
    private Rigidbody2D rb;

    [Range(1f, 4f)]
    public float speed = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    private void LateUpdate()
    {
        // Shitty way to do it but it's for a game jam
        if (transform.position.x < -52f)
        {
            float randomX = Random.Range(80f, 100f);
            float randomY = Random.Range(-3f, 17f);
            float speed = Random.Range(1, 3);
            transform.position = new Vector3(randomX, randomY, 3);
            rb.velocity = new Vector2(-speed, 0);
        } 
    }
}
