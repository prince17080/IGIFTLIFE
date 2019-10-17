using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragNDrop : MonoBehaviour
{
	Vector3 startPos;
	Vector3 holderPos;
	bool flag, overSprite;
	public bool Valid;
	public GameObject Holder;
	public GameObject Label;
	private GameObject Life1;
	private GameObject Life2;
	private GameObject Life3;
	private bool isBeingHeld, lifeLost;

	// Use this for initialization
	void Start()
	{
		holderPos = Holder.transform.position;
		flag = false;
		lifeLost = true;
		startPos = this.transform.position;
		Life1 = GameObject.FindGameObjectWithTag("life1");
		Life2 = GameObject.FindGameObjectWithTag("life2");
		Life3 = GameObject.FindGameObjectWithTag("life3");
	}

	// Update is called once per frame
	void Update()
	{
		if (!flag)
		{
			if (isBeingHeld)
			{
				Vector3 mp = Input.mousePosition;
				mp.z = 10;
				mp = Camera.main.ScreenToWorldPoint(mp);
				this.transform.position = new Vector3(mp.x, mp.y, 0);
				Label.SetActive(false);
				overSprite = Holder.GetComponent<SpriteRenderer>().bounds.Contains(this.transform.position);
			}
			else
			{
				this.transform.position = startPos;
				Label.SetActive(true);
			}


			if (overSprite)
			{
				if (Valid)
				{
					this.transform.position = new Vector3(holderPos.x, holderPos.y, 0);
					Holder.SetActive(false);
					Label.SetActive(false);
					flag = true;
				}
				else
				{
					this.transform.position = startPos;
					Label.SetActive(true);
					overSprite = false;
					if (lifeLost)
					{
						lifeLost = false;
						if (Life3.active)
						{
							Life3.SetActive(false);
						}
						else if (Life2.active)
						{
							Life2.SetActive(false);
						}
						else if (Life1.active)
						{
							Life1.SetActive(false);
							SceneManager.LoadScene("SceneFinal");
						}
					}
				}
			}
		}
	}

	private void OnMouseDown()
	{
		if (!flag && Input.GetMouseButtonDown(0))
		{
			isBeingHeld = true;
		}
	}

	private void OnMouseUp()
	{
		isBeingHeld = false;
		lifeLost = true;
	}
}
