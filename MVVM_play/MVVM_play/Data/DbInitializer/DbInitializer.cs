namespace MVVM_play.Data.DbInitializer;

public static class DbInitializer
{
    public static async void Initialize()
    {
        ;// Code Value Set
        await CodeValueSetSeeder.SeedAsync();

        // Code Values
        var cvSeeder = new CodeValueSeeder();

        // Codesets with same display, meaning, definition & description
        await cvSeeder.SeedAsync();

        // Codesets with different display, meaning, definition & description
        await cvSeeder.SeedAsync2();

    }
}
