using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    float yPos;
    [SerializeField] GameObject laser;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 convertedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(convertedPosition.x, yPos, 0);

        if(Input.GetButtonDown("FireLaser"))
        {
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }
}
