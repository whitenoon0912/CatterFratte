using UnityEngine;

public class CameraManagerls : MonoBehaviour
{
    public Transform player;
    public float distance = 5f;
    public float height = 4f;
    public float sensitivity = 5f;

    private float currentXAngle = 0f;
    private float currentYAngle = 0f;
    private float maxXAngle = 50f;
    private float minXAngle = -50f;
    public bool NGaction = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null || NGaction) return;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        currentYAngle += mouseX;
        currentXAngle -= mouseY;

        currentXAngle = Mathf.Clamp(currentXAngle, minXAngle, maxXAngle);

        Quaternion rotation = Quaternion.Euler(currentXAngle, currentYAngle, 0);

        Vector3 offset = new Vector3(0, height, -distance);

        transform.position = player.transform.position + rotation * offset;

        transform.LookAt(player.position, Vector3.up * 1.5f);
    }
}
