namespace CommunityToolkit.WinForms.Controls.Tooling.IO;

/// <summary>
/// Provides methods to generate and disambiguate filenames and folders based on various strategies.
/// </summary>
public class FilenameDisambiguator
{
    private string? _title;
    private string _extension = string.Empty;
    private string? _basePath;
    private GenerationStrategy _generationStrategy = GenerationStrategy.None;
    private bool _combineUniquePath;

    private string _dateFilenameAmendmentFormat = "yy-MM-dd HH-mm-ss";
    private int _maxLengthFilename = 255;
    private int _maxLengthFolder = 50;

    /// <summary>
    /// Parameterless constructor.
    /// </summary>
    public FilenameDisambiguator()
    {
    }

    /// <summary>
    /// Initializes a new instance with the specified title and extension.
    /// </summary>
    /// <param name="title">The title used to generate the filename and folder.</param>
    /// <param name="extension">The file extension including the leading dot.</param>
    /// <param name="combineUniquePath">
    /// If true, a unique folder (derived from the Title) will be generated.
    /// </param>
    public FilenameDisambiguator(string title, string extension, bool combineUniquePath = false)
    {
        Title = title;
        Extension = extension;
        _combineUniquePath = combineUniquePath;
    }

    /// <summary>
    /// Initializes a new instance with the specified title, base path, and extension.
    /// </summary>
    /// <param name="title">The title used to generate the filename and folder.</param>
    /// <param name="basePath">The base folder path.</param>
    /// <param name="extension">The file extension including the leading dot.</param>
    /// <param name="combineUniquePath">
    /// If true, a unique folder (derived from the Title) will be generated.
    /// </param>
    public FilenameDisambiguator(string title, string basePath, string extension, bool combineUniquePath = false)
    {
        Title = title;
        BasePath = basePath;
        Extension = extension;
        _combineUniquePath = combineUniquePath;
    }

    /// <summary>
    /// Initializes a new instance with the specified generation strategy and extension.
    /// Title is not provided so only DateBased or GuidBase are allowed.
    /// </summary>
    /// <param name="generationStrategy">
    /// The generation strategy. Must be DateBased or GuidBase.
    /// </param>
    /// <param name="extension">The file extension including the leading dot.</param>
    /// <param name="combineUniquePath">
    /// If true, a unique folder (using a default FolderCandidate) will be generated.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if an invalid generation strategy is provided.
    /// </exception>
    public FilenameDisambiguator(GenerationStrategy generationStrategy, string extension, bool combineUniquePath = false)
    {
        if (generationStrategy == GenerationStrategy.None ||
            generationStrategy == GenerationStrategy.DateAmended)
        {
            throw new ArgumentException(
                "For this constructor, generationStrategy must be DateBased or GuidBase.",
                nameof(generationStrategy));
        }

        _generationStrategy = generationStrategy;
        Extension = extension;
        _combineUniquePath = combineUniquePath;
    }

    /// <summary>
    /// Initializes a new instance with the specified title, extension, and generation strategy.
    /// When a Title is provided, only DateAmended is allowed.
    /// </summary>
    /// <param name="title">The title used to generate the filename and folder.</param>
    /// <param name="extension">The file extension including the leading dot.</param>
    /// <param name="generationStrategy">
    /// The generation strategy. Must be DateAmended.
    /// </param>
    /// <param name="combineUniquePath">
    /// If true, a unique folder (derived from the Title) will be generated.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if generationStrategy is not DateAmended.
    /// </exception>
    public FilenameDisambiguator(string title, string extension,
        GenerationStrategy generationStrategy, bool combineUniquePath = false)
    {
        if (generationStrategy != GenerationStrategy.DateAmended)
        {
            throw new ArgumentException(
                "When Title is provided with a generation strategy, only DateAmended is allowed.",
                nameof(generationStrategy));
        }

        Title = title;
        Extension = extension;

        _generationStrategy = generationStrategy;
        _combineUniquePath = combineUniquePath;
    }

    /// <summary>
    /// Initializes a new instance with the specified title, base path, extension, and generation strategy.
    /// When a Title is provided, only DateAmended is allowed.
    /// </summary>
    /// <param name="title">The title used to generate the filename and folder.</param>
    /// <param name="basePath">The base folder path.</param>
    /// <param name="extension">The file extension including the leading dot.</param>
    /// <param name="generationStrategy">
    /// The generation strategy. Must be DateAmended.
    /// </param>
    /// <param name="combineUniquePath">
    /// If true, a unique folder (derived from the Title) will be generated.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if generationStrategy is not DateAmended.
    /// </exception>
    public FilenameDisambiguator(string title, string basePath, string extension,
        GenerationStrategy generationStrategy, bool combineUniquePath = false)
    {
        if (generationStrategy != GenerationStrategy.DateAmended)
        {
            throw new ArgumentException(
                "When Title is provided with a generation strategy, only DateAmended is allowed.",
                nameof(generationStrategy));
        }

        Title = title;
        BasePath = basePath;
        Extension = extension;

        _generationStrategy = generationStrategy;
        _combineUniquePath = combineUniquePath;
    }

    // Properties

    /// <summary>
    /// Gets or sets the auto‑generation strategy for the filename.
    /// Changing this property will validate against the current Title.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown if an implausible value is set based on Title.
    /// </exception>
    public GenerationStrategy GenerationStrategy
    {
        get => _generationStrategy;
        set
        {
            if (!string.IsNullOrWhiteSpace(Title))
            {
                // When Title is provided, only DateAmended or None are valid.
                if (value != GenerationStrategy.DateAmended &&
                    value != GenerationStrategy.None)
                {
                    throw new InvalidOperationException(
                        "When Title is provided, only GenerationStrategy of DateAmended or None is allowed.");
                }
            }
            else if (value == GenerationStrategy.DateAmended)
            {
                throw new InvalidOperationException(
                    "GenerationStrategy DateAmended requires a Title.");
            }

            _generationStrategy = value;
        }
    }

    /// <summary>
    /// Gets or sets the title used to generate the filename and folder.
    /// Setting the Title resets GenerationStrategy to None unless it is already DateAmended.
    /// </summary>
    public string? Title
    {
        get => _title;
        set
        {
            _title = value;

            if (!string.IsNullOrWhiteSpace(value) &&
                _generationStrategy != GenerationStrategy.DateAmended)
            {
                _generationStrategy = GenerationStrategy.None;
            }
        }
    }

    /// <summary>
    /// Gets or sets the file extension, including the leading dot.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// Thrown if set to null.
    /// </exception>
    public string Extension
    {
        get => _extension;
        set => _extension = value ?? throw new ArgumentNullException(nameof(Extension));
    }

    /// <summary>
    /// Gets or sets the base folder path.
    /// </summary>
    public string? BasePath
    {
        get => _basePath;
        set => _basePath = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether both a unique folder and file should be generated.
    /// When true, the file will be placed in a unique folder derived from the Title.
    /// </summary>
    public bool CombineUniquePath
    {
        get => _combineUniquePath;
        set => _combineUniquePath = value;
    }

    /// <summary>
    /// Gets or sets the date format used when generating a filename based on date.
    /// </summary>
    public string DateFilenameAmendmentFormat
    {
        get => _dateFilenameAmendmentFormat;
        set => _dateFilenameAmendmentFormat = value;
    }

    /// <summary>
    /// Gets or sets the maximum allowed length for the generated filename.
    /// </summary>
    public int MaxLengthFilename
    {
        get => _maxLengthFilename;
        set => _maxLengthFilename = value;
    }

    /// <summary>
    /// Gets or sets the maximum allowed length for the generated folder name.
    /// </summary>
    public int MaxLengthFolder
    {
        get => _maxLengthFolder;
        set => _maxLengthFolder = value;
    }

    /// <summary>
    /// Gets the candidate filename (without extension) based on the provided parameters.
    /// This value is computed but is not necessarily unique until disambiguation.
    /// </summary>
    public string FilenameCandidate
    {
        get
        {
            string candidate = GenerationStrategy switch
            {
                GenerationStrategy.None =>
                    string.IsNullOrWhiteSpace(Title)
                        ? throw new InvalidOperationException("Title must be provided when GenerationStrategy is None.")
                        : Sanitize(Title),

                GenerationStrategy.DateBased =>
                    !string.IsNullOrWhiteSpace(Title)
                        ? throw new InvalidOperationException("Title must not be provided for DateBased strategy.")
                        : DateTime.Now.ToString(DateFilenameAmendmentFormat),

                GenerationStrategy.GuidBase =>
                    !string.IsNullOrWhiteSpace(Title)
                        ? throw new InvalidOperationException("Title must not be provided for GuidBase strategy.")
                        : Guid.NewGuid().ToString(),

                GenerationStrategy.DateAmended =>
                    string.IsNullOrWhiteSpace(Title)
                        ? throw new InvalidOperationException("Title must be provided for DateAmended strategy.")
                        : $"{Sanitize(Title)} {DateTime.Now.ToString(DateFilenameAmendmentFormat)}",

                _ => throw new NotSupportedException("Unsupported generation strategy.")
            };

            if (GenerationStrategy == GenerationStrategy.DateAmended &&
                candidate.Length > MaxLengthFilename)
            {
                candidate = candidate[..MaxLengthFilename];
            }

            return candidate;
        }
    }

    /// <summary>
    /// Gets the candidate folder name based on the Title.
    /// This value is computed but is not necessarily unique until disambiguation.
    /// </summary>
    public string FolderCandidate
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                // When Title is not provided, use a default folder name.
                return "DefaultFolder";
            }

            string folder = Sanitize(Title);

            return folder.Length > MaxLengthFolder
                ? folder[..MaxLengthFolder]
                : folder;
        }
    }

    // Methods

    /// <summary>
    /// Returns the resulting filename tuple after disambiguation.
    /// The tuple contains the folder, filename (without extension), and extension.
    /// </summary>
    /// <returns>A tuple of (folder, filename, extension).</returns>
    public (string folder, string filename, string extension) GetResultingFilename()
    {
        if (CombineUniquePath)
        {
            // Unique folder is generated; file candidate remains unchanged.
            string folder = GetResultingFoldername();
            return (folder, FilenameCandidate, Extension);
        }
        else
        {
            if (string.IsNullOrWhiteSpace(BasePath))
            {
                throw new InvalidOperationException("BasePath must be provided when CombineUniquePath is false.");
            }

            string candidatePath = Path.Combine(BasePath, FilenameCandidate + Extension);
            int count = 1;

            while (File.Exists(candidatePath))
            {
                candidatePath = Path.Combine(BasePath, $"{FilenameCandidate} ({count}){Extension}");
                count++;
            }

            return (BasePath, Path.GetFileNameWithoutExtension(candidatePath), Extension);
        }
    }

    /// <summary>
    /// Returns the resulting folder name after disambiguation.
    /// If CombineUniquePath is false, returns BasePath.
    /// </summary>
    /// <returns>The resulting unique folder name.</returns>
    public string GetResultingFoldername()
    {
        if (string.IsNullOrWhiteSpace(BasePath))
        {
            throw new InvalidOperationException("BasePath must be provided.");
        }

        if (!CombineUniquePath)
        {
            return BasePath;
        }

        string folderCandidate = FolderCandidate;
        string candidateFolder = Path.Combine(BasePath, folderCandidate);
        int count = 1;

        while (Directory.Exists(candidateFolder))
        {
            candidateFolder = Path.Combine(BasePath, $"{folderCandidate} ({count})");
            count++;
        }

        return candidateFolder;
    }

    /// <summary>
    /// Sanitizes the input string by removing invalid filename characters.
    /// </summary>
    /// <param name="input">The input string to sanitize.</param>
    /// <returns>A sanitized string safe for use in filenames and folder names.</returns>
    private static string Sanitize(string input)
    {
        char[] invalidChars = Path.GetInvalidFileNameChars();

        return new string([.. input.Where(ch => !invalidChars.Contains(ch))]);
    }

    /// <summary>
    /// Expands the given path by replacing environment variables with their values.
    /// </summary>
    /// <param name="path">The path containing environment variables to expand.</param>
    /// <returns>The expanded path.</returns>
    public static string ExpandPath(string path) => Environment.ExpandEnvironmentVariables(path);

    /// <summary>
    /// Shrinks the given full path by replacing known environment variable values with their names.
    /// </summary>
    /// <param name="fullPath">The full path to shrink.</param>
    /// <returns>The shrunk path with environment variable names.</returns>
    public static string ShrinkPath(string fullPath)
    {
        Dictionary<string, string> envVars = new()
        {
            { "%ONEDRIVE%", Environment.GetEnvironmentVariable("ONEDRIVE") ?? "" },
            { "%ONEDRIVECOMMERCIAL%", Environment.GetEnvironmentVariable("ONEDRIVECOMMERCIAL") ?? "" },
            { "%ONEDRIVECONSUMER%", Environment.GetEnvironmentVariable("ONEDRIVECONSUMER") ?? "" },
            { "%USERPROFILE%", Environment.GetEnvironmentVariable("USERPROFILE") ?? "" },
            { "%APPDATA%", Environment.GetEnvironmentVariable("APPDATA") ?? "" },
            { "%LOCALAPPDATA%", Environment.GetEnvironmentVariable("LOCALAPPDATA") ?? "" },
            { "%PROGRAMFILES%", Environment.GetEnvironmentVariable("PROGRAMFILES") ?? "" },
            { "%WINDIR%", Environment.GetEnvironmentVariable("WINDIR") ?? "" }
        };

        foreach (KeyValuePair<string, string> lookup in envVars)
        {
            if (!string.IsNullOrEmpty(lookup.Value)
                && fullPath.StartsWith(lookup.Value, StringComparison.OrdinalIgnoreCase))
            {
                return string.Concat(lookup.Key, fullPath.AsSpan(lookup.Value.Length));
            }
        }

        return fullPath;
    }
}
