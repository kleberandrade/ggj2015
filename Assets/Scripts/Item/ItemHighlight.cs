using UnityEngine;
using System.Collections;

public class ItemHighlight : MonoBehaviour
{
	private int collidingPlayers;
	private ItemHealth itemHealth;

	void Awake()
    {
        itemHealth = GetComponent<ItemHealth>();
		collidingPlayers = 0;
	}

	void OnTriggerEnter (Collider player)
    {
        if (!itemHealth.IsDestroyed() && player.tag == "Player")
        {
			if(collidingPlayers++ == 0)
				Highlight();
		}
	}
	
	void OnTriggerExit (Collider player)
    {
        if (!itemHealth.IsDestroyed() && player.tag == "Player")
        {
			if(--collidingPlayers == 0)
				Dehighlight();
		}
	}

	void Highlight()
    {
		//print ("highlighting");
	}

	void Dehighlight()
    {
		//print ("dehighlighting");
	}
}
