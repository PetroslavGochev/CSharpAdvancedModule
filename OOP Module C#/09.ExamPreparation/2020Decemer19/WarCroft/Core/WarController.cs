using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> itemPool;

		public WarController()
		{
			this.party = new List<Character>();
			this.itemPool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			if (characterType != "Priest" && characterType != "Warrior")
			{
				throw new ArgumentException($"Invalid character type \"{ characterType }\"!");
			}
			Character character = null;
			 if(characterType == "Priest")
            {
				character = new Priest(name);
            }
			else if(characterType == "Warrior")
            {
				character = new Warrior(name);
            }
			this.party.Add(character);
			return $"{character.Name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			if(itemName != "FirePotion" && itemName != "HealthPotion")
            {
				throw new ArgumentException($"Invalid item \"{ itemName }\"!");
			}
			Item item = null;
			if(itemName == "FirePotion")
            {
				item = new FirePotion();
            }
			else if(itemName == "HealthPotion")
            {
				item = new HealthPotion();
            }
			this.itemPool.Add(item);
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			if(!this.party.Any(x=>x.Name == characterName))
            {
				throw new ArgumentException($"Character {characterName} not found!");
			}
			else if (!this.itemPool.Any())
            {
				throw new InvalidOperationException("No items left in pool!");
            }

			Character character = this.party.FirstOrDefault(x => x.Name == characterName);
			Item item = this.itemPool.Last();
			this.itemPool.Remove(item);
			character.Bag.AddItem(item);
			return $"{character.Name} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			if(!this.party.Any(x=>x.Name == characterName))
            {
				throw new ArgumentException($"Character {characterName} not found!");
            }

			Character character = this.party.FirstOrDefault(x => x.Name == characterName);
			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);
			return $"{character.Name} used {item.GetType().Name}.";

		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
            foreach (var character in this.party.OrderByDescending(x=>x.IsAlive).ThenByDescending(x=>x.Health))
            {
				string status = character.IsAlive ? "Alive" : "Dead";
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, " +
					$"Status: {status}");
            }
			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			if(!this.party.Any(x=>x.Name == attackerName))
            {
				throw new ArgumentException($"Character {attackerName} not found!");
            }
			else if (!this.party.Any(x => x.Name == receiverName))
			{
				throw new ArgumentException($"Character {receiverName} not found!");
			}

			Warrior attacker = (Warrior)this.party.FirstOrDefault(x => x.Name == attackerName);
			Character receiver = this.party.FirstOrDefault(x => x.Name == receiverName);

            if (!attacker.IsAlive)
            {
				throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

			attacker.Attack(receiver);

			StringBuilder sb = new StringBuilder();

			sb.Append($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points!");
			sb.Append($"{receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and ");
			sb.AppendLine($"{receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive)
            {
				sb.Append($"{receiver.Name} is dead!");
			}
			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			if(!this.party.Any(x=>x.Name == healerName))
            {
				throw new ArgumentException($"Character {healerName} not found!");
            }
			else if (!this.party.Any(x => x.Name == healingReceiverName))
			{
				throw new ArgumentException($"Character {healingReceiverName} not found!");
			}

			Priest healer = (Priest)this.party.FirstOrDefault(x => x.Name == healerName);
			Character receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

            if (!healer.IsAlive)
            {
				throw new ArgumentException($"{healer.Name} cannot heal!");
            }

			healer.Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
