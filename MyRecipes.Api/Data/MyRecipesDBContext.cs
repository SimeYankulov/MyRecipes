using Microsoft.EntityFrameworkCore;
using MyRecipes.Api.Entities;

namespace MyRecipes.Api.Data
{
    public class MyRecipesDBContext:DbContext
    {
        public MyRecipesDBContext(DbContextOptions<MyRecipesDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Category 1 Quick&Easy
            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 1,
                Title = "Coconut & squash dhansak",
                Description = "This quick and easy vegetarian curry is perfect for a healthy weeknight dinner " +
                                "– with butternut squash, coconut milk, lentils and spinach",
                ImageUrl = "/Images/Quick&Easy/coconut-squash.png",
                CategoryId = 1

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 2,
                Title = "Crispy shredded chicken",
                Description = "Try this takeaway favourite served with rice, or simply on its own as part of a buffet-style meal." +
                                " It can work as a main course or starter to share",
                ImageUrl = "/Images/Quick&Easy/Crispy-shredded-chicken.png",
                CategoryId = 1

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 3,
                Title = "Air fryer bacon",
                Description = "Cook bacon in an air fryer to achieve a crispy texture with less fat." +
                                " The perfect bacon sandwich starts here",
                ImageUrl = "/Images/Quick&Easy/Air-Fryer-Bacon.png",
                CategoryId = 1

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 4,
                Title = "Easy huevos rancheros",
                Description = "An easy Mexican breakfast that'll keep you going all morning, " +
                               "this huevos rancheros recipe (aka 'ranch eggs') is packed with vibrant colours and flavours.",
                ImageUrl = "/Images/Quick&Easy/easy-huevos-rancheros.png",
                CategoryId = 1

            });

            //Category 2 Desserts
            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 5,
                Title = "Self-saucing sticky toffee chocolate pudding",
                Description = "Combine sticky toffee pudding sponge with a generous helping of chocolate chunks and" +
                                " chocolate sauce for the ultimate comforting dessert",
                ImageUrl = "/Images/Desserts/chocolate_toffee_pudding.png",
                CategoryId = 2

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 6,
                Title = "Rocky road cheesecake pudding",
                Description = "We've blended two tempting sweet treats – rocky road and cheesecake" +
                                " – to create this irresistible make-ahead dessert.",
                ImageUrl = "/Images/Desserts/cheesecake-pudding.png",
                CategoryId = 2

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 7,
                Title = "The best apple crumble",
                Description = "You can't beat a traditional apple filling topped with crispy, " +
                             "buttery crumble - classic comfort food at its best",
                ImageUrl = "/Images/Desserts/apple-crumble.png",
                CategoryId = 2

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 8,
                Title = "Luscious lemon baked cheesecake",
                Description = "A simple but very impressive pud, light enough to have a slice to finish a big meal",
                ImageUrl = "/Images/Desserts/lemon_cheesecake.png",
                CategoryId = 2

            });

            //Category 3 Pasta

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 9,
                Title = "Vegetable pasta bake",
                Description = "Get the maximum flavour out of all the veg in our pasta bake by pan-frying it first." +
                                    " You can also freeze this for up to three months to enjoy on busier days",
                ImageUrl = "/Images/Pasta/vegetable-pasta.png",
                CategoryId = 3

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 10,
                Title = "Pumpkin pasta alla vodka",
                Description = "Celebrate pumpkins in autumn with this easy pasta dish that makes the most of this gourd." +
                "                Vodka and chilli provide a lovely deep flavour",
                ImageUrl = "/Images/Pasta/Pumpkin-pasta.png",
                CategoryId = 3

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 11,
                Title = "One-pot tomato orzo",
                Description = "Have a glut of tomatoes? Put them to good use in this one-pan orzo dish, perfect for a family midweek dinner. " +
                                "Finish with fresh parsley and plenty of parmesan",
                ImageUrl = "/Images/Pasta/One-pot-tomato-orzo.png",
                CategoryId = 3

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 12,
                Title = "Cacio e pepe",
                Description = "Whip up a simple cacio e pepe for a speedy lunch. With four simple ingredients – spaghetti, pepper, " +
                               "parmesan and butter – this is a storecupboard favourite",
                ImageUrl = "/Images/Pasta/One-pot-tomato-orzo.png",
                CategoryId = 3

            });


            //Users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "Sime1"

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Username = "Sime2"

            });

            //Bookmark List of users
            modelBuilder.Entity<Bookmark>().HasData(new Bookmark
            {
                Id = 1,
                UserId = 1

            });
            modelBuilder.Entity<Bookmark>().HasData(new Bookmark
            {
                Id = 2,
                UserId = 2

            });
            //Recipe Categories
            modelBuilder.Entity<RecipeCategory>().HasData(new RecipeCategory
            {
                Id = 1,
                Name = "Quick&Easy"
            });
            modelBuilder.Entity<RecipeCategory>().HasData(new RecipeCategory
            {
                Id = 2,
                Name = "Dessert"
            });
            modelBuilder.Entity<RecipeCategory>().HasData(new RecipeCategory
            {
                Id = 3,
                Name = "Pasta"
            });
        }

        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<BookmarkItem> BookmarkItems { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<User> Users { get; set; } 
    }
}
