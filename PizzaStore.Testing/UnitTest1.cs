using System;
using System.Collections.Generic;
using System.Linq;
using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.PizzaModel;
using PizzaStore.Domain.Models.ToppingModel;
using Xunit;

namespace PizzaStore.Testing
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddingPizza()
        {
          // Name name, Size size, Crust crust, List<Topping> toppings
          var order = new Order();
          var pizza = new Pizza(new Name("MyPizza"), new Size("M"), new Crust("flatbread"), new List<Topping>{new Cheese(), new Jalapeno()});
          order.Pizzas.Add(pizza);

          var expectedPizzaName = "MyPizza";
          var expectedPizzaSize = "M";

          Assert.NotNull(order.Pizzas);
          Assert.Equal(expectedPizzaName, order.Pizzas.ElementAt(0).Name.PizzaName);
          Assert.Equal(expectedPizzaSize, order.Pizzas.ElementAt(0).Size.PizzaSize);
          Assert.True(order.Pizzas.Count == 1);
        }
        [Fact]
        public void TestCreatePizza()
        {
          // Cheese Pizza Price = 8.4
          // 250/8.4 = 29.76
          // 1) Expected to pass: adding 29 cheese pizzas
          // 2) Expected to pass: adding 30th cheese pizza, system will not allow this to occur
          var order = new Order();
          for(int i = 1; i < 30; i++){  // iterations set to less than 30 because 29 is the max amount of cheese pizzas you can add
            // Assert.True()
            Assert.True(order.CreatePizza(new CheesePizzaFactory())); // 1)
          }
          Assert.False(order.CreatePizza(new CheesePizzaFactory())); // 2)

          Assert.True(order.IsPizzasInRange());


          // Assert.NotNull(order.Pizzas);
          // Assert.Equal(pizza.Name.PizzaName, "MyPizza");
          // Assert.Equal(pizza.Size.PizzaSize, "M");
          // Assert.Equal(order.Pizzas.Count, 1);
        }
    }
}
