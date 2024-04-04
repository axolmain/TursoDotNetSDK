using System.Text.Json.Serialization;

namespace Turso.Client.PlatformAPI.Database.Models.Request;

public class CreateDatabaseRequest
{
    public CreateDatabaseRequest(string name, string group)
    {
        Name = name;
        Group = group;
    }
    
    // Constructor for creating a parent database
    public CreateDatabaseRequest(string name, string group, bool isSchema)
    {
        Name = name;
        Group = group;
        IsSchema = isSchema;
    }

    // Constructor for creating a child database with a schema
    public CreateDatabaseRequest(string name, string group, string schema)
    {
        Name = name;
        Group = group;
        Schema = schema;
    }
    /// <summary>
    /// The name of the group where the database should be created. The group must already exist.
    /// </summary>
    [JsonPropertyName("group")]
    public string Group { get; set; }

    /// <summary>
    /// Mark this database as the parent schema database that updates child databases with any schema changes.
    /// </summary>
    [JsonPropertyName("is_schema")]
    public bool? IsSchema { get; set; }

    /// <summary>
    /// The name of the new database. Must contain only lowercase letters, numbers, dashes. No longer than 32 characters.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The name of the parent database to use as the schema.
    /// See <a href="https://docs.turso.tech/features/multi-db-schemas">Multi-DB Schemas.</a>
    /// </summary>
    [JsonPropertyName("schema")]
    public string Schema { get; set; }

    /// <summary>
    /// The seed to use for the new database.
    /// </summary>
    [JsonPropertyName("seed")]
    public Seed Seed { get; set; }

    /// <summary>
    /// The maximum size of the database in bytes. Values with units are also accepted, e.g. 1mb, 256mb, 1gb.
    /// </summary>
    [JsonPropertyName("size_limit")]
    public string SizeLimit { get; set; }
    
}