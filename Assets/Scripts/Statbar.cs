using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statbar : MonoBehaviour
{
	private Image content;
	[SerializeField] private float lerpSpeed;
	[SerializeField] private Text statValue;
	private float currentFill;
	private float currentValue;
	public float MaxValue { get; set; }
	public float CurrentValue
	{
		get
		{
			return currentValue;
		}
		set
		{
			if (value > MaxValue)
			{
				currentValue = MaxValue;
			}
			else if (value < 0)
			{
				currentValue = 0;
			}
			else
			{
				currentValue = value;
			}

			currentFill = currentValue / MaxValue;
			statValue.text = currentValue.ToString() + " / " + MaxValue.ToString();
		}
	}

	void Start ()
	{
		MaxValue = 100;
		content = GetComponent<Image> ();
		content.fillAmount = 0.5f;
	}

	void Update ()
	{
		if (currentFill != content.fillAmount)
		{
			content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, lerpSpeed * Time.deltaTime);
		}
		//content.fillAmount = currentFill;
	}

	public void Initialize (float currentValue, float maxValue)
	{
		this.MaxValue = maxValue;
		this.currentValue = currentValue;
	}
}