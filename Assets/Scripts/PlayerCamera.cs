using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Odiana
{
	public class PlayerCamera : MonoBehaviour
	{
		private int playerId;
		private Transform player;
		private Vector3 minCamPos;
		private Vector3 maxCamPos;

		void Awake ()
		{
			player = FindObjectOfType<Player>().transform;
		}

		void LateUpdate()
		{
			//transform.position = new Vector3(Mathf.Clamp(player, minCamPos, maxCamPos));
		}

		private void SetLimits(Vector3 minPos, Vector3 maxPos)
		{
			Camera cam = Camera.main;
			minCamPos = minPos;
			maxCamPos = maxPos;
		}
	}
}