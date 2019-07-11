using Chinook.WebApi.Repository.MySql;
using Chinook.WebApi.Repository.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.WebApi
{
    public class SeedData
    {
        public static void InitialData(IServiceProvider serviceProvider)
        {
            var contextMysql = serviceProvider.GetRequiredService<ChinookMySqlContext>();
            var contextSql = serviceProvider.GetRequiredService<ChinookSqlContext>();

            contextMysql.Database.EnsureCreated();

            if (!contextMysql.Genre.Any())
            {
                contextMysql.Genre.AddRangeAsync(contextSql.Genre);
                contextMysql.MediaType.AddRangeAsync(contextSql.MediaType);
                contextMysql.Artist.AddRangeAsync(contextSql.Artist);
                contextMysql.Album.AddRangeAsync(contextSql.Album);
                contextMysql.Track.AddRangeAsync(contextSql.Track);
                contextMysql.Employee.AddRangeAsync(contextSql.Employee);
                contextMysql.Customer.AddRangeAsync(contextSql.Customer);
                contextMysql.Invoice.AddRangeAsync(contextSql.Invoice);
                contextMysql.InvoiceLine.AddRangeAsync(contextSql.InvoiceLine);
                contextMysql.Playlist.AddRangeAsync(contextSql.Playlist);
                contextMysql.PlaylistTrack.AddRangeAsync(contextSql.PlaylistTrack);
                contextMysql.SaveChangesAsync();
            }

        }
    }
}
