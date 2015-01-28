using UnityEngine;
using System.Collections;

/// <summary>
/// Classe para não destruir os objetos
/// </summary>
[AddComponentMenu("Scripts/Helper/ObjectKeeper")]
public class ObjectKeeper : MonoBehaviour 
{
    /// <summary>
    /// Método Awake
    /// </summary>
	void Awake() 
    {
		DontDestroyOnLoad(transform.gameObject);
	}

}
