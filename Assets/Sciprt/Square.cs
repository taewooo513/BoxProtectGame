using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        float randX = Random.Range(-3f, 3f), randY = Random.Range(3f, 5f);
        float randSize = Random.Range(.5f, 1.5f);
        this.transform.position = new Vector3(randX, randY, 0);
        this.transform.localScale = new Vector2(randSize, randSize);

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnBecameInvisible()
    {
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.GetGameManager().EndGame();
            Destroy(this.gameObject);
        }
    }

}
