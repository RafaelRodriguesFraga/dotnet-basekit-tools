using Spectre.Console;

ConsoleUi.ShowWelcomeBanner();

var projectName = ConsoleUi.AskProjectName();
var databaseChoice = ConsoleUi.AskDatabase();
var dbFlag = ProjectGenerator.MapDatabaseToFlag(databaseChoice);
var includeTests = ConsoleUi.AskIncludeTests();

bool success = false;
string errorMessage = string.Empty;

await AnsiConsole.Status()
    .Spinner(Spinner.Known.Dots)
    .SpinnerStyle(Style.Parse("cyan bold"))
    .StartAsync("Generating solution structure...", async ctx =>
    {
        ctx.Status("Checking template installation...");
        ProjectGenerator.EnsureTemplateInstalled();
        await Task.Delay(300);

        ctx.Status($"Creating solution '{projectName}'...");
        (success, errorMessage) = ProjectGenerator.CreateSolution(projectName, dbFlag, includeTests);
        await Task.Delay(300);
    });

if (success)
{
    ConsoleUi.ShowSuccessPanel(projectName, databaseChoice, includeTests);
}
else
{
    ConsoleUi.ShowCreationError(errorMessage);
}