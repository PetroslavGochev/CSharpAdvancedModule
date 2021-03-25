using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Players.Models;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields.Models
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            if (attackPlayer.GetType().Name == "Beginner")
            {
                IncreaseHealth(attackPlayer);
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                IncreaseHealth(enemyPlayer);
            }
            HealthBonus(attackPlayer);
            HealthBonus(enemyPlayer);
            Fighting(attackPlayer, enemyPlayer);
        }

        private void Fighting(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                int attackPlayerDamage = PlayerAttackPower(attackPlayer);
                int enemyPlayerDamage = PlayerAttackPower(enemyPlayer);
                enemyPlayer.TakeDamage(attackPlayerDamage);
                if (enemyPlayer.IsDead)
                {
                    continue;
                }
                attackPlayer.TakeDamage(enemyPlayerDamage);
            }
        }

        private int PlayerAttackPower(IPlayer player)
        {
            return player.CardRepository.Cards.Sum(c => c.DamagePoints);
        }
        private void HealthBonus(IPlayer player)
        {
            int sum = player.CardRepository.Cards.Sum(c => c.HealthPoints);
            player.Health += sum;
        }
        private void IncreaseHealth(IPlayer player)
        {
            player.Health += 40;
            foreach (var pc in player.CardRepository.Cards)
            {
                pc.DamagePoints += 30;
            }
        }


    }
}
