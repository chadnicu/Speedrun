# Speedrun

## Condiția
> Elaborați aplicația Orase care va gestiona datele din baza de date „Orase”. Fiecare oraș are la bază clasa Oras ce conține câmpurile CodOras, Denumire, NumarulLocuitori, CodTara unde CodTara reprezintă codul unei țări. O țară are la bază clasa Tara caracterizată de câmpurile CodTara, Denumire, Continent. 
Aplicația va permite salvarea datelor în bază de date și va conține următoarele: 
a.	Interfața aplicației cu afișarea informației din cele două tabele ale bazei de date;
b.	Interfețe pentru:
•	Inserarea/editare unui oraș;
•	Inserarea/editare unei țări;
c.	Interfețe pentru:
•	Căutarea și afișarea listei orașelor, cu un număr de locuitori mai mare de 1.000.000 de locuitori;
•	Căutarea și afișarea listei țărilor unui anumit continent; 
•	Afișarea listei țărilor cu calcul numărului de orașe.

## Versiuni
- NET Core 8.0
- EntityFrameWorkCore 8.0.11
- EntityFrameWorkCore.SqlServer 8.0.11 


## Snippets
```csharp
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)  { }

    public DbSet<Oras> Orase { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Oras>().ToTable("Oras");
    }
}
```

```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=NumeBd;Trusted_Connection=True;MultipleActiveResultSets=true"
```

```csharp
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

```csharp
public static void Seed(Context context)
{
    if (context.Tari.Any() || context.Orase.Any()) return;

    // ...
}
```

```csharp
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Context>();
    Seeder.Seed(context);
}
```
