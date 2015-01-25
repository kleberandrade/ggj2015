using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ItemHighlight))]
[RequireComponent(typeof(ItemExplode))]
[RequireComponent (typeof(ItemBehavior))]
public class ItemHealth : MonoBehaviour 
{
    public int life = 10;

    private ItemExplode itemExplode;
    private ItemBehavior itemBehavior;

    void Awake()
    {
        itemExplode = GetComponent<ItemExplode>();
        itemBehavior = GetComponent<ItemBehavior>();
    }

    public bool IsDestroyed()
    {
        return life < 1;
    }

    public void Hit(int hit)
    {
        if (IsDestroyed())
            return;

        life -= hit;
       // if (IsDestroyed())
           // itemExplode.Destroy();
        //else
       //     itemBehavior.Behave();
    }
}
