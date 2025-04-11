// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using PersonalChef.ApiModel.Model;
using PersonalChef.DataModel.Common;
using PersonalChef.DataModel.Model;
using static Azure.Core.HttpHeader;

public class RecipeContext(DbContextOptions<RecipeContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeasurementUnit>().HasData(GetMeasurementUnits());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeStep> RecipeSteps { get; set; }
    public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
    public DbSet<RecipeImage> RecipeImages { get; set; }

    private static IEnumerable<MeasurementUnit> GetMeasurementUnits()
    {
        foreach (Units u in Enum.GetValues(typeof(Units)))
        {
            yield return new MeasurementUnit(u);
        }
    }
}