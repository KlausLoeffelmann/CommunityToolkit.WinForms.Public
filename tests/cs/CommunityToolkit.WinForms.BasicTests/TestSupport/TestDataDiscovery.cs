using System.Runtime.CompilerServices;

namespace CommunityToolkit.WinForms.BasicTests.TestSupport;

internal static class TestDataDiscovery
{
    private const string UnitTestsDirectoryName = "UnitTests";
    private const string TestDataDirectoryName = "TestData";

    /// <summary>
    /// Discovers test data files with .csLiterals extension in the TestData directory relative to the current file.
    /// </summary>
    /// <param name="baseFilePath">The base file path, automatically provided by the compiler.</param>
    /// <returns>A collection of test data file names without extensions.</returns>
    public static TheoryData<string> GetCsLiteralsTestDataFiles([CallerFilePath] string? baseFilePath = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(baseFilePath);
        return GetTestDataFiles("*.csLiterals", baseFilePath, "SemanticKernel");
    }

    public static TheoryData<string> GetCsRoslynTestDataFiles([CallerFilePath] string? baseFilePath = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(baseFilePath);
        return GetTestDataFiles("*.csLiterals", baseFilePath, "Roslyn");
    }

    public static TheoryData<string> GetCsRoslynTestDataFiles(
        IEnumerable<string> testDataFiles,
        string baseFilePath = TestDataDirectoryName,
        string? subFolder = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(baseFilePath);
        return GetTestDataFiles("*.csLiterals", baseFilePath, "Roslyn");
    }



    /// <summary>
    /// Discovers test data files in the TestData directory relative to the current file.
    /// </summary>
    /// <param name="filePattern">The file pattern to search for.</param>
    /// <param name="baseFilePath">The base file path, automatically provided by the compiler.</param>
    /// <returns>A collection of test data file names without extensions.</returns>
    private static TheoryData<string> GetTestDataFiles(string filePattern, string baseFilePath, string subFolder)
    {
        ArgumentNullException.ThrowIfNull(baseFilePath);

        TheoryData<string> data = new TheoryData<string>();
        string? currentDirectory = Path.GetDirectoryName(baseFilePath);

        while (currentDirectory != null)
        {
            if (Path.GetFileName(currentDirectory) == UnitTestsDirectoryName)
            {
                string testDataDirectory = Path.Combine(
                    Path.GetDirectoryName(currentDirectory)!,
                    TestDataDirectoryName,
                    subFolder);

                foreach (string file in Directory.GetFiles(testDataDirectory, filePattern))
                {
                    data.Add(file);
                }
                break;
            }

            currentDirectory = Path.GetDirectoryName(currentDirectory);
        }

        return data;
    }

    public static string GetTestDataDirectoryPath(
        [CallerFilePath] string? baseFilePath = default, 
        string? subDirectoryPath = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(baseFilePath);

        var currentDirectory = Path.GetDirectoryName(baseFilePath);

        while (currentDirectory != null)
        {
            if (Path.GetFileName(currentDirectory) == UnitTestsDirectoryName)
            {
                string targetDirectory = Path.Combine(
                    Path.GetDirectoryName(currentDirectory)!,
                    Path.Combine(TestDataDirectoryName, subDirectoryPath ?? string.Empty));

                if (!Directory.Exists(targetDirectory))
                {
                    // We fail fast.
                    throw new InvalidOperationException($"Could not find the test data directory at '{targetDirectory}'.");
                }

                return targetDirectory;
            }

            currentDirectory = Path.GetDirectoryName(currentDirectory);
        }

        throw new InvalidOperationException("Could not find the test data directory.");
    }

    internal static TheoryData<string> GetTheoryDataFromFiles(List<string> files, string targetDirectory)
    {
        var data = new TheoryData<string>();

        // Iterate through all the files in the directory and make sure
        // that they exist. If they do, add them to the test data.
        // If they don't, we fail fast.
        foreach (string file in files)
        {
            string filePath = Path.Combine(targetDirectory, file);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"We have been trying to find the file '{filePath}', but it does not exist.");
            }

            data.Add(filePath);
        }

        return data;
    }
}
