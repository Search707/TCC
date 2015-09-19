using UnityEngine;
using System.Collections;

public class Warrior : Character
{
	public Warrior WarriorConstructor()
	{
		characterClass = CharacterClass.WARRIOR;

		characterName = "Warrior";

		healthPoints = 1000;
		maxHealthPoints = 1000;
		baseDamage = 100;

		return this;
	}
}
