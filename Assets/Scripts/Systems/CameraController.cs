using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Map map;
    public Transform cameraTransform;

    public float zoomSpeed = 1f;
    public float panSpeed = 0.08f;
    public float rotationSpeed = 0.2f;
    public float smoothing = 10.0f;

    public float cameraDistanceMin = 10f;
    public float cameraDistanceMax = 100f;
    public float cameraDistanceStart = 60f;
    public float cameraDistanceSpeed = 10f;
    private float cameraDistance = 1.0f;

    private Vector2 panInput = Vector2.zero;
    private float zoomInput = 0f;
    private float rotateInput = 0f;

    private bool dragIndicator = false;
    private bool rotateIndicator = false;

    private InputMaster controls;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private Vector3 dragStart;
    private Vector3 drag;


    void Awake()
    {
        controls = new InputMaster();
    }

    private void OnEnable()
    {
        controls.CameraRig.Pan.performed += OnPan;
        controls.CameraRig.Zoom.performed += OnZoom;
        controls.CameraRig.Rotate.performed += OnRotate;
        controls.CameraRig.DragIndicator.performed += OnDragIndicator;
        controls.CameraRig.RotateIndicator.performed += OnRotateIndicator;
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.CameraRig.Pan.performed -= OnPan;
        controls.CameraRig.Zoom.performed -= OnZoom;
        controls.CameraRig.Rotate.performed -= OnRotate;
        controls.CameraRig.DragIndicator.performed -= OnDragIndicator;
        controls.CameraRig.RotateIndicator.performed -= OnRotateIndicator;
    }

    void Start()
    {
        cameraDistance = cameraDistanceStart;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        UpdateTransforms();
    }

    void UpdateTransforms()
    {
        Vector3? coordinate = map.MouseToCoordinate();

        if (dragIndicator && coordinate != null)
        {
            drag = coordinate.GetValueOrDefault();
            targetPosition = transform.position + dragStart - drag;
        }

        targetPosition += transform.rotation * new Vector3(panInput.x, 0, panInput.y) * panSpeed;

        targetPosition.x = Mathf.Clamp(targetPosition.x, 0f, map.GetWidth());
        targetPosition.z = Mathf.Clamp(targetPosition.z, 0f, map.GetLength());

        Vector3 newCameraDistance = transform.InverseTransformDirection(cameraTransform.forward) * -cameraDistance;

        if (rotateIndicator)
        {
            targetRotation *= Quaternion.Euler(Vector3.up * rotationSpeed * rotateInput);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothing * Time.deltaTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newCameraDistance, cameraDistanceSpeed * Time.deltaTime);
    }

    void OnPan(InputAction.CallbackContext ctx)
    {
        panInput = ctx.ReadValue<Vector2>();
    }

    void OnZoom(InputAction.CallbackContext ctx)
    {
        zoomInput = ctx.ReadValue<float>();
        cameraDistance += -zoomInput;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
    }

    void OnRotate(InputAction.CallbackContext ctx)
    {
        rotateInput = ctx.ReadValue<float>();
    }

    void OnDragIndicator(InputAction.CallbackContext ctx)
    {
        dragIndicator = ctx.ReadValue<float>() > .5f;

        Vector3? coordinate = map.MouseToCoordinate();
        if (dragIndicator && coordinate != null)
        {
            dragStart = coordinate.GetValueOrDefault();
        }
    }
    void OnRotateIndicator(InputAction.CallbackContext ctx)
    {
        rotateIndicator = ctx.ReadValue<float>() >.5f;
    }
}
