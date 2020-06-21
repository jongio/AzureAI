﻿using AzureAI.CallCenterTalksAnalysis.Core.Model;
using AzureAI.CallCenterTalksAnalysis.Core.Services.Interfaces;
using AzureAI.CallCenterTalksAnalysis.FunctionApps.Utils;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureAI.CallCenterTalksAnalysis.FunctionApps.Functions
{
    internal class TextFileAnalyzer
    {
        private readonly ITextFileProcessingService _textFileProcessingService;

        public TextFileAnalyzer(ITextFileProcessingService textFileProcessingService)
        {
            _textFileProcessingService = textFileProcessingService;
        }

        [FunctionName(FunctionNamesRepository.TextFileAnalyzerFunc)]
        public async Task<FileAnalysisResult> AnalyzeAudioVideoFile([ActivityTrigger] InputFileData inputFileData, ILogger log)
        {
            var fileAnalysisResult = await _textFileProcessingService.AnalyzeFileContent(inputFileData);
            return fileAnalysisResult;
        }
    }
}
