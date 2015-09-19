using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	public enum CharacterClass
	{
		WARRIOR,
		ARCHER
	}

	protected CharacterClass characterClass;

	protected string characterName;

	protected int healthPoints;
	protected int maxHealthPoints;
	protected int baseDamage;
}
