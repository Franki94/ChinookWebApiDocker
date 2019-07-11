namespace Chinook.WebApi.Repository.MySql.Migrations.Data
{
    public partial class SeedData
    {
        public const string AddGenreData = @"
use chinook;

INSERT INTO Genre (GenreId, Name) VALUES (1, N'Rock');
INSERT INTO Genre (GenreId, Name) VALUES (2, N'Jazz');
INSERT INTO Genre (GenreId, Name) VALUES (3, N'Metal');
INSERT INTO Genre (GenreId, Name) VALUES (4, N'Alternative & Punk');
INSERT INTO Genre (GenreId, Name) VALUES (5, N'Rock And Roll');
INSERT INTO Genre (GenreId, Name) VALUES (6, N'Blues');
INSERT INTO Genre (GenreId, Name) VALUES (7, N'Latin');
INSERT INTO Genre (GenreId, Name) VALUES (8, N'Reggae');
INSERT INTO Genre (GenreId, Name) VALUES (9, N'Pop');
INSERT INTO Genre (GenreId, Name) VALUES (10, N'Soundtrack');
INSERT INTO Genre (GenreId, Name) VALUES (11, N'Bossa Nova');
INSERT INTO Genre (GenreId, Name) VALUES (12, N'Easy Listening');
INSERT INTO Genre (GenreId, Name) VALUES (13, N'Heavy Metal');
INSERT INTO Genre (GenreId, Name) VALUES (14, N'R&B/Soul');
INSERT INTO Genre (GenreId, Name) VALUES (15, N'Electronica/Dance');
INSERT INTO Genre (GenreId, Name) VALUES (16, N'World');
INSERT INTO Genre (GenreId, Name) VALUES (17, N'Hip Hop/Rap');
INSERT INTO Genre (GenreId, Name) VALUES (18, N'Science Fiction');
INSERT INTO Genre (GenreId, Name) VALUES (19, N'TV Shows');
INSERT INTO Genre (GenreId, Name) VALUES (20, N'Sci Fi & Fantasy');
INSERT INTO Genre (GenreId, Name) VALUES (21, N'Drama');
INSERT INTO Genre (GenreId, Name) VALUES (22, N'Comedy');
INSERT INTO Genre (GenreId, Name) VALUES (23, N'Alternative');
INSERT INTO Genre (GenreId, Name) VALUES (24, N'Classical');
INSERT INTO Genre (GenreId, Name) VALUES (25, N'Opera');
";
    }
}
