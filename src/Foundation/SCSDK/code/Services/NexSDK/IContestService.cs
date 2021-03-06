﻿using System;
using System.Threading.Tasks;
using SitecoreCognitiveServices.Foundation.NexSDK.Contest.Models;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Services.NexSDK
{
    public interface IContestService
    {
        /// <summary>
        /// Gets detailed data science information generated by a session
        /// </summary>
        /// <remarks>
        /// #### Gets detailed data science information generated by a session
        /// During the execution of a session, many different algorithms can be run, in order to see which
        /// algorithm produces the best results.  The contest information returned from this endpoint contains
        /// details about all of the algorithms that were attempted, which one is the champion, and various scoring
        /// metrics which were used to determine the best algorithm.
        /// __Note:__ This endpoint is not available under the community plan.  Please [upgrade](http://nexosis.com/pricing) to a paid plan if you are currently on Community.
        /// Be sure to use the [Paid Subscription key](https://developers.nexosis.com/developer) if you have already upgraded.
        /// </remarks>
        /// <param name="sessionId">Session identifier for which to retrieve contest details</param>
        Task<ContestResponse> GetContest(Guid sessionId);

        /// <summary>
        /// Gets the champion of a contest, and the test data used in scoring the algorithm.
        /// </summary>
        /// <remarks>
        /// #### Gets the champion of a contest, and the test data used in scoring the algorithm
        /// This is the algorithm which was determined to score the best for the given contest.  Scoring metrics,
        /// as well as the test data, is returned.
        /// __Note:__ This endpoint is not available under the community plan.  Please [upgrade](http://nexosis.com/pricing) to a paid plan if you are currently on Community.
        /// Be sure to use the [Paid Subscription key](https://developers.nexosis.com/developer) if you have already upgraded.
        /// </remarks>
        /// <param name="sessionId">Session identifier for which to retrieve champion details.</param>
        /// <param name="options">Optional.  Additional options for querying for the champion</param>
        Task<ContestantResponse> GetChampion(Guid sessionId, ChampionQueryOptions options = null);

        /// <summary>
        /// Gets the selection criteria that is used to determined which algorithms were executed.
        /// </summary>
        /// <remarks>
        /// #### Gets the selection criteria that is used to determined which algorithms were executed.
        /// The _metricSets_ contain some information about the data source that was used by the session.  It includes
        /// some basic stats about the dataset, such as the mean and standard deviation.  For a forecast or impact session,
        /// it will also include information about what levels of seasonality were detected in the data.
        /// __Note:__ This endpoint is not available under the community plan.  Please [upgrade](http://nexosis.com/pricing) to a paid plan if you are currently on Community.
        /// Be sure to use the [Paid Subscription key](https://developers.nexosis.com/developer) if you have already upgraded.
        /// </remarks>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        Task<ContestSelectionResponse> GetSelection(Guid sessionId);

        /// <summary>
        /// Lists the contestant algorithms which were executed for this contest.
        /// </summary>
        /// <remarks>
        /// #### Lists the contestant algorithms which were executed for this contest.
        /// __Note:__ This endpoint is not available under the community plan.  Please [upgrade](http://nexosis.com/pricing) to a paid plan if you are currently on Community.
        /// Be sure to use the [Paid Subscription key](https://developers.nexosis.com/developer) if you have already upgraded.
        /// </remarks>
        /// <param name="sessionId">Session identifier for which to retrieve contestant algorithms.</param>
        Task<ChampionContestantList> ListContestants(Guid sessionId);


        /// <summary>
        /// Gets a specific contestant algorithm, and the test data used in scoring the algorithm.
        /// </summary>
        /// <remarks>
        /// #### Gets a specific contestant algorithm, and the test data used in scoring the algorithm
        /// This is one of the algorithms which were executed during a session.  Scoring metrics, as well as the test data, is returned.
        /// __Note:__ This endpoint is not available under the community plan.  Please [upgrade](http://nexosis.com/pricing) to a paid plan if you are currently on Community.
        /// Be sure to use the [Paid Subscription key](https://developers.nexosis.com/developer) if you have already upgraded.
        /// </remarks>
        /// <param name="sessionId">Session identifier for which to retrieve algorithm details.</param>
        /// <param name="contestantId">Identifier of the specific algorithm execution for which to retrieve details.</param>
        /// <param name="options">Optional.  Additional query options.</param>
        Task<ContestantResponse> GetContestant(Guid sessionId, string contestantId, ChampionQueryOptions options = null);
    }
}