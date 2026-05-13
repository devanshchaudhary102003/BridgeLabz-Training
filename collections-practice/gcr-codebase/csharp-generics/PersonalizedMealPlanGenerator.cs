using System;
using System.Collections.Generic;

interface IMealPlan
{
    void PrepareMeal();
}

class VegetarianMeal : IMealPlan
{
    public void PrepareMeal()
    {
        Console.WriteLine("Vegetarian Meal");
    } 
}

class VeganMeal : IMealPlan
{
    public void PrepareMeal()
    {
        Console.WriteLine("Vegan Meal");
    } 
}

class KetoMeal : IMealPlan
{
    public void PrepareMeal()
    {
        Console.WriteLine("Keto Meal");
    } 
}

class HighProteinMeal : IMealPlan
{
    public void PrepareMeal()
    {
        Console.WriteLine("High Meal Protein");
    } 
}
 
class Meal<T> where T : IMealPlan
{
    public T MealPlan;

    public Meal(T mealPlan)
    {
        MealPlan = mealPlan;
    }
}

class MealGenerator
{
     public static void GenerateMeal<T>(Meal<T> meal) where T : IMealPlan
    {
        Console.WriteLine("\nGenerate Meal: ");
        meal.MealPlan.PrepareMeal();
    }
}

class PersonalizedMealPlanGenerator
{
    static void Main(string[] args)
    {
        Meal<VegetarianMeal> vegMeal = new Meal<VegetarianMeal>(new VegetarianMeal());
        Meal<VeganMeal> veganMeal = new Meal<VeganMeal>(new VeganMeal());
        Meal<KetoMeal> ketoMeal = new Meal<KetoMeal>(new KetoMeal());
        Meal<HighProteinMeal> highProteinMeal = new Meal<HighProteinMeal>(new HighProteinMeal());

        MealGenerator.GenerateMeal(vegMeal);
        MealGenerator.GenerateMeal(veganMeal);
        MealGenerator.GenerateMeal(ketoMeal);
        MealGenerator.GenerateMeal(highProteinMeal);

    }
}