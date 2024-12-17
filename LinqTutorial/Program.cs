using LinqPractice;

var musicians = MusicData.Musicians;

//Group musicians by the number of hobbies they have and retrieve the distinct
// instruments they play in each group.

var task10 = musicians
    .GroupBy(x => x.Hobbies.Count)
    .Select(x => new
    {
        HobbyCount = x.Key,
        Instruments = x.SelectMany(y=>y.Instruments).Distinct()
    });
foreach (var subcollection in task10)
{
    Console.WriteLine(subcollection.HobbyCount);
    foreach (var instrument in subcollection.Instruments)
    {
        Console.WriteLine(instrument);
    }
}


// var task2 = musicians.GroupBy(x => x.Instruments.Count);

//foreach (var subcollection in task2)
//{
//    Console.WriteLine(subcollection.Key);
//    foreach (var musician in subcollection)
//    {
//        Console.WriteLine(musician.Name);
//    }
//}

//Using Distinct, GroupBy, Any and All


//var task6 = musicians.Select(x => x.BirthDate.Year).Distinct().OrderBy(x=>x);
//foreach (var musician in task6)
//    Console.WriteLine(musician);

// var task4 = musicians.All(x => x.Hobbies.Count > 0);
// Console.WriteLine(task4);

// var task3 = musicians.Any(x => x.Height > 200);
// Console.WriteLine(task3);

//Retrieving specific elements from the collection

// var task17 = musicians.TakeWhile(x => !x.Name.Contains("k"));
// foreach (var musician in task17)
//     Console.WriteLine(musician);

// var task13 = musicians.Where(x => x.Height < 170).Take(2);
// foreach (var musician in task13)
//     Console.WriteLine(musician);


//I will only keep three
// var task10 = musicians.Skip(5).Take(3);
// foreach (var musician in task10)
//     Console.WriteLine(musician);

// var task8 = musicians.LastOrDefault(x => x.Hobbies.Count > 3);
// Console.WriteLine(task8);

// var task1 = musicians.First(x=> x.Height > 180);
// Console.WriteLine(task1);

// Projection (Select), ordering (OrderBy) and filtration (Where)  !!!!

// var task13 = musicians
//     .OrderBy(x => x.BirthDate.Year)
//     .ThenBy(x => x.Name);
//
// foreach (var musician in task13)
//     Console.WriteLine(musician);

// var task11 = musicians.OrderBy(x => x.Name);
// foreach (var musician in task11)
//     Console.WriteLine(musician);

// var task10 = musicians.Select(x => x.Name.Split(" ").Length);
// foreach (var number in task10)
//     Console.WriteLine(number);

// var task6 = musicians.Select(x => x.Name);
// foreach (var name in task6)
//     Console.WriteLine(name);

// var task5 = musicians.Where(x => x.Instruments.Contains("Guitar"));
// foreach (var musician in task5)
//     Console.WriteLine($"{musician.Name} plays: {string.Join(", ", musician.Instruments)}");

// var task1 = musicians.Where(x => !x.DateOfDeath.HasValue);
// foreach (var musician in task1)
//     Console.WriteLine(musician);

//Basic Linq features

//#8
// var task8 = musicians.Count(x => DateTime.Today.Year - x.BirthDate.Year > 50);
// Console.WriteLine(task8);

//#6
// var task6 = musicians.Max(x => x.BirthDate);
// Console.WriteLine(task6);

//#3
// var task3 = musicians.Average(x => x.Height);
// Console.WriteLine(task3);

//#1
// var task1 = musicians.Count();
// Console.WriteLine(task1);

// foreach (var musician in musicians)
//     Console.WriteLine(musician.Instruments.Count);