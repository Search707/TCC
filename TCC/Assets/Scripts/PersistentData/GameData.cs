using UnityEngine;
using System.Collections;

public static class GameData
{
	public struct Battle
	{
		public static readonly int totalActionsAllowded = 3;
	}

	public struct Cannon
	{
		public static readonly int maxHp = 1000;
		public static readonly int baseDamage = 100;
		public static readonly float actionTime = 2.0f;
	}

	public struct SmallCannon
	{
		public static readonly int maxHp = 500;
		public static readonly int baseDamage = 50;
		public static readonly float actionTime = 1.0f;
	}
}
