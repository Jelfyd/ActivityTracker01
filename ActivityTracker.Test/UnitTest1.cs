namespace ActivittyTracker.Test;
using Xunit;
using ActivityTracker.Core;


public class ActivityTrackerTests
{
    [Fact]
    public void Constructor_ShouldThrow_WhenDailyGoalIsNegative()
    {
        Assert.Throws<ArgumentException>(() => new ActivityTracker(-5));
    }

    [Fact]
    public void Constructor_ShouldSetDailyGoal()
    {
        var tracker = new ActivityTracker(5000);
        Assert.Equal(5000, tracker.DailyGoal);
    }

    [Fact]
    public void AddSteps_ShouldIncreaseSteps_WhenPositive()
    {
        var t = new ActivityTracker(5000);
        t.AddSteps(1000);
        Assert.Equal(1000, t.StepsToday);
    }

    [Fact]
    public void AddSteps_ShouldIgnoreNegativeValues()
    {
        var t = new ActivityTracker(5000);
        t.AddSteps(-300);
        Assert.Equal(0, t.StepsToday);
    }

    [Fact]
    public void ResetDay_ShouldSetStepsToZero()
    {
        var t = new ActivityTracker(5000);
        t.AddSteps(2000);
        t.ResetDay();
        Assert.Equal(0, t.StepsToday);
    }

    [Fact]
    public void GetProgress_ShouldReturn100_WhenGoalIsZero()
    {
        var t = new ActivityTracker(0);
        Assert.Equal(100, t.GetProgress());
    }

    [Theory]
    [InlineData(4000, 1000, 25)]
    [InlineData(4000, 555, 13)]
    public void GetProgress_ShouldReturnCorrectPercentage(int dailyGoal, int steps, int expected)
    {
        var t = new ActivityTracker(dailyGoal);
        t.AddSteps(steps);
        Assert.Equal(expected, t.GetProgress());
    }

    [Fact]
    public void IsGoalReached_ShouldBeTrue_WhenStepsEnough()
    {
        var t = new ActivityTracker(3000);
        t.AddSteps(3000);
        Assert.True(t.IsGoalReached);
    }

    [Fact]
    public void IsGoalReached_ShouldBeFalse_WhenStepsNotEnough()
    {
        var t = new ActivityTracker(3000);
        t.AddSteps(1000);
        Assert.False(t.IsGoalReached);
    }
}


