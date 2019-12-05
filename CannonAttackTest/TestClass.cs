using CannotAttack;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonAttackTest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void CannonIDValid()
        {
            Cannon cannon = new Cannon();
            Assert.IsNotNull(cannon.ID);
        }

        [Test]
        public void TestCannonMultipleInstances()
        {
            Cannon cannon = Cannon.GetInstance();
            Cannon cannon2 = Cannon.GetInstance();
            Assert.IsTrue(cannon == cannon2);
        }

        [Test]
        public void TestCannonShootIncorrectAngle()
        {
            Cannon cannon = Cannon.GetInstance();
            var shot = cannon.Shoot(95, 100);
            Assert.IsFalse(shot.Item1);
        }

        [Test]
        public void TestCannonShootVelocityGreaterThanSpeedOfLight()
        {
            Cannon cannon = Cannon.GetInstance();
            var shot = cannon.Shoot(45, 30001);
            Assert.IsFalse(shot.Item1);
        }

        [Test]
        public void TestCannonShootHit()
        {
            Cannon cannon = Cannon.GetInstance();
            cannon.SetTarget(12621);
            var shot = cannon.Shoot(45, 350);
            Assert.IsTrue(shot.Item2 == "Hit");
        }

        [Test]
        public void TestCannonShootMiss()
        {
            Cannon cannon = Cannon.GetInstance();
            cannon.SetTarget(4000);
            var shot = cannon.Shoot(45, 350);
            Assert.IsTrue(shot.Item2 == "Missed cannonball landed at 12621 meters");
        }
    }
}
