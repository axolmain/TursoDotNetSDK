namespace Turso.Client.PlatformAPI.Database.Models;

public class Usage
{
    public int RowsRead { get; set; }
    public int RowsWritten { get; set; }
    public int StorageBytes { get; set; }
}