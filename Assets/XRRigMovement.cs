using UnityEngine;

public class XRRigMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // Left/Right input
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   // Forward/Backward input

        // Move the rig
        transform.Translate(new Vector3(moveX, 0, moveZ));

        // Simulate head rotation with mouse
        float rotateY = Input.GetAxis("Mouse X") * moveSpeed * 10f;
        transform.Rotate(0, rotateY, 0);
    }
}