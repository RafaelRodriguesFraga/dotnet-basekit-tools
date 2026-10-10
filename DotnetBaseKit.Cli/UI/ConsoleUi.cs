using Spectre.Console;

public static class ConsoleUi
{
    public static void ShowWelcomeBanner()
    {
        AnsiConsole.Write(
            new FigletText("DotnetBaseKit")
                .Color(Color.Blue));

        AnsiConsole.Write(new Rule("[blue]Interactive Project Generator v1.0.0[/]"));
        AnsiConsole.WriteLine();
    }

    public static string AskProjectName()
    {
        var projectName = AnsiConsole.Ask<string>("Enter [springgreen2]project name[/]: (Ex: [yellow]MyProject[/]):");

        while (string.IsNullOrWhiteSpace(projectName))
        {
            AnsiConsole.MarkupLine("[red]Project name cannot be empty.[/]");
            projectName = AnsiConsole.Ask<string>("Enter the [springgreen2]project name[/]:");
        }

        return projectName;
    }

    public static string AskDatabase()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Which [springgreen2]Database[/] do you want?")
                .PageSize(10)
                .HighlightStyle(new Style(foreground: Color.Cyan2))
                .AddChoices(new[]
                {
                    "MySql",
                    "MongoDB",
                    "PostgreSQL",
                    "Sqlite"
                }));
    }

    public static bool AskIncludeTests()
    {
        return AnsiConsole.Confirm(
            "Do you want to include a [springgreen2]unit test project[/] in the solution?",
            defaultValue: true);
    }

    public static void ShowCreationError(string errorOutput)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[red] Failed to create the solution:[/]");

        if (!string.IsNullOrWhiteSpace(errorOutput))
        {
            AnsiConsole.Write(new Text(errorOutput, new Style(Color.Red)));
        }
    }

    public static void ShowSuccessPanel(string projectName, string databaseChoice, bool includeTests)
    {
        AnsiConsole.WriteLine();

        var safeProjectName = Markup.Escape(projectName);
        var safeDatabaseChoice = Markup.Escape(databaseChoice);

        var projectsText = $"  • [darkseagreen3]{safeProjectName}.Api[/]\n" +
                           $"  • [darkseagreen3]{safeProjectName}.Application[/]\n" +
                           $"  • [darkseagreen3]{safeProjectName}.Domain[/]\n" +
                           $"  • [darkseagreen3]{safeProjectName}.Infra[/]\n" +
                           $"  • [darkseagreen3]{safeProjectName}.Shared[/]";

        if (includeTests)
        {
            projectsText += $"\n  • [darkseagreen3]{safeProjectName}.Tests[/]";
        }

        var panel = new Panel(new Markup(
            $"[springgreen2]Solution created successfully![/]\n\n" +
            $"[white]Name:[/] [yellow]{safeProjectName}[/]\n" +
            $"[white]Database:[/] [yellow]{safeDatabaseChoice}[/]\n" +
            $"[white]Tests:[/] [yellow]{(includeTests ? "Yes" : "No")}[/]\n\n" +
            $"[white]Projects created:[/]\n" +
            $"{projectsText}\n\n" +
            $"[white]To start working:[/]\n" +
            $"  [cyan]cd {safeProjectName}[/]\n" +
            $"  [cyan]dotnet build[/]"))
        {
            Border = BoxBorder.Rounded,
            Padding = new Padding(1, 1, 1, 1),
            Header = new PanelHeader(" DotnetBaseKit ", Justify.Left)
        };

        AnsiConsole.Write(panel);
    }
}
