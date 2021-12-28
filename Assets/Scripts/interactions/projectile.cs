using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    player player;
    Rigidbody2D rb;
    bool kunaiLeft = false;
    [SerializeField] GameObject destroyVfx;
    [SerializeField] AudioClip DestroySfx;
    [SerializeField] AudioClip dirtSfx;
    [SerializeField] int damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<player>();

        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        setKunaiDirection();
        flipKunaiSprite();
        SelfDestroy();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        BossHealth enemy = other.GetComponent<BossHealth>();
        if (other.gameObject.tag=="enemy" || other.gameObject.tag=="hazards")
        {
            Destroy(other.gameObject);
            GameObject destroyVFX = Instantiate(destroyVfx, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(DestroySfx, transform.position);
            Destroy(gameObject);
            Destroy(destroyVFX, 1f);

        }    
        else if(enemy)
        {
            enemy.TakeDamage(damage);
            GameObject destroyVFX = Instantiate(destroyVfx, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(DestroySfx, transform.position);
            Destroy(gameObject);
            Destroy(destroyVFX, 1f);
        }
        else if(other.gameObject.tag=="Ground")
        {
            Destroy(gameObject);
            GameObject destroyVFX = Instantiate(destroyVfx, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(dirtSfx, transform.position);
            Destroy(destroyVFX, 1f);
        }
        
        
    }

    private void SelfDestroy()
    {
        Destroy(gameObject, 2f);
    }
    private void setKunaiDirection()
    {
        if (player.transform.localScale.x<0)
        {
            kunaiLeft = true;
        }
        else if (player.transform.localScale.x > 0)
        {
            kunaiLeft = false;
        }
    }
    private void flipKunaiSprite()
    {
        if (kunaiLeft)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
    }
}
