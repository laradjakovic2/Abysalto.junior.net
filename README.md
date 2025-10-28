# 🧩 .NET Web API – Restaurant App

Ovo je jednostavna .NET 9 Web API aplikacija za upravljanje narudžbama restorana koja demonstrira:

- Dohvaćanje i sortiranje narudžbi korisnika
- Kreiranje i upravljanje narudžbama

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

## ⚙️ 3. Pokrenutanje

- pokrenuti aplikaciju u Visual Studiu
- aplikacija je dostupna na: https://localhost:7056
- swagger dokumentacija dostupna je na: https://localhost:7056/index.html
