namespace ActivityTracker.Core;

public class ActivityTracker
{
    public int DailyGoal { get; }
    public int StepsToday { get; private set; }
    public bool IsGoalReached => StepsToday >= DailyGoal;

    public ActivityTracker(int dailyGoal)
    {
        if (dailyGoal < 0)
            throw new ArgumentException("Daily goal cannot be negative");

        DailyGoal = dailyGoal;
        StepsToday = 0;
    }

    public void AddSteps(int steps)
    {
        if (steps > 0)
            StepsToday += steps;
    }
    public void ResetDay()
    {
        StepsToday = 0;
    }
    public int GetProgress()
    {
        if (DailyGoal == 0) return 100;
        return (int)((double)StepsToday / DailyGoal * 100);
    }
    
}
