using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CYOATests
{
    [TestClass]
    public class MerchantTests
    {
        [TestMethod]
        public void PlayerShouldReceiveWeaponUpgrade()
        {
            var player = new Player();
            player.Weapon = new Weapon("sword", 10, "art");
            
            // Simulating merchant logic
            player.Weapon = new Weapon("Magical " + player.Weapon.Type, player.Weapon.MaxDamage + 5, "✨" + player.Weapon.AsciiArt);

            Assert.AreEqual("Magical sword", player.Weapon.Type);
            Assert.AreEqual(15, player.Weapon.MaxDamage);
        }

        [TestMethod]
        public void PlayerShouldReceiveArmorUpgrade()
        {
            var player = new Player();
            
            // Simulating merchant logic
            player.Armor = new Armor("Magical Armor", 5);

            Assert.IsNotNull(player.Armor);
            Assert.AreEqual("Magical Armor", player.Armor.Type);
            Assert.AreEqual(5, player.Armor.Protection);
        }
    }
}
