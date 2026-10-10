using System.Diagnostics;

public static class ProjectGenerator
{
    public static string MapDatabaseToFlag(string databaseChoice)
    {
        return databaseChoice switch
        {
            var db when db.StartsWith("MySql") => "sql",
            var db when db.StartsWith("MongoDB") => "mongodb",
            var db when db.StartsWith("PostgreSQL") => "postgresql",
            var db when db.StartsWith("Sqlite") => "sqlite",
            _ => "none"
        };
    }

    public static void EnsureTemplateInstalled()
    {

        string templatePath = @"C:\Users\Rafael\Documents\dev\C#\dotnet-basekit-tools\DotnetBaseKit.Templates\bin\Release";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"new install \"{templatePath}\" --force",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        process.WaitForExit();
    }

    public static (bool Success, string Error) CreateSolution(string projectName, string dbFlag, bool includeTests)
    {
        string args = $"new basekit -n \"{projectName}\" --database {dbFlag} --include-tests {includeTests.ToString().ToLower()}";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.StartInfo.EnvironmentVariables["DOTNET_CLI_UI_LANGUAGE"] = "en-US";

        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            string message = !string.IsNullOrWhiteSpace(error) ? error : output;
            return (false, message);
        }

        return (true, string.Empty);
    }
}
