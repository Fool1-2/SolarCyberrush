using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveWithMouse : MonoBehaviour
{
    SpriteRenderer spriteR;
    const float _SPEED = 15f;

    [SerializeField]private Camera _cam;

    Vector2 _movement;
    Vector2 _ZERO = new Vector2(500, 300);  
    Rigidbody2D _rb;
    [SerializeField, Tooltip("Click this when its used for puzzles too")]private bool isPuzzleCursor;
    public bool isController;

    private void Start() {
        spriteR = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isController)
        {
            if (isPuzzleCursor)
            {
                transform.Translate(_movement * _SPEED * Time.deltaTime);
                var mouse = Mouse.current;
                mouse.WarpCursorPosition(_cam.WorldToScreenPoint(transform.position));
                Vector2 vec = _cam.WorldToScreenPoint(transform.position);
                if (vec.x < 0)
                {
                    mouse.WarpCursorPosition(_cam.WorldToScreenPoint(_ZERO));
                    transform.position = _cam.ScreenToWorldPoint(_ZERO);
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                }
                else if (vec.x > 1050)
                {
                    mouse.WarpCursorPosition(_cam.WorldToScreenPoint(_ZERO));
                    transform.position = _cam.ScreenToWorldPoint(_ZERO);
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                }
    
                if (vec.y > 600)
                {
                    mouse.WarpCursorPosition(_cam.WorldToScreenPoint(_ZERO));
                    transform.position = _cam.ScreenToWorldPoint(_ZERO);
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                }
                else if (vec.y < 0)
                {
                    mouse.WarpCursorPosition(_cam.WorldToScreenPoint(_ZERO));
                    transform.position = _cam.ScreenToWorldPoint(_ZERO);
                    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                }
            }
            
            if(!isPuzzleCursor)
            {
                if (Glow.isGlowActive)
                {
                    spriteR.enabled = true;
                    transform.Translate(_movement * _SPEED * Time.deltaTime);
                    var mouse = Mouse.current;
                    mouse.WarpCursorPosition(_cam.WorldToScreenPoint(transform.position));
                    Vector2 vec = _cam.WorldToScreenPoint(transform.position);
                    if (vec.x < 0)
                    {
                        mouse.WarpCursorPosition(_cam.WorldToScreenPoint(_ZERO));
                        transform.position = _cam.ScreenToWorldPoint(_ZERO);
                        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    }
                    else if (vec.x > 1050)
                    {
                        mouse.WarpCursorPosition(_cam.WorldToScreenPoint(_ZERO));
                        transform.position = _cam.ScreenToWorldPoint(_ZERO);
                        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    }
    
                    if (vec.y > 600)
                    {
                        mouse.WarpCursorPosition(_cam.WorldToScreenPoint(_ZERO));
                        transform.position = _cam.ScreenToWorldPoint(_ZERO);
                        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    }
                    else if (vec.y < 0)
                    {
                        mouse.WarpCursorPosition(_cam.WorldToScreenPoint(_ZERO));
                        transform.position = _cam.ScreenToWorldPoint(_ZERO);
                        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    }
                }
                else
                {
                    spriteR.enabled = false;
                }
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Vector2 newPos = _cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = newPos;
        }
        
    }

    private void FixedUpdate() => _rb.AddForce(_movement * _SPEED * Time.deltaTime);

    public void OnMove(InputValue v) => _movement = v.Get<Vector2>();
    
}
