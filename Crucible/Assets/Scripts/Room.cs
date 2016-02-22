using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
	public class Room {
		//Room class to store global information of various generated rooms.
		//Can be altered to store a room name or specific state.

		private int width, height;
		private Vector2 startPos;
		private Vector2 centre;

		public Room(Vector2 StartPos, int Width, int Height) {
			startPos = StartPos;
			width = Width;
			height = Height;

			//centre = new Vector2((),())
		}
	}
}
