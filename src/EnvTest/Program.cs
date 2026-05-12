
var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../..", ".env");

filePath = Path.GetFullPath(filePath);

DotNetEnv.Env.Load(filePath);

var envValue = Environment.GetEnvironmentVariable("DATABASE_URL");

Console.WriteLine($"Value of DATABASE_URL: {envValue}");