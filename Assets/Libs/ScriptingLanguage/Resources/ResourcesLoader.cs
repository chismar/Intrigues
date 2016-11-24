using UnityEngine;
using System.Collections;
using System;

public abstract class ResourcesLoader : MonoBehaviour
{
	public abstract void LoadResources (Action onFinished);
}



