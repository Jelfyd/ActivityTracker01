namespace ActivityTracker.Tests;
using ActivityTracker.Core;
using NUnit.Framework;
public class UnitTest1
{
    [Test]
    public void Constructor_ShouldThrow_WhenDailyGoalIsNegative()
    {
        Assert.Throws<ArgumentException>(() => new ActivityTracker(-5));
    }

    [Test]
    public void Constructor_ShouldSetDailyGoal()
    {
        var tracker = new ActivityTracker(5000);
        Assert.That(tracker.DailyGoal, Is.EqualTo(5000));
    }
}
