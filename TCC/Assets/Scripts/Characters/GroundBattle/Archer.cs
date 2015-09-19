using UnityEngine;
using System.Collections;

public class Archer : Character
{
	public Archer ArcherConstructor()
	{
		characterClass = CharacterClass.ARCHER;
		
		characterName = "Archer";
		
		healthPoints = 600;
		maxHealthPoints = 600;
		baseDamage = 100;
		
		return this;
	}
}
