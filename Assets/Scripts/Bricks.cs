using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject brickTemplate;
    Color[] colors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 11; x++)
            {
                GameObject brick = Instantiate(brickTemplate);

                brick.transform.position = new Vector3(x, y * 0.5f) + new Vector3(-5, 6.5f);

                SpriteRenderer renderer = brick.GetComponent<SpriteRenderer>();
                renderer.material.color = colors[y];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
