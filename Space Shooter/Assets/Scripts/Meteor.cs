using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] GameManager manager;

    private bool collisionDestroyed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float speedLevel = 1f + Time.timeSinceLevelLoad / 30f;

        transform.position -= new Vector3(0, speed * speedLevel * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionDestroyed = true;

        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.ApplyDamage(20);
        }
        else
        {
            Destroy(collision.gameObject);
        }
        
        Destroy(gameObject);
    }
}
