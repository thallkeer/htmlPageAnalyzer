using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using HtmlPageAnalyzer.Core;
using HtmlPageAnalyzer.Core.DataInterfaces;

namespace HtmlPageAnalyzer.DataAccess
{
    /// <summary>
    /// Implementation of data access for TextAnalysis
    /// </summary>
    public class TextAnalysisDao : ITextAnalysisDao
    {
        private const string TABLE_NAME = "TextAnalysis";
        private readonly string _connectionString;

        public TextAnalysisDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Saves analysis result to database
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task SaveAnalysisStatsAsync(TextAnalysisRecord record)
        {
            using IDbConnection cnn = new SqlConnection(_connectionString);
            string insertQuery = @$"INSERT INTO [dbo].[{TABLE_NAME}]([Date], [Url], [Statistics]) 
                                    OUTPUT INSERTED.[Id]
                                    VALUES (@Date, @Url, @Statistics);";

            int newRecordId = await cnn.QuerySingleAsync<int>(insertQuery, record);
            record.Id = newRecordId;
        }

        /// <summary>
        ///Retrieves all data from a text analysis table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TextAnalysisRecord>> GetAnalysisStatsAsync()
        {
            IEnumerable<TextAnalysisRecord> allRecords = null;
            using IDbConnection cnn = new SqlConnection(_connectionString);
            allRecords = await cnn.QueryAsync<TextAnalysisRecord>(@$"SELECT * FROM {TABLE_NAME};");
            return allRecords;
        }
    }
}
