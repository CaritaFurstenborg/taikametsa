using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Odiana
{
	public class Player : Character
	{
		[SerializeField] private Statbar health;
		[SerializeField] private Statbar resource;
		[SerializeField] private float maxHealth;
		[SerializeField] private float maxResource;
		protected override void Start()
		{
			health.Initialize(maxHealth, maxHealth);
			resource.Initialize(maxResource, maxResource);
			base.Start();
		}
		protected override void Update ()
		{
			GetInput ();
			base.Update ();
		}

		private void GetInput ()
		{
			direction = Vector2.zero;

			//DEBUGGING ONLY
			if(Input.GetKeyDown(KeyCode.I))
			{
				health.CurrentValue -= 3;
			}
			if(Input.GetKeyDown(KeyCode.O))
			{
				health.CurrentValue += 3;
			}

			if (Input.GetKey (KeyCode.A))
			{
				direction += Vector2.left;
			}
			if (Input.GetKey (KeyCode.D))
			{
				direction += Vector2.right;
			}
			if (Input.GetKey (KeyCode.W))
			{
				direction += Vector2.up;
			}
			if (Input.GetKey (KeyCode.S))
			{
				direction += Vector2.down;
			}
		}
	}
}