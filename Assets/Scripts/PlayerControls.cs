using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 20f;
    [SerializeField] private float xRange = 9.5f;
    [SerializeField] private float yTopLimit = 12f;
    [SerializeField] private float yBottomLimit = -4f;

    [Header("Rotation")]
    [SerializeField] private float positionXRotationFactor = -2f;
    [SerializeField] private float controlXRotationFactor = -10f;
    [SerializeField] private float yRotationFactor = 1.5f;
    [SerializeField] private float zRotationFactor = -20f;
    
    private float _xThrow;
    private float _yThrow;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        var localPosition = transform.localPosition;
        _xThrow = Input.GetAxis("Horizontal");
        _yThrow = Input.GetAxis("Vertical");
        var xOffset = _xThrow * controlSpeed * Time.deltaTime;
        var yOffset = _yThrow * controlSpeed * Time.deltaTime;
        var newXPos = Mathf.Clamp(localPosition.x + xOffset, -xRange, xRange);
        var newYPos = Mathf.Clamp(localPosition.y + yOffset, yBottomLimit, yTopLimit);

        transform.localPosition = new Vector3(newXPos, newYPos);
    }

    private void ProcessRotation()
    {
        var localPosition = transform.localPosition;
        
        var xRotationDueToPosition = localPosition.y * positionXRotationFactor;
        var xRotationDueToControl = _yThrow * controlXRotationFactor;
        var xRotation = xRotationDueToPosition + xRotationDueToControl;

        var yRotation = localPosition.x * yRotationFactor;

        var zRotation = _xThrow * zRotationFactor;
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }
}