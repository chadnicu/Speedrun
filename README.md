# Speedrun


## Versions
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
