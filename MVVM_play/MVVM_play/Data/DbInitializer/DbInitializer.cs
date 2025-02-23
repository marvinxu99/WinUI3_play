namespace MVVM_play.Data.DbInitializer;

public static class DbInitializer
{
    public static async void Initialize()
    {
        ;// Code Value Set
        await InitCodeValueSet.SeedAsync();

        // Code Values

    }
}
