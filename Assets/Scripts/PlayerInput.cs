using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera _mainCamera;
    // way to send other scripts the info about position selected using mouse
    public event Action<Vector3> OnMouseClick;

    public event Action<Vector3> OnDirectionInput; // New event for direction input

    private AgentMover _agentMover;

    float moveHorizontal;
    float moveVertical;


    // raycast onto selected plains
    RaycastHit _HitInfo = new();
    public LayerMask _movable;

    private void Awake() {
      _agentMover = GetComponent<AgentMover>();
    }

    private void Start() {
      _mainCamera = Camera.main; // Cache the main camera for better performance
    }

    private void Update() {
      if(Input.GetMouseButtonDown(0)) {
        // create raycast on where we clicked
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray.origin, ray.direction, // ray.origin, ray.direction -> camera towards the ground
        out _HitInfo, 100, _movable)) { // save info in _Hitinfo; 100 distance from camera, _movable -> filter to only detect objects on this layer
          OnMouseClick?.Invoke(_HitInfo.point);
          Debug.Log($"Selected position is + {_HitInfo.point}");
        }
      }
      HandleKeyboardInput();
    }

    private void HandleKeyboardInput()
{
    moveHorizontal = Input.GetAxisRaw("Horizontal");
    moveVertical = Input.GetAxisRaw("Vertical");

    // Get the camera's forward and right vectors, but ignore the vertical component
    Vector3 forward = _mainCamera.transform.forward;
    forward.y = 0;
    Vector3 right = _mainCamera.transform.right;
    right.y = 0;

    // Normalize the vectors to keep consistent movement speed
    forward.Normalize();
    right.Normalize();

    // Calculate the movement direction relative to the camera's orientation
    Vector3 movementDir = (forward * moveVertical) + (right * moveHorizontal);

    if (movementDir != Vector3.zero)
    {
        OnDirectionInput?.Invoke(movementDir);

        // Interrupt point-and-click movement
         _agentMover.InterruptPointAndClickMovement();
    }
}
}
