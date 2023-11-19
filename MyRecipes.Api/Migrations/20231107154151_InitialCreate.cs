using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyRecipes.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeBookItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeBookId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeBookItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RecipeBooks",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Quick&Easy" },
                    { 2, "Dessert" },
                    { 3, "Pasta" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, 1, "This quick and easy vegetarian curry is perfect for a healthy weeknight dinner – with butternut squash, coconut milk, lentils and spinach", "/Images/Quick&Easy/coconut-squash.png", "Coconut & squash dhansak" },
                    { 2, 1, "Try this takeaway favourite served with rice, or simply on its own as part of a buffet-style meal. It can work as a main course or starter to share", "/Images/Quick&Easy/Crispy-shredded-chicken.png", "Crispy shredded chicken" },
                    { 3, 1, "Cook bacon in an air fryer to achieve a crispy texture with less fat. The perfect bacon sandwich starts here", "/Images/Quick&Easy/Air-Fryer-Bacon.png", "Air fryer bacon" },
                    { 4, 1, "An easy Mexican breakfast that'll keep you going all morning, this huevos rancheros recipe (aka 'ranch eggs') is packed with vibrant colours and flavours.", "/Images/Quick&Easy/easy-huevos-rancheros.png", "Easy huevos rancheros" },
                    { 5, 2, "Combine sticky toffee pudding sponge with a generous helping of chocolate chunks and chocolate sauce for the ultimate comforting dessert", "/Images/Desserts/chocolate_toffee_pudding.png", "Self-saucing sticky toffee chocolate pudding" },
                    { 6, 2, "We've blended two tempting sweet treats – rocky road and cheesecake – to create this irresistible make-ahead dessert.", "/Images/Desserts/cheesecake-pudding.png", "Rocky road cheesecake pudding" },
                    { 7, 2, "You can't beat a traditional apple filling topped with crispy, buttery crumble - classic comfort food at its best", "/Images/Desserts/apple-crumble.png", "The best apple crumble" },
                    { 8, 2, "A simple but very impressive pud, light enough to have a slice to finish a big meal", "/Images/Desserts/lemon_cheesecake.png", "Luscious lemon baked cheesecake" },
                    { 9, 3, "Get the maximum flavour out of all the veg in our pasta bake by pan-frying it first. You can also freeze this for up to three months to enjoy on busier days", "/Images/Pasta/vegetable-pasta.png", "Vegetable pasta bake" },
                    { 10, 3, "Celebrate pumpkins in autumn with this easy pasta dish that makes the most of this gourd.                Vodka and chilli provide a lovely deep flavour", "/Images/Pasta/Pumpkin-pasta.png", "Pumpkin pasta alla vodka" },
                    { 11, 3, "Have a glut of tomatoes? Put them to good use in this one-pan orzo dish, perfect for a family midweek dinner. Finish with fresh parsley and plenty of parmesan", "/Images/Pasta/One-pot-tomato-orzo.png", "One-pot tomato orzo" },
                    { 12, 3, "Whip up a simple cacio e pepe for a speedy lunch. With four simple ingredients – spaghetti, pepper, parmesan and butter – this is a storecupboard favourite", "/Images/Pasta/One-pot-tomato-orzo.png", "Cacio e pepe" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username" },
                values: new object[,]
                {
                    { 1, "Sime1" },
                    { 2, "Sime2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeBookItems");

            migrationBuilder.DropTable(
                name: "RecipeBooks");

            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
