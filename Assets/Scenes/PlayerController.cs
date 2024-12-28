using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 5;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveTowardsMousePosition();
        }
    }

    private void MoveTowardsMousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPosition = transform.position;

        transform.position = Vector2.MoveTowards(currentPosition, mousePosition, moveSpeed * Time.deltaTime);

    }
}
