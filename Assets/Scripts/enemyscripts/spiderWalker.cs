using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderWalker : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    Rigidbody2D mybody;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacingLeft())
        {
            mybody.velocity = new Vector2(-speed, 0f);
        }
        else
        {
            mybody.velocity = new Vector2(speed, 0f);
        }
        
    }

    private bool isFacingLeft()
    {
        return transform.localScale.x < 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-Mathf.Sign(mybody.velocity.x), transform.localScale.y);
    }
}
