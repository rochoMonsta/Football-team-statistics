# Football statistics

Програма, яка виконує зчитування та аналіз статистики з **.json** файлів, після чого, 
виводить на екран відповідні результати.

Завдання:

Потрібно розробити програму на **C#** яка буде відображати статистику матчів англійської футбольної ліги.
Вхідні дані: файли **en.1.json**, **en.2.json**, **en.3.json** де числа 1,2,3 відповідно Ліга 1, Ліга 2, Ліга 3.
Файли представляють усі зіграні матчі за сезон і їхній результат.

На екран потрбіно вивести статистику по всіх лігах:
* (1) Найкращу атакуючу команду (яка забила найбільшу кількість голів в своїй лізі)
* (2) Найкращу захисну команду (яка пропустила найменшу кількість голів в своїй лізі)
* (3) Найкращу команду за показником забиті-прапущені (пріорітет надавати команді з більшою кількістю забитих голів)

    *Приклад:*

    команда 1 забила 50 пропустила 43

    команда 2 забила 87 пропустила 80

    потрбіно вивести команду 2 бо в неї більша кількість забитих голів
* (4) Найрезультативніший день по всіх лігах (день коли було забито максимальну кількість голів сумарно по лігах1,2,3)

## Result

![Some pictures](https://github.com/rochoMonsta/Football-team-statistics/tree/master/Results/result1.png)

## Methods


**(1)** Найкращу атакуючу команду (яка забила найбільшу кількість голів в своїй лізі):
```csharp
sealed class Exercise
{
    public Team GetBestTeamByGoals(Season season)
    {
        return season.teams.FirstOrDefault(t => t.scoredGoals == season.teams.Max(s => s.scoredGoals));
    }
}
```

**(2)** Найкращу захисну команду (яка пропустила найменшу кількість голів в своїй лізі):
```csharp
sealed class Exercise
{
    public Team GetBestTeamByMinMissedGoals(Season season)
    {
        return season.teams.FirstOrDefault(t => t.missedGoals == season.teams.Min(s => s.missedGoals));
    }
}
```

**(3)** Найкращу команду за показником забиті-прапущені (пріорітет надавати команді з більшою кількістю забитих голів):
```csharp
sealed class Exercise
{
    public Team GetBestTeamByMaxGoalsToMissedGoals(Season season)
    {
        int maxDefference = season.teams.Max(s => s.differenceBetweenGoals);

        var teams = season.teams.Where(t => t.differenceBetweenGoals == maxDefference);

        return teams.FirstOrDefault(t => t.scoredGoals == teams.Max(t => t.scoredGoals));
    }
}
```

**(4)** Найрезультативніший день по всіх лігах (день коли було забито максимальну кількість голів сумарно по лігах1,2,3):
```csharp
sealed class Exercise
{
    public GameDay GetBestGameDayByCountOfScore(List<Season> seasons)
    {
        var dateList = new List<GameDay>();

        foreach (var season in seasons)
        {
            foreach (var gameDate in season.matches)
            {
                if (!dateList.Any(d => d.GameDate == gameDate.date))
                {
                    if (gameDate.score == null)
                        gameDate.score = new Score(new int[] { 0, 0 });
                    dateList.Add(new GameDay(gameDate.date, gameDate.score.ft));
                }
                else
                {
                    if (gameDate.score != null)
                        dateList[dateList.IndexOf(dateList.FirstOrDefault(d => d.GameDate == gameDate.date))].AddScore(gameDate.score.ft);
                }
            }
        }
        return dateList.FirstOrDefault(d => d.CountOfGoals == dateList.Max(d => d.CountOfGoals));
    }
}
```