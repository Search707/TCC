using UnityEngine;
using System.Collections;

public class TownCharactersManager : MonoBehaviour
{
	public Warrior warrior;
	public Archer archer;

	public Character CreateNewCharacter(Character.CharacterClass p_characterClass)
	{
		switch(p_characterClass)
		{
			case Character.CharacterClass.WARRIOR: return warrior.WarriorConstructor();
			case Character.CharacterClass.ARCHER:  return archer.ArcherConstructor();

			default: return null;
		}
	}
}
