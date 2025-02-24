namespace MVVM_play.Data.DbInitializer;

public static class DbInitializer
{
    public static async void Initialize()
    {
        ;// Code Value Set
        await CodeValueSetSeeder.SeedAsync();

        // Code Values
        var cvSeeder = new CodeValueSeeder();

        // Codeset 2 - Admit Sources
        await cvSeeder.SeedAsync();

    }
}
