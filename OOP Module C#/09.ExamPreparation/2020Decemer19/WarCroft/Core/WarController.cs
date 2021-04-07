using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
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
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType), characterType);
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
			return String.Format(String.Format(SuccessMessages.JoinParty, character.Name));
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			if(itemName != "FirePotion" && itemName != "HealthPotion")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem), itemName);
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
			return String.Format(String.Format(SuccessMessages.AddItemToPool, itemName));
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			if(!this.party.Any(x=>x.Name == characterName))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), characterName);
			}
			else if (!this.itemPool.Any())
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			Character character = this.party.FirstOrDefault(x => x.Name == characterName);
			Item item = this.itemPool.Last();
			this.itemPool.Remove(item);
			character.Bag.AddItem(item);
			return String.Format(String.Format(SuccessMessages.PickUpItem, character.Name, item.GetType().Name));
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			if(!this.party.Any(x=>x.Name == characterName))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), characterName);
            }

			Character character = this.party.FirstOrDefault(x => x.Name == characterName);
			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);
			return String.Format(String.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name));

		}

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var character in this.party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                string status = character.IsAlive ? "Alive" : "Dead";
                sb.AppendLine(String.Format(SuccessMessages.CharacterStats,
                   character.Name, character.Health,
                   character.BaseHealth, character.Armor,
                   character.BaseArmor, status));
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            if (!this.party.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), attackerName);

            }
            else if (!this.party.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), receiverName);
            }

            Warrior attacker = (Warrior)this.party.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = this.party.FirstOrDefault(x => x.Name == receiverName);

            if (!attacker.IsAlive)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has " +
                $"{receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
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

            if (!this.party.Any(x => x.Name == healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), healerName);
            }
            else if (!this.party.Any(x => x.Name == healingReceiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), healingReceiverName);
            }
            if (this.party.FirstOrDefault(x=>x.Name == healerName).GetType().Name != "Priest")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            Priest healer = (Priest)this.party.FirstOrDefault(x => x.Name == healerName);
            Character receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

            
            StringBuilder sb = new StringBuilder();
            healer.Heal(receiver);
            sb.AppendLine(String.Format(SuccessMessages.HealCharacter,
              healer.Name, receiver.Name, healer.AbilityPoints,
              receiver.Name, receiver.Health));
            return sb.ToString().TrimEnd();
        }
        
	}
}

