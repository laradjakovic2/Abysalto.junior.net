 # 🧩 .NET Web API – Restaurant App

Ovo je jednostavna .NET 8 Web API aplikacija koja demonstrira osnovne principe:
- Entity Framework Core (Code First)
- Seed inicijalnih podataka
- Sortiranje
- Pokretanje kroz lokalni SQL Server

---
## ⚙️ 1. Za pokretanje je potrebno
- Visual Studio

## ⚙️ 2. Konfiguracija connection stringa

U `secrets.json` zaljepiti sljedeći connection string za spajanje na bazu:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=RestaurantDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

## ⚙️ Pokrenutanje
- pokrenuti aplikaciju putem 'https' u Visual Studiu ili putem cmd-a:
`
dotnet ef database update
dotnet run
`
- aplikacija je dostupna na localhost:7056

