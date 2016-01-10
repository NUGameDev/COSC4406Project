using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class PlayerManagerTests
{
    [Test]
    public void BreathIsNeverNegative()
    {
        //setup
        GameObject player = new GameObject();
        player.AddComponent<PlayerManager>();
        PlayerManager pm = player.GetComponent<PlayerManager>();
        float preBreath = pm.getBreath();

        pm.DepleteBreath(2.0f * preBreath);

        Assert.That(pm.getBreath() >= 0.0f);
    }
    [Test]
    public void BreathNeverOverMaximum()
    {
        GameObject player = new GameObject();
        player.AddComponent<PlayerManager>();
        PlayerManager pm = player.GetComponent<PlayerManager>();

        float preBreath = pm.getBreath();
        pm.PufferUseSelf();

        Assert.That(pm.getBreath() <= pm.MaxBreath);
    }

    [Test]
    public void CannotSetBreathPastBounds()
    {
        GameObject player = new GameObject();
        player.AddComponent<PlayerManager>();
        PlayerManager pm = player.GetComponent<PlayerManager>();

        pm.setBreath(-1000f);
        Assert.That(pm.getBreath() >= 0.0f);

        pm.setBreath(pm.MaxBreath + 10000f);
        Assert.That(pm.getBreath() <= pm.MaxBreath);
        
    }
}