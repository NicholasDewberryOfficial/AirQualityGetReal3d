using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatBubble : MonoBehaviour
{

	public List<GameObject> _bubbleObj;
	public GameObject _parent;
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(IenumCreatBubble());
	}

	// Update is called once per frame
	void Update()
	{

	}

	IEnumerator IenumCreatBubble()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.RandomRange(1, 5));// Time between two bubbles
			Instantiate(_bubbleObj[Random.RandomRange(0,_bubbleObj.Count)],_parent.transform);

		}
	}
}
