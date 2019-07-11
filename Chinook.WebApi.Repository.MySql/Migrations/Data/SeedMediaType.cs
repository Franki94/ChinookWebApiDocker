namespace Chinook.WebApi.Repository.MySql.Migrations.Data
{
    public partial class SeedData
    {
        public const string AddMediaTypeData = @"
use chinook;

INSERT INTO MediaType (MediaTypeId, Name) VALUES (1, N'MPEG audio file');
INSERT INTO MediaType (MediaTypeId, Name) VALUES (2, N'Protected AAC audio file');
INSERT INTO MediaType (MediaTypeId, Name) VALUES (3, N'Protected MPEG-4 video file');
INSERT INTO MediaType (MediaTypeId, Name) VALUES (4, N'Purchased AAC audio file');
INSERT INTO MediaType (MediaTypeId, Name) VALUES (5, N'AAC audio file');
";
    }
}
