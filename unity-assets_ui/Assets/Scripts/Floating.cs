using UnityEngine;

public class Floating : MonoBehaviour
{
    public enum Direction {X, Y};
    public float intensity = 1.0f;
    public Direction direction = Direction.Y; 

    private float phaseOffset;
    private Vector3 initialPosition;

    void Start()
    {
        phaseOffset = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
        initialPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(direction == Direction.Y)
        {
        transform.position = new Vector3(
            transform.position.x,
            initialPosition.y + Mathf.Cos(Time.time + phaseOffset) * intensity,
            transform.position.z);
        }
        if(direction == Direction.X)
        {
            transform.position = new Vector3(
            initialPosition.x + Mathf.Cos(Time.time + phaseOffset) * intensity,
            transform.position.y,
            transform.position.z);
        }
    }
}
