﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PersonalChef.ApiModel.MigrationService.Migrations
{
    [DbContext(typeof(RecipeContext))]
    partial class RecipeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonalChef.ApiModel.Model.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("PersonalChef.ApiModel.Model.MeasurementUnit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UnitId");

                    b.ToTable("MeasurementUnits");

                    b.HasData(
                        new
                        {
                            UnitId = 1,
                            Name = "Cup"
                        },
                        new
                        {
                            UnitId = 2,
                            Name = "Pint"
                        },
                        new
                        {
                            UnitId = 3,
                            Name = "Quart"
                        },
                        new
                        {
                            UnitId = 4,
                            Name = "Gallon"
                        },
                        new
                        {
                            UnitId = 5,
                            Name = "Milliliter"
                        },
                        new
                        {
                            UnitId = 6,
                            Name = "Liter"
                        },
                        new
                        {
                            UnitId = 7,
                            Name = "Teaspoon"
                        },
                        new
                        {
                            UnitId = 8,
                            Name = "Tablespoon"
                        },
                        new
                        {
                            UnitId = 9,
                            Name = "FluidOunce"
                        },
                        new
                        {
                            UnitId = 10,
                            Name = "Pound"
                        },
                        new
                        {
                            UnitId = 11,
                            Name = "Ounce"
                        },
                        new
                        {
                            UnitId = 12,
                            Name = "Milligram"
                        },
                        new
                        {
                            UnitId = 13,
                            Name = "Gram"
                        },
                        new
                        {
                            UnitId = 14,
                            Name = "Kilogram"
                        },
                        new
                        {
                            UnitId = 15,
                            Name = "Millimeter"
                        },
                        new
                        {
                            UnitId = 16,
                            Name = "Centimeter"
                        },
                        new
                        {
                            UnitId = 17,
                            Name = "Meter"
                        },
                        new
                        {
                            UnitId = 18,
                            Name = "Inch"
                        },
                        new
                        {
                            UnitId = 19,
                            Name = "Object"
                        },
                        new
                        {
                            UnitId = 20,
                            Name = "Clove"
                        });
                });

            modelBuilder.Entity("PersonalChef.ApiModel.Model.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("PersonalChef.ApiModel.Model.RecipeImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("ImageBytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeImages");
                });

            modelBuilder.Entity("PersonalChef.ApiModel.Model.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UnitId");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("PersonalChef.ApiModel.Model.RecipeStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeSteps");
                });

            modelBuilder.Entity("PersonalChef.ApiModel.Model.RecipeImage", b =>
                {
                    b.HasOne("PersonalChef.ApiModel.Model.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("PersonalChef.ApiModel.Model.RecipeIngredient", b =>
                {
                    b.HasOne("PersonalChef.ApiModel.Model.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalChef.ApiModel.Model.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalChef.ApiModel.Model.MeasurementUnit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("PersonalChef.ApiModel.Model.RecipeStep", b =>
                {
                    b.HasOne("PersonalChef.ApiModel.Model.Recipe", "Recipe")
                        .WithMany("RecipeSteps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("PersonalChef.ApiModel.Model.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");

                    b.Navigation("RecipeSteps");
                });
#pragma warning restore 612, 618
        }
    }
}
