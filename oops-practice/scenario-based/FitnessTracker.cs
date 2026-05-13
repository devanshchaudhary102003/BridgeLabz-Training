using System;
interface ITrackable
{
    int CalculateCalories();
    void DisplayWorkout();
}

abstract class WorkOut : ITrackable
{
    private string WorkoutName;
    private int Duration;   //duration in minute

    public string workOutName
    {
        get
        {
           return WorkoutName; 
        }
        set
        {
           WorkoutName = value; 
        }
    }

    public int duration
    {
        get
        {
           return Duration; 
        }
        set
        {
           Duration = value; 
        }
    }

    public abstract int CalculateCalories();

    public virtual void DisplayWorkout()
    {
        Console.WriteLine("---------- Workout -------------");
        Console.WriteLine("Workout Name: "+workOutName);
        Console.WriteLine("Workout Duration: "+duration);
        Console.WriteLine("Calculate Calories: "+CalculateCalories());
    }
}

class CardioWorkout : WorkOut
{
    public override int CalculateCalories()
    {
        return duration * 8;
    }

}

class StrengthWorkout : WorkOut
{
    public override int CalculateCalories()
    {
        return duration * 12;
    }
}

class UserProfile
{
    private string UserName;
    private int UserId;
    private int Age;

    public string userName
    {
        get
        {
            return UserName;
        }
        set
        {
            UserName = value;
        }
    }

    public int userId
    {
        get
        {
            return UserId;
        }
        set
        {
            UserId = value;
        }
    }

    public int age
    {
        get
        {
            return Age ;
        }
        set
        {
            Age = value;
        }
    }

    public void DisplayDetails()
    {
        Console.WriteLine("------------------- User Details -------------------");
        Console.WriteLine("User Name: "+UserName);
        Console.WriteLine("User Id: "+UserId);
        Console.WriteLine("User Age: "+Age);
    }
}

class FitnessTracker
{
    static void Main(string[] args)
    {
        UserProfile user = new UserProfile();
        user.userName = "Devansh Singh";
        user.userId = 123;
        user.age = 23;

        user.DisplayDetails();

        WorkOut[] workouts = new WorkOut[2];
        
        workouts[0] = new CardioWorkout();
        workouts[0].workOutName = "Chest";
        workouts[0].duration = 30;

        workouts[1] = new StrengthWorkout();
        workouts[1].workOutName = "Running";
        workouts[1].duration = 20;

        for(int i = 0; i < workouts.Length; i++)
        {
            workouts[i].DisplayWorkout();
            Console.WriteLine();
        }
    }
}