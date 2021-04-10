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
    //public class WarController
    //{
    //	private List<Character> party;
    //	private List<Item> itemPool;

    //	public WarController()
    //	{
    //		this.party = new List<Character>();
    //		this.itemPool = new List<Item>();
    //	}

    //	public string JoinParty(string[] args)
    //	{
    //		string characterType = args[0];
    //		string name = args[1];

    //		if (characterType != "Priest" && characterType != "Warrior")
    //		{
    //			throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType), characterType);
    //		}
    //		Character character = null;
    //		 if(characterType == "Priest")
    //           {
    //			character = new Priest(name);
    //           }
    //		else if(characterType == "Warrior")
    //           {
    //			character = new Warrior(name);
    //           }
    //		this.party.Add(character);
    //		return String.Format(String.Format(SuccessMessages.JoinParty, character.Name));
    //	}

    //	public string AddItemToPool(string[] args)
    //	{
    //		string itemName = args[0];
    //		if(itemName != "FirePotion" && itemName != "HealthPotion")
    //           {
    //			throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem), itemName);
    //		}
    //		Item item = null;
    //		if(itemName == "FirePotion")
    //           {
    //			item = new FirePotion();
    //           }
    //		else if(itemName == "HealthPotion")
    //           {
    //			item = new HealthPotion();
    //           }
    //		this.itemPool.Add(item);
    //		return String.Format(String.Format(SuccessMessages.AddItemToPool, itemName));
    //	}

    //	public string PickUpItem(string[] args)
    //	{
    //		string characterName = args[0];
    //		if(!this.party.Any(x=>x.Name == characterName))
    //           {
    //			throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), characterName);
    //		}
    //		else if (!this.itemPool.Any())
    //           {
    //			throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
    //           }

    //		Character character = this.party.FirstOrDefault(x => x.Name == characterName);
    //		Item item = this.itemPool.Last();
    //		this.itemPool.Remove(item);
    //		character.Bag.AddItem(item);
    //		return String.Format(String.Format(SuccessMessages.PickUpItem, character.Name, item.GetType().Name));
    //	}

    //	public string UseItem(string[] args)
    //	{
    //		string characterName = args[0];
    //		string itemName = args[1];

    //		if(!this.party.Any(x=>x.Name == characterName))
    //           {
    //			throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), characterName);
    //           }

    //		Character character = this.party.FirstOrDefault(x => x.Name == characterName);
    //		Item item = character.Bag.GetItem(itemName);
    //		character.UseItem(item);
    //		return String.Format(String.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name));

    //	}

    //       public string GetStats()
    //       {
    //           StringBuilder sb = new StringBuilder();
    //           foreach (var character in this.party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
    //           {
    //               string status = character.IsAlive ? "Alive" : "Dead";
    //               sb.AppendLine(String.Format(SuccessMessages.CharacterStats,
    //                  character.Name, character.Health,
    //                  character.BaseHealth, character.Armor,
    //                  character.BaseArmor, status));
    //           }
    //           return sb.ToString().TrimEnd();
    //       }

    //       public string Attack(string[] args)
    //       {
    //           string attackerName = args[0];
    //           string receiverName = args[1];

    //           if (!this.party.Any(x => x.Name == attackerName))
    //           {
    //               throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), attackerName);

    //           }
    //           else if (!this.party.Any(x => x.Name == receiverName))
    //           {
    //               throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), receiverName);
    //           }

    //           Warrior attacker = (Warrior)this.party.FirstOrDefault(x => x.Name == attackerName);
    //           Character receiver = this.party.FirstOrDefault(x => x.Name == receiverName);

    //           if (!attacker.IsAlive)
    //           {
    //               throw new ArgumentException($"{attacker.Name} cannot attack!");
    //           }

    //           attacker.Attack(receiver);

    //           StringBuilder sb = new StringBuilder();

    //           sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has " +
    //               $"{receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
    //           if (!receiver.IsAlive)
    //           {
    //               sb.Append($"{receiver.Name} is dead!");
    //           }
    //           return sb.ToString().TrimEnd();
    //       }


    //       public string Heal(string[] args)
    //       {
    //           string healerName = args[0];
    //           string healingReceiverName = args[1];

    //           if (!this.party.Any(x => x.Name == healerName))
    //           {
    //               throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), healerName);
    //           }
    //           else if (!this.party.Any(x => x.Name == healingReceiverName))
    //           {
    //               throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), healingReceiverName);
    //           }
    //           if (this.party.FirstOrDefault(x=>x.Name == healerName).GetType().Name != "Priest")
    //           {
    //               throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));
    //           }
    //           Priest healer = (Priest)this.party.FirstOrDefault(x => x.Name == healerName);
    //           Character receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

    //           StringBuilder sb = new StringBuilder();
    //           healer.Heal(receiver);
    //           sb.AppendLine(String.Format(SuccessMessages.HealCharacter,
    //             healer.Name, receiver.Name, healer.AbilityPoints,
    //             receiver.Name, receiver.Health));
    //           return sb.ToString().TrimEnd();
    //       }

    //}
    public class WarController
    {
        private List<Character> characterRepo;
        private List<Item> itemRepo;

        public WarController()
        {
            characterRepo = new List<Character>();
            itemRepo = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string characterName = args[1];

            Character hero = null;

            if (characterType == "Priest")
            {
                hero = new Priest(characterName);
            }
            else if (characterType == "Warrior")
            {
                hero = new Warrior(characterName);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCharacterType, characterType);
            }

            this.characterRepo.Add(hero);
            return String.Format(SuccessMessages.JoinParty, characterName);
        }

        public string AddItemToPool(string[] args)
        {
            string itemType = args[0];

            Item item = null;

            if (itemType == "Priest")
            {
                item = new FirePotion();
            }
            if (itemType == "Warrior")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidItem, itemType);
            }
            this.itemRepo.Add(item);
            return String.Format(SuccessMessages.JoinParty, itemType);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (!this.characterRepo.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (!this.itemRepo.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item pichUpItem = this.itemRepo.Last();
            Character character = this.characterRepo.FirstOrDefault(x => x.Name == characterName);
            character.Bag.AddItem(pichUpItem);
            this.itemRepo.Remove(pichUpItem);

            return String.Format(SuccessMessages.PickUpItem, characterName, pichUpItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = this.characterRepo.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return String.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            var sortedCharacters =
                this.characterRepo.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);

            foreach (var character in sortedCharacters)
            {
                string status = character.IsAlive == true ? "Alive" : "Dead";
                sb.AppendLine(String.Format
                (SuccessMessages.CharacterStats,
                character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, status));
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string recieverName = args[1];

            if (!this.characterRepo.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (!this.characterRepo.Any(x => x.Name == recieverName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, recieverName));
            }

            Warrior attacker = (Warrior)this.characterRepo.FirstOrDefault(x => x.Name == attackerName);
            Character reciever = this.characterRepo.FirstOrDefault(x => x.Name == recieverName);

            if (!attacker.IsAlive)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            attacker.Attack(reciever);

            sb.AppendLine(String.Format
               (SuccessMessages.AttackCharacter, attackerName, recieverName, attacker.AbilityPoints,
               recieverName, reciever.Health, reciever.BaseHealth, reciever.Armor, reciever.BaseArmor));

            if (!reciever.IsAlive)
            {
                sb.AppendLine(String.Format(SuccessMessages.AttackKillsCharacter, reciever.Name));
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string healerName = args[0];
            string healingReceiverName = args[1];

            if (!this.characterRepo.Any(x => x.Name == healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), healerName);
            }
            if (!this.characterRepo.Any(x => x.Name == healingReceiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), healingReceiverName);
            }

            if (this.characterRepo.FirstOrDefault(x => x.Name == healerName).GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Priest healer = (Priest)this.characterRepo.FirstOrDefault(x => x.Name == healerName);
            Character reciever = this.characterRepo.FirstOrDefault(x => x.Name == healingReceiverName);

            healer.Heal(reciever);

            sb.AppendLine(String.Format
             (SuccessMessages.HealCharacter, healer.Name, reciever.Name, healer.AbilityPoints, reciever.Name, reciever.Health));

            return sb.ToString().TrimEnd();
        }
    }
}

