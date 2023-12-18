using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ballscript : MonoBehaviour
{

    Rigidbody RB;
    int hp = 3;

    int blockDestroyed = 0;

    [SerializeField]
    private GameObject heart1;

    [SerializeField]
    private GameObject heart2;

    [SerializeField]
    private GameObject heart3;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject gameWin;

    [SerializeField]
    private TextMeshProUGUI blockHitScore;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, 4, 0);
        RB.AddForce(new Vector3(0, -0.1f, 0));
        gameOver.SetActive(false);
        gameWin.SetActive(false);
        blockHitScore.text = "Score: " + blockDestroyed;

    }

    // Update is called once per frame
    void Update()
    {
        float speed = 4;
        RB.velocity = RB.velocity.normalized * speed;

    }

    public void TakeDamage()
    {

        hp -= 1;

        if (hp == 2)
        {

            Destroy(heart3);

        }
        if (hp == 1)
        {

            Destroy(heart2);

        }
        if (hp == 0)
        {

            Destroy(heart1);
            Destroy(gameObject);
            gameOver.SetActive(true);

        }

        transform.position = new Vector3(0, 4, 0);
        RB.AddForce(new Vector3(0, -0.3f, 0));

    }

    public void winCondition()
    {

        blockDestroyed += 1;

        blockHitScore.text = "Score: " + blockDestroyed;

        if (blockDestroyed == 84)
        {

            gameWin.SetActive(true);

        }

    }
}
