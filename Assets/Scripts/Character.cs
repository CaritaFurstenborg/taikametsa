using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Odiana
{
	public abstract class Character : MonoBehaviour
	{
		protected Vector2 direction;
		[SerializeField] private float speed;
		private Animator animator;
		private Rigidbody2D rigidBod;

		public bool IsMoving
		{
			get
			{
				return direction.x != 0 || direction.y != 0;
			}
		}

		protected virtual void Start ()
		{
			rigidBod = GetComponent<Rigidbody2D> ();
			animator = GetComponent<Animator> ();
		}

		protected virtual void Update ()
		{
			HandleAnimLayers ();
		}

		private void FixedUpdate ()
		{
			Move ();
		}

		public void Move ()
		{
			rigidBod.velocity = direction.normalized * speed;
		}

		public void HandleAnimLayers ()
		{
			if(IsMoving)
			{
				Animate (direction);
			}			
		}

		public void Animate (Vector2 dir)
		{
			animator.SetFloat ("x", direction.x);
			animator.SetFloat ("y", direction.y);
		}

		public void ActivateAnimLayer(string layerName)
		{
			for(int i = 0; i < animator.layerCount; i++)
			{
				animator.SetLayerWeight(i, 0);
			}
			
			animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
		}
	}
}