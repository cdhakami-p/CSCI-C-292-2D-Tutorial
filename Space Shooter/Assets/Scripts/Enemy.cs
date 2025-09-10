using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed = 10.0f;
    [SerializeField] GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.InitiateGameOver();
        } else
        {
            GameManager.instance.IncreaseScore(10);
        }
       
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
