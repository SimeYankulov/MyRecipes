﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyRecipes.Api.Data;

#nullable disable

namespace MyRecipes.Api.Migrations
{
    [DbContext(typeof(MyRecipesDBContext))]
    partial class MyRecipesDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyRecipes.Api.Entities.Bookmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bookmarks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("MyRecipes.Api.Entities.BookmarkItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookmarkId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BookmarkItems");
                });

            modelBuilder.Entity("MyRecipes.Api.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "This quick and easy vegetarian curry is perfect for a healthy weeknight dinner – with butternut squash, coconut milk, lentils and spinach",
                            ImageUrl = "/Images/Quick&Easy/coconut-squash.png",
                            Title = "Coconut & squash dhansak"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Try this takeaway favourite served with rice, or simply on its own as part of a buffet-style meal. It can work as a main course or starter to share",
                            ImageUrl = "/Images/Quick&Easy/Crispy-shredded-chicken.png",
                            Title = "Crispy shredded chicken"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Cook bacon in an air fryer to achieve a crispy texture with less fat. The perfect bacon sandwich starts here",
                            ImageUrl = "/Images/Quick&Easy/Air-Fryer-Bacon.png",
                            Title = "Air fryer bacon"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "An easy Mexican breakfast that'll keep you going all morning, this huevos rancheros recipe (aka 'ranch eggs') is packed with vibrant colours and flavours.",
                            ImageUrl = "/Images/Quick&Easy/easy-huevos-rancheros.png",
                            Title = "Easy huevos rancheros"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Combine sticky toffee pudding sponge with a generous helping of chocolate chunks and chocolate sauce for the ultimate comforting dessert",
                            ImageUrl = "/Images/Desserts/chocolate_toffee_pudding.png",
                            Title = "Self-saucing sticky toffee chocolate pudding"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "We've blended two tempting sweet treats – rocky road and cheesecake – to create this irresistible make-ahead dessert.",
                            ImageUrl = "/Images/Desserts/cheesecake-pudding.png",
                            Title = "Rocky road cheesecake pudding"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "You can't beat a traditional apple filling topped with crispy, buttery crumble - classic comfort food at its best",
                            ImageUrl = "/Images/Desserts/apple-crumble.png",
                            Title = "The best apple crumble"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "A simple but very impressive pud, light enough to have a slice to finish a big meal",
                            ImageUrl = "/Images/Desserts/lemon_cheesecake.png",
                            Title = "Luscious lemon baked cheesecake"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "Get the maximum flavour out of all the veg in our pasta bake by pan-frying it first. You can also freeze this for up to three months to enjoy on busier days",
                            ImageUrl = "/Images/Pasta/vegetable-pasta.png",
                            Title = "Vegetable pasta bake"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Description = "Celebrate pumpkins in autumn with this easy pasta dish that makes the most of this gourd.                Vodka and chilli provide a lovely deep flavour",
                            ImageUrl = "/Images/Pasta/Pumpkin-pasta.png",
                            Title = "Pumpkin pasta alla vodka"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Description = "Have a glut of tomatoes? Put them to good use in this one-pan orzo dish, perfect for a family midweek dinner. Finish with fresh parsley and plenty of parmesan",
                            ImageUrl = "/Images/Pasta/One-pot-tomato-orzo.png",
                            Title = "One-pot tomato orzo"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Description = "Whip up a simple cacio e pepe for a speedy lunch. With four simple ingredients – spaghetti, pepper, parmesan and butter – this is a storecupboard favourite",
                            ImageUrl = "/Images/Pasta/One-pot-tomato-orzo.png",
                            Title = "Cacio e pepe"
                        });
                });

            modelBuilder.Entity("MyRecipes.Api.Entities.RecipeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecipeCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Quick&Easy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dessert"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pasta"
                        });
                });

            modelBuilder.Entity("MyRecipes.Api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Username = "Sime1"
                        },
                        new
                        {
                            Id = 2,
                            Username = "Sime2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
