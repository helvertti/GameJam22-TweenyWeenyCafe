using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{

    private List<Ingredient> ingredients;
    private List<Beverage> recipes;

    private List<Beverage> knownRecipes;

    private Beverage failedBev;

    private int totalDoneBevsCount;
    private int satisfiedBevsCount;
    private int servedPoisonCount;
    private int servedLoveCount;

    private static PlayerController instance = null;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerController();
            }
            return instance;
        }
    }
    private PlayerController() {
        totalDoneBevsCount = 0;
        satisfiedBevsCount = 0;
        servedPoisonCount = 0;
        servedLoveCount = 0;

        ingredients = new List<Ingredient>();
        initIngredients();

        recipes = new List<Beverage>();
        initRecipes();

        knownRecipes = new List<Beverage>();
        initKnownRecipes();

        failedBev = new Beverage("Goo", new List<Ingredient>());
    }

    private void initIngredients() {
        ingredients.Add(new Ingredient("coffee", Ingredient.property.BITTER));
        // ingredients.Add(new Ingredient("sugar", Ingredient.property.SWEET));
        ingredients.Add(new Ingredient("milk", Ingredient.property.SWEET));
        ingredients.Add(new Ingredient("love fruit", Ingredient.property.SOUR));
        ingredients.Add(new Ingredient("purple root", Ingredient.property.POISON));
        // ingredients.Add(new Ingredient("", Ingredient.property.));
    }

    private void initRecipes() {
        recipes.Add(new Beverage("Latte", new List<Ingredient>() {
            ingr("coffee"), ingr("milk"), ingr("milk")
        }));
        recipes.Add(new Beverage("Cappuccino", new List<Ingredient>() {
            ingr("coffee"), ingr("milk")
        }));
        recipes.Add(new Beverage("Coffee with Milk", new List<Ingredient>() {
            ingr("coffee"), ingr("coffee"), ingr("milk")
        }));
        recipes.Add(new Beverage("Strong Coffee with Milk", new List<Ingredient>() {
            ingr("coffee"), ingr("coffee"), ingr("coffee"), ingr("milk")
        }));
        recipes.Add(new Beverage("Milk with Coffee", new List<Ingredient>() {
            ingr("milk"), ingr("milk"), ingr("milk"), ingr("coffee")
        }));
        recipes.Add(new Beverage("Milk", new List<Ingredient>() {
            ingr("milk")
        }));
        recipes.Add(new Beverage("Extra Milk", new List<Ingredient>() {
            ingr("milk"), ingr("milk")
        }));
        recipes.Add(new Beverage("Milk with Extra Milk", new List<Ingredient>() {
            ingr("milk"), ingr("milk"), ingr("milk")
        }));
        recipes.Add(new Beverage("Milk Milk Milk Milk", new List<Ingredient>() {
            ingr("milk"), ingr("milk"), ingr("milk"), ingr("milk")
        }));
        recipes.Add(new Beverage("Espresso", new List<Ingredient>() {
            ingr("coffee")
        }));
        recipes.Add(new Beverage("Double Espresso", new List<Ingredient>() {
            ingr("coffee"), ingr("coffee")
        }));
        recipes.Add(new Beverage("Triple Espresso", new List<Ingredient>() {
            ingr("coffee"), ingr("coffee"), ingr("coffee")
        }));
        recipes.Add(new Beverage("Questionable Espresso", new List<Ingredient>() {
            ingr("coffee"), ingr("coffee"), ingr("coffee"), ingr("coffee")
        }));
        recipes.Add(new Beverage("Pure Poison", new List<Ingredient>() {
            ingr("purple root")
        }));
        recipes.Add(new Beverage("Super Poison", new List<Ingredient>() {
            ingr("purple root"), ingr("purple root")
        }));
        recipes.Add(new Beverage("Hyper Poison", new List<Ingredient>() {
            ingr("purple root"), ingr("purple root"), ingr("purple root")
        }));
        recipes.Add(new Beverage("Ultra Poison", new List<Ingredient>() {
            ingr("purple root"), ingr("purple root"), ingr("purple root"), ingr("purple root")
        }));
        recipes.Add(new Beverage("Vitamin Shot of Feelings", new List<Ingredient>() {
            ingr("love fruit")
        }));
        recipes.Add(new Beverage("Lemonade of Dating", new List<Ingredient>() {
            ingr("love fruit"), ingr("love fruit")
        }));
        recipes.Add(new Beverage("Love Potion", new List<Ingredient>() {
            ingr("love fruit"), ingr("love fruit"), ingr("love fruit")
        }));
        recipes.Add(new Beverage("Obsession Potion", new List<Ingredient>() {
            ingr("love fruit"), ingr("love fruit"), ingr("love fruit"), ingr("love fruit")
        }));
        recipes.Add(new Beverage("Milkshake of Feelings", new List<Ingredient>() {
            ingr("love fruit"), ingr("milk")
        }));
        recipes.Add(new Beverage("Milkshake of Dating", new List<Ingredient>() {
            ingr("love fruit"), ingr("love fruit"), ingr("milk")
        }));
        recipes.Add(new Beverage("Milkshake of Love", new List<Ingredient>() {
            ingr("love fruit"), ingr("love fruit"), ingr("love fruit"), ingr("milk")
        }));
        recipes.Add(new Beverage("Espresso of Feelings", new List<Ingredient>() {
            ingr("love fruit"), ingr("coffee")
        }));
        recipes.Add(new Beverage("Espresso of Dating", new List<Ingredient>() {
            ingr("love fruit"), ingr("coffee"), ingr("coffee")
        }));
        recipes.Add(new Beverage("Love Fruit Spice Latte", new List<Ingredient>() {
            ingr("love fruit"), ingr("milk"), ingr("coffee")
        }));
        recipes.Add(new Beverage("Magical Lemonade of Luck", new List<Ingredient>() {
            ingr("love fruit"), ingr("purple root")
        }));
        recipes.Add(new Beverage("Unhealthy Espresso", new List<Ingredient>() {
            ingr("coffee"), ingr("purple root")
        }));
        recipes.Add(new Beverage("Questionable Milkshake", new List<Ingredient>() {
            ingr("milk"), ingr("purple root")
        }));
        // recipes.Add(new Beverage("", new List<Ingredient>() {
        //     ingr(""), ingr("")
        // }));

        for (int i = 0; i < recipes.Count; i++) {
            recipes[i].getProperties().Sort((x, y) => string.Compare(x.getName(), y.getName()));
        }
    }

    private void initKnownRecipes() {
        knownRecipes.Add(bevr("Latte"));
        knownRecipes.Add(bevr("Milk"));
        knownRecipes.Add(bevr("Espresso"));
        knownRecipes.Add(bevr("Pure Poison"));
    }

    public Ingredient ingr(string name) {
        for (int i = 0; i < ingredients.Count; i++) {
            if (ingredients[i].getName() == name) {
                return ingredients[i];
            }
        }
        Debug.Log("No ingredients found with name " + name);
        return null;
    }

    public Beverage bevr(string name) {
        for (int i = 0; i < recipes.Count; i++) {
            if (recipes[i].getName() == name) {
                return recipes[i];
            }
        }
        Debug.Log("No recipe found with name " + name);
        return null;
    }

    // Tällä hetkellä hyväksyy vain tarkan vastaavuuden;
    // kaikki yhdistelmät, joista ei ole reseptiä, hylätään.
    public Beverage bevrByList(List<Ingredient> ingrs) {
        ingrs.Sort((x, y) => string.Compare(x.getName(), y.getName()));
        Debug.Log("Analyzing ingredients: " + string.Join(",", ingrs));
        for (int i = 0; i < recipes.Count; i++) {
            // Debug.Log(i + "  " + recipes.Count);
            // Debug.Log("Iterating at " + recipes[i].getName() + "(" + string.Join(", ", recipes[i].getProperties()) + ")");
            bool matching = true;
            if (recipes[i].getProperties().Count > ingrs.Count || recipes[i].getProperties().Count < ingrs.Count ) {
                // Debug.Log("Skipping " + recipes[i].getName());
                continue;
            }
            for (int j = 0; j < ingrs.Count; j++) {
                // Debug.Log("Comparing " + recipes[i].getName() + " and " + string.Join(", ", ingrs));
                // Debug.Log(j + "  " + ingrs.Count);
                // Debug.Log(ingrs[j].getName().Equals(recipes[i].getProperties()[j].getName()));
                if (!ingrs[j].getName().Equals(recipes[i].getProperties()[j].getName())) {
                    matching = false;
                    // Debug.Log("Matching is " + matching);
                    break;
                }
            }
            if (matching) {

                Debug.Log(string.Join("+", ingrs) + " matches " + recipes[i].getName());
                return recipes[i];
            }
        }
        return failedBev;
    }

    public List<Ingredient> getIngredients() {
        return ingredients;
    }

    public List<Beverage> getRecipes() {
        return recipes;
    }

    public List<Beverage> getKnownRecipes() {
        return knownRecipes;
    }

    public void addRecipeToKnown(string name) {
        Beverage b = bevr(name);
        if (recipes.Contains(b) && !knownRecipes.Contains(b)) {
            knownRecipes.Add(b);
        } else if (knownRecipes.Contains(b)) {
            Debug.Log(name + " is already in known recipes.");
        } else {
            Debug.Log(name + " is not a recognised recipe.");
        }
    }

    public void increaseTotalDoneBevsCount() {
        totalDoneBevsCount = totalDoneBevsCount + 1;
    }

    public int getTotalDoneBevsCount() {
        return totalDoneBevsCount;
    }

    public void increaseSatisfiedBevsCount() {
        satisfiedBevsCount = satisfiedBevsCount + 1;
    }
    public int getSatisfiedBevsCount() {
        return satisfiedBevsCount;
    }

    public void increaseServedPoisonCount() {
        servedPoisonCount = servedPoisonCount + 1;
    }

    public int getServedPoisonCount() {
        return servedPoisonCount;
    }

    public void increaseServedLoveCount() {
        servedLoveCount = servedLoveCount + 1;
    }

    public int getServedLoveCount() {
        return servedLoveCount;
    }

}
