using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xRange = 10f;
    [SerializeField] private float yTopLimit = 11f;
    [SerializeField] private float yBottomLimit = -3f;

    // Update is called once per frame
    void Update()
    {
        var localPosition = transform.localPosition;
        var xThrow = Input.GetAxis("Horizontal");
        var yThrow = Input.GetAxis("Vertical");
        var xOffset = xThrow * controlSpeed * Time.deltaTime;
        var yOffset = yThrow * controlSpeed * Time.deltaTime;
        var newXPos = Mathf.Clamp(localPosition.x + xOffset, -xRange, xRange);
        var newYPos = Mathf.Clamp(localPosition.y + yOffset, yBottomLimit, yTopLimit);

        transform.localPosition = new Vector3(newXPos, newYPos);
    }
}