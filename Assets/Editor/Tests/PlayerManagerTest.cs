using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class PlayerManagerTests
{
    private GameObject player;
    private PlayerManager pm;

    [TestFixtureSetUp]
    public void init()
    {
        GameObject player = new GameObject();
        player.AddComponent<PlayerManager>();
        pm = player.GetComponent<PlayerManager>();
    }

    [TestFixtureTearDown]
    public void finish()
    {
        GameObject.DestroyImmediate(player);
    }

    [Test]
    public void BreathIsNeverNegative()
    {
        float preBreath = pm.getBreath();

        pm.DepleteBreath(2.0f * preBreath);

        Assert.That(pm.getBreath() >= 0.0f);

    }
    [Test]
    public void BreathNeverOverMaximum()
    {

        float preBreath = pm.getBreath();
        pm.PufferUseSelf();

        Assert.That(pm.getBreath() <= pm.MaxBreath);

    }

    [Test]
    public void CannotSetBreathPastBounds()
    {

        pm.setBreath(-1000f);
        Assert.That(pm.getBreath() >= 0.0f);

        pm.setBreath(pm.MaxBreath + 10000f);
        Assert.That(pm.getBreath() <= pm.MaxBreath);

        
    }
    
    [Test]
    public void AddScoreIncreasesScore()
    {
        int s = pm.getscore();
        pm.addscore(1);
        Assert.That(s < pm.getscore());
    }
}