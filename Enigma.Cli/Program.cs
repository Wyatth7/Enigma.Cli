
var allArgs = args.AsQueryable();

var file = allArgs.SingleOrDefault(v => v.Contains("--file="));
var encrypt = allArgs.SingleOrDefault(v => v.Contains("--encrypt"));
var decrypt = allArgs.SingleOrDefault(v => v.Contains("--decrypt"));

Console.WriteLine(file);
Console.WriteLine(encrypt);
Console.WriteLine(decrypt);
