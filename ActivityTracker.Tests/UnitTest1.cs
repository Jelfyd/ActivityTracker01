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

    [Test]
    public void AddSteps_ShouldIncreaseSteps_WhenPositive()
    {
        var t = new ActivityTracker(5000);
        t.AddSteps(1000);
        Assert.That(t.StepsToday, Is.EqualTo(1000));
    }

    [Test]
    public void AddSteps_ShouldIgnoreNegativeValues()
    {
        var t = new ActivityTracker(5000);
        t.AddSteps(-300);
        Assert.That(t.StepsToday, Is.EqualTo(0));
    }
    [Test]
    public void ResetDay_ShouldSetStepsToZero()
    {
        var t = new ActivityTracker(5000);
        t.AddSteps(2000);
        t.ResetDay();
        Assert.That(t.StepsToday, Is.EqualTo(0));
    }
    [Test]
    public void GetProgress_ShouldReturn100_WhenGoalIsZero()
    {
        var t = new ActivityTracker(0);
        Assert.That(t.GetProgress(), Is.EqualTo(100));
    }

    [Test]
    public void GetProgress_ShouldReturnCorrectPercentage()
    {
        var t = new ActivityTracker(4000);
        t.AddSteps(1000);
        Assert.That(t.GetProgress, Is.EqualTo(25));
    }
    [Test]
    public void IsGoalReached_ShouldBeTrue_WhenStepsEnough()
    {
        var t = new ActivityTracker(3000);
        t.AddSteps(3000);
        Assert.That(t.IsGoalReached, Is.True);
    }

    [Test]
    public void IsGoalReached_ShouldBeFalse_WhenStepsNotEnough()
    {
        var t = new ActivityTracker(3000);
        t.AddSteps(1000);
        Assert.That(t.IsGoalReached, Is.False);
    }


}
