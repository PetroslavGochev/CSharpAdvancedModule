using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;

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
            while(!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                
            }
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
