using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] float laserSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, laserSpeed, 0) * Time.deltaTime;
    }
}
