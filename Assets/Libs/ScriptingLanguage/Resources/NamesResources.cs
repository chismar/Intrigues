using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.IO;

public class NamesResources : MonoBehaviour
{

	Dictionary<string, List<string>> names = new Dictionary<string, List<string>> ();

	void Awake ()
	{

		var nameFiles = Directory.GetFiles ((Application.isEditor ? "Assets/" : BasicLoader.ProjectPrefix + "_Data/") + "StreamingAssets/Mods/names");
		foreach (var nameFile in nameFiles)
		{
            if (nameFile.EndsWith(".meta"))
                continue;
			var lines = File.ReadAllLines (nameFile);

			var typeLine = lines [0];
			var typePart = typeLine.Split ('=') [1];

			List<string> list = null;
			if (!names.TryGetValue (typePart, out list))
			{
				list = new List<string> ();
				names.Add (typePart, list);
			}
			for (int i = 1; i < lines.Length; i++)
			{
				if (lines [i] != "")
					list.Add (lines [i]);
			}
		}
		FindObjectOfType<BasicLoader> ().EFunctions.Add (new BasicLoader.ExternalFunctions (this, "RandomName"));
	}

	System.Random random = new System.Random ();

	public string RandomName (string type)
	{
		List<string> list = null;
		if (!names.TryGetValue (type, out list))
			return "no_such_category " + type;
		
		return list [random.Next (0, list.Count)];
	}
}

