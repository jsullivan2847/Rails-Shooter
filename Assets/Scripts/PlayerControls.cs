using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;
    [SerializeField] float speed;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;

        // float horizontalThrow = Input.GetAxis("Horizontal");
        // Debug.Log(horizontalThrow); 

        // float verticalThrow = Input.GetAxis("Vertical");
        // Debug.Log(verticalThrow); 

        float xOffset = xThrow * Time.deltaTime * speed;
        float yOffset = yThrow * Time.deltaTime * speed;

        float rawXPos = xOffset + transform.localPosition.x;
        float rawYPos = yOffset + transform.localPosition.y;

        float newXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float newYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        
        transform.localPosition = new Vector3 (
        newXPos,newYPos,transform.localPosition.z);
    }

    void OnEnable(){
        movement.Enable();
    }
    void OnDisable(){
        movement.Disable();
    }
}
