using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsOnline.API.Migrations
{
    public partial class pupular_produto : Migration
    {
        protected override void Up(MigrationBuilder model)
        {
            model.Sql("Insert into Products(Name, Price, Description, Stock, ImagePath, CategoryId)" +
             "Values('Mussarela', 50.00, 'Mussarela. tomate e azeitonas', 50, 'https://img2.gratispng.com/20180206/lde/kisspng-chicago-style-pizza-buffet-pepperoni-garlic-bread-pepperoni-pizza-png-transparent-image-5a795d3884be79.7330394215179031605437.jpg', 1)");

            model.Sql("Insert into Products(Name, Price, Description, Stock, ImagePath, CategoryId)" +
                "Values('Calabresa', 35.00, 'Calabresa, cebola e azeitonas.', 60, 'https://img2.gratispng.com/20180206/lde/kisspng-chicago-style-pizza-buffet-pepperoni-garlic-bread-pepperoni-pizza-png-transparent-image-5a795d3884be79.7330394215179031605437.jpg', 1)");

            model.Sql("Insert into Products(Name, Price, Description, Stock, ImagePath, CategoryId)" +
              "Values('Chocolate', 60.00, 'Chocolate com morango', 50, 'https://img1.gratispng.com/20180805/wfc/kisspng-pizza-dulce-de-leche-dish-chocolate-spread-5b675015be3b10.9771218615334973657792.jpg', 2)");

            model.Sql("Insert into Products(Name, Price, Description, Stock, ImagePath, CategoryId)" +
             "Values('Coca-cola', 15.00, 'Garrafa 2L', 50, 'https://img1.gratispng.com/20180131/oxw/kisspng-coca-cola-soft-drink-diet-coke-coca-cola-png-photos-5a7234fb7229d9.7826255515174341074676.jpg', 3)");

            model.Sql("Insert into Products(Name, Price, Description, Stock, ImagePath, CategoryId)" +
            "Values('Coca-cola', 15.00, 'Lata 350ML', 50, 'https://img1.gratispng.com/20180323/sse/kisspng-coca-cola-fizzy-drinks-diet-coke-beverage-can-coca-cola-5ab4c79f1002f3.7078378315217970230656.jpg', 3)");
        }

        protected override void Down(MigrationBuilder model)
        {
            model.Sql("delete from Products");
        }
    }
}
