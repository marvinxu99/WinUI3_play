namespace MVVM_play.Data.DbInitializer;

public static class DbInitializer
{
    public static async void Initialize()
    {
        await InitCodeValueSet.SeedAsync();


    }
}
