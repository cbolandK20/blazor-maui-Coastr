// See https://aka.ms/new-console-template for more information
Console.WriteLine("--- CoastR Migrator ---");
try
{
    var db = new Coastr.Persistence.Impl.CoasterDBContext();
} catch (Exception e)
{
    Console.WriteLine(e);
}

