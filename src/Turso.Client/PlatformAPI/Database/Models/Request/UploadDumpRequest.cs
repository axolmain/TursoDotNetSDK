namespace Turso.Client.PlatformAPI.Database.Models.Request;

/// <summary>
/// Represents a Request to upload a database dump.
/// </summary>
public class UploadDumpRequest
{
    /// <summary>
    /// Gets or sets the binary content of the dump file.
    /// </summary>
    public byte[] DumpFileContent { get; set; }

    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    public string FileName { get; set; }

    public UploadDumpRequest(byte[] dumpFileContent, string fileName)
    {
        DumpFileContent = dumpFileContent;
        FileName = fileName;
    }
}