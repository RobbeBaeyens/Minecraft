using System;
using System.Linq;
using DALMinecraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting_Minecraft
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void ToevoegenServer()
        {
            Server server = new Server();

            server.name = "UnitTestServer 1";
            server.ipadress = "192.45.01.196";

            Assert.AreEqual("UnitTestServer 1", server.name);
            Assert.AreEqual("192.45.01.196", server.ipadress);
        }

        [TestMethod]
        public void ToevoegenSpeler()
        {
            Player speler = new Player();

            speler.name = "UnitTestSpeler 1";
            speler.uuid = "6229f327f20a49889ad3a1c3ed934719";
            speler.skin = "skin";
            speler.health = 15;
            speler.armor = 8;
            speler.posX = 20;
            speler.posY = 15;
            speler.posZ = 12;

            Assert.AreEqual("UnitTestSpeler 1", speler.name);
            Assert.AreEqual("6229f327f20a49889ad3a1c3ed934719", speler.uuid);
            Assert.AreEqual("skin", speler.skin);
            Assert.AreEqual(15, speler.health);
            Assert.AreEqual(8, speler.armor);
            Assert.AreEqual(20, speler.posX);
            Assert.AreEqual(15, speler.posY);
            Assert.AreEqual(12, speler.posZ);
        }

        [TestMethod]
        public void VeranderWereldEigenschappen()
        {
            World wereld = new World();

            wereld.name = "UnitTestWereldNaam 1";
            wereld.seed = "1000000000";
            wereld.structures = true;
            wereld.worldType = 2;
            wereld.bonusChest = true;
            wereld.cheats = true;
            wereld.difficulty = 1;

            Assert.AreEqual("UnitTestWereldNaam 1", wereld.name);
            Assert.AreEqual("1000000000", wereld.seed);
            Assert.AreEqual(true, wereld.structures);
            Assert.AreEqual(2, wereld.worldType);
            Assert.AreEqual(true, wereld.bonusChest);
            Assert.AreEqual(true, wereld.cheats);
            Assert.AreEqual(1, wereld.difficulty);
        }
    }
}
