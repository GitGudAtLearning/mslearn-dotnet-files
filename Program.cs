using Newtonsoft.Json;

// var salesJson = await File.ReadAllTextAsync($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
// var salesData = JsonConvert.DeserializeObject<MyNamespace.SalesTotal>(salesJson);

// if (salesData != null)
// {
//     Console.WriteLine(salesData.Total);

//     //File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", salesData.Total.ToString());
//     await File.AppendAllTextAsync($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{salesData.Total}{Environment.NewLine}");
// }
// else
// {
//     Console.WriteLine("Sales data is null.");
// }

// namespace MyNamespace
// {
//     class SalesTotal
//     {
//         public double Total { get; set; }
//     }
// }

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);


var salesTotal = CalculateSalesTotal(salesFiles);

await File.AppendAllTextAsync(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);

        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}

record SalesData(double Total);

// string filePath = Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "newDir");
// Directory.CreateDirectory(filePath);
// bool exists = Directory.Exists(filePath);
// await File.WriteAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");

// Console.WriteLine(exists);

// var currentDirectory = Directory.GetCurrentDirectory();
// var storesDirectory = Path.Combine(currentDirectory, "stores");
// var salesFiles = FindFiles(storesDirectory);

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }



// Console.WriteLine(Directory.GetCurrentDirectory());

// string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
// Console.WriteLine(docPath);

// char sep = Path.DirectorySeparatorChar;

// Console.WriteLine($"stores{sep}201");

// Console.WriteLine(Path.Combine("stores", "201")); // outputs: stores/201

// Console.WriteLine(Path.GetExtension("sales.json")); // outputs: .json

// string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

// FileInfo info = new FileInfo(fileName);

// Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more


// var salesFiles = FindFiles("stores");

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }

// IEnumerable<string> FindFiles(string folderName)
// {
//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     var salesFiles = foundFiles.Where(file => file.EndsWith("sales.json")).ToList();

//     return salesFiles;
// }

// var salesFiles = FindFiles("stores");

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }

// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         var extension = Path.GetExtension(file);
//         if (extension == ".json")
//         {
//             salesFiles.Add(file);
//         }
//     }

//     return salesFiles;
// }