using System.Collections.Generic;
using System.Threading.Tasks;

namespace HtmlPageAnalyzer.Core.DataInterfaces
{
    public interface ITextAnalysisDao
    {
        /// <summary>
        /// Retrieves all data from a text analysis table
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TextAnalysisRecord>> GetAnalysisStatsAsync();
        /// <summary>
        /// Saves analysis result to database
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task SaveAnalysisStatsAsync(TextAnalysisRecord record);
    }
}