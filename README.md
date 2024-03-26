# TDD_Time

Strukturen `Time` i `TDD_Time` är en enkel tidsrepresentation i 24-timmarsformat. Den tillhandahåller egenskaper för timmar, minuter och sekunder, samt metoder för att jämföra och manipulera tidinstanser.

## Egenskaper

- `Hours`: Representerar timmarna i 24-timmarsformat.
- `Minutes`: Representerar minuterna.
- `Seconds`: Representerar sekunderna.

## Konstruktor

Strukturen `Time` har en konstruktor som tar tre parametrar:
public Time(int hours, int minutes, int seconds)

## Metoder

- `Equals(object? obj)`: Skriver över basmetoden `Equals` för att tillhandahålla ett sätt att jämföra två `Time`-instanser.
- `GetHashCode()`: Skriver över basmetoden `GetHashCode` för att generera en hashkod för `Time`-instansen.
- `IsValid(Time time)`: Kontrollerar om en `Time`-instans är giltig. Kastar ett `ArgumentOutOfRangeException` om tiden är utanför intervallet.
- `ToString(bool format)`: Skriver över basmetoden `ToString` för att formatera tiden som en sträng. Om `format` är `true`, returneras tiden i formatet `HH:MM:SS`. Om `format` är `false`, returneras tiden i formatet `HH:MM:SS AM/PM`.
- `IsAm()`: Kontrollerar om tiden är AM eller PM.

## Operatorer

Strukturen `Time` överlagrar flera operatorer för att jämföra och manipulera `Time`-instanser:

- `>` och `<`: Jämför två `Time`-instanser.
- `==` och `!=`: Kontrollerar om två `Time`-instanser är lika eller inte.
- `++` och `--`: Ökar eller minskar tiden med en sekund.
- `+` och `-`: Lägger till eller drar ifrån ett visst antal sekunder från tiden.
