using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    public AudioClip chopSound1;                
    public AudioClip chopSound2;                
    public Sprite dmgSprite;                    
    public int hp = 3;                          


    private SpriteRenderer spriteRenderer;


    void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        
    }
}
