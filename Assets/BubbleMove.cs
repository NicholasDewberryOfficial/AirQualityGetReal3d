using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour
{
	public float speed;

	public Vector3 _directionVector;

	public List<Vector3> _listVector;



	// Start is called before the first frame update
	void Start()
	{
		_directionVector = Vector3.up;

		StartCoroutine(ChangeDirection());

		float bubbleD = Random.Range(1, 3); // Size of the bubble

		this.transform.localScale = new Vector3(bubbleD/10, bubbleD/10, bubbleD/10);
	}

	// Update is called once per frame
	void Update()
	{
		//transform.Translate(Vector3.left * Time.deltaTime * speed);

		this.gameObject.GetComponent<Rigidbody>().AddForce(_directionVector * Time.deltaTime);
	}


	IEnumerator ChangeDirection()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(1, 6));
			_directionVector = _listVector[Random.Range(0, 6)];
		}

	}


	private void OnMouseDown()
	{
		Destroy(this.gameObject);
	}
}
