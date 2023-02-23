# Uppgift BMI och BMR

Skriv ett program för att beräkna BMI och BMR för både män och kvinnor.

Först programmet ska räkna ut **BMI-Body Mass Index**. BMI är ett mått på
förhållandet mellan vikt och längd.  Detta mått används bland annat av WHO
(Världshälsoorganisationen) för att definiera övervikt/fetma och ska ses
som en riktlinje.

Beräknings formel för BMI är följande:

```BMI = 1.3*vikt(kg)/höjd(m)2.5```

Programmet ska också skriva ut om personen har en normal vikt eller inte
enligt följande tabell.

BMI tabell[^1]

BMI | Vikt
:--- | :---:
BMI under 18.5 | "undervikt"
BMI 18.5–25 | "sund och normal vikt"
BMI 25–30 | "övervikt"
BMI 30–40 | "kraftig övervikt"
BMI över 40 | "extrem övervikt"


Programmet ska sedan räkna ut BMR-basal metabolic rate. BMR är det dagliga
energibehov som behövs för att hålla en persons vitala organ i total vila.

En av formlerna som används för att räkna detta är Mifflin-st Jeou equation:

För män:

```BMR = 66.47 + (13.75 * (i kg)weight) + (5.003 * (i cm)höjd) - (6.755 * år)```

För kvinnor:

```BMR = 655.1 + (9.563 * (i kg)weight) + (1.85 * (i cm)höjd) - (4.676 * år)```

Programmet ska verifiera om inmatningen är konsekvent:

- 50 [cm] ≤ lägd ≤ 220 [cm]
- 10 [kg] ≤ vikt ≤ 250 [kg]
- 18 [år] ≤ alder ≤ 70 [år]

Programmet ska sedan skriva ut både bmi och bmr.

[^1]: Tabellen nedan gäller för män och kvinnor över 18 år med normal kroppsbyggnad. 
