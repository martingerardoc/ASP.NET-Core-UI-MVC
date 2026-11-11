
namespace BlazingPizza.Data;

public class PizzaService
{
    public Task<Pizza[]> GetPizzasAsync()
    {
        Pizza[] pizzas =
        [
            new Pizza
            {
                PizzaId = 1,
                Name = "Muzzarella",
                Description = "Mozzarella cheese and tomato sauce",
                Price = 8500,
                Vegetarian = true,
                Vegan = false
            },
            new Pizza
            {
                PizzaId = 2,
                Name = "Pepperoni",
                Description = "Pepperoni and mozzarella cheese",
                Price = 10500,
                Vegetarian = false,
                Vegan = false
            },
            new Pizza
            {
                PizzaId = 3,
                Name = "Vegetarian",
                Description = "Tomatoes, peppers and mushrooms",
                Price = 9500,
                Vegetarian = true,
                Vegan = true
            }
        ];

        return Task.FromResult(pizzas);
    }
}
