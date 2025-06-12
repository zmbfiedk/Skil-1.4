using UnityEngine;

public class TankController : MonoBehaviour
{
    [Header("Beweging")]
    private Vector3 velocity;
    private Vector3 direction;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float rotationSpeed = 100f;
    private Animator anim;

    private Vector2 min;
    private Vector2 max;
    
    public float SP { get {  return speed; }}

    void Start()
    {
        min = Camera.main.ScreenToWorldPoint(Vector2.zero);
        max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0f, 0f, -horizontal * rotationSpeed * Time.deltaTime); 

        float vertical = Input.GetAxis("Vertical");
        speed += vertical * acceleration;

        direction = transform.right; 
        velocity = direction * speed;
        transform.position += velocity * Time.deltaTime;

        Vector3 pos = transform.position;
        if (pos.x > max.x) pos.x = min.x;
        if (pos.x < min.x) pos.x = max.x;
        if (pos.y > max.y) pos.y = min.y;
        if (pos.y < min.y) pos.y = max.y;
        transform.position = pos;
    }
}
