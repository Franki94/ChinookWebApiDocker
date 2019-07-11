namespace Chinook.WebApi.Repository.MySql.Migrations.Data
{
    public partial class SeedData
    {
        public const string AddPlayList = @"
use chinook;

INSERT INTO Playlist (PlaylistId, Name) VALUES (1, N'Music');
INSERT INTO Playlist (PlaylistId, Name) VALUES (2, N'Movies');
INSERT INTO Playlist (PlaylistId, Name) VALUES (3, N'TV Shows');
INSERT INTO Playlist (PlaylistId, Name) VALUES (4, N'Audiobooks');
INSERT INTO Playlist (PlaylistId, Name) VALUES (5, N'90’s Music');
INSERT INTO Playlist (PlaylistId, Name) VALUES (6, N'Audiobooks');
INSERT INTO Playlist (PlaylistId, Name) VALUES (7, N'Movies');
INSERT INTO Playlist (PlaylistId, Name) VALUES (8, N'Music');
INSERT INTO Playlist (PlaylistId, Name) VALUES (9, N'Music Videos');
INSERT INTO Playlist (PlaylistId, Name) VALUES (10, N'TV Shows');
INSERT INTO Playlist (PlaylistId, Name) VALUES (11, N'Brazilian Music');
INSERT INTO Playlist (PlaylistId, Name) VALUES (12, N'Classical');
INSERT INTO Playlist (PlaylistId, Name) VALUES (13, N'Classical 101 - Deep Cuts');
INSERT INTO Playlist (PlaylistId, Name) VALUES (14, N'Classical 101 - Next Steps');
INSERT INTO Playlist (PlaylistId, Name) VALUES (15, N'Classical 101 - The Basics');
INSERT INTO Playlist (PlaylistId, Name) VALUES (16, N'Grunge');
INSERT INTO Playlist (PlaylistId, Name) VALUES (17, N'Heavy Metal Classic');
INSERT INTO Playlist (PlaylistId, Name) VALUES (18, N'On-The-Go 1');";
    }
}
