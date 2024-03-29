﻿using System;
using System.Linq;
using System.ServiceModel;
using Fintrak.Shared.Common.Contracts;
using Fintrak.Shared.Common.Exceptions;
using Fintrak.Client.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;
using Fintrak.Shared.Common.Services.QueryService;
using Fintrak.Shared.Common.Services;


namespace Fintrak.Client.IFRS.Contracts
{
    [ServiceContract]
    public interface IIFRS9Service : IServiceContract
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void RegisterModule();

        [OperationContract]
        UInt64 GetTotalRecordsCount(string tableName, string columnName, string searchParamS, Double? searchParamN);

        #region ExternalRating

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ExternalRating UpdateExternalRating(ExternalRating externalRating);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteExternalRating(int externalRatingId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ExternalRating GetExternalRating(int externalRatingId);

        [OperationContract]
        ExternalRating[] GetAllExternalRatings();

        #endregion

        #region HistoricalSectorRating

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        HistoricalSectorRating UpdateHistoricalSectorRating(HistoricalSectorRating historicalSectorRating);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteHistoricalSectorRating(int historicalSectorRatingId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        HistoricalSectorRating GetHistoricalSectorRating(int historicalSectorRatingId);

        [OperationContract]
        HistoricalSectorRating[] GetAllHistoricalSectorRatings();

        #endregion

        #region InternalRatingBased

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        InternalRatingBased UpdateInternalRatingBased(InternalRatingBased internalRatingBased);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteInternalRatingBased(int internalRatingBasedId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        InternalRatingBased GetInternalRatingBased(int internalRatingBasedId);

        [OperationContract]
        InternalRatingBased[] GetAllInternalRatingBaseds();

        #endregion

        #region MacroEconomic

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MacroEconomic UpdateMacroEconomic(MacroEconomic macroEconomic);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMacroEconomic(int macroEconomicId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MacroEconomic GetMacroEconomic(int macroEconomicId);

        [OperationContract]
        MacroEconomic[] GetAllMacroEconomics();


        #endregion

        #region RatingMapping

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        RatingMapping UpdateRatingMapping(RatingMapping ratingMapping);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteRatingMapping(int ratingMappingId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        RatingMapping GetRatingMapping(int ratingMappingId);

        [OperationContract]
        RatingMapping[] GetAllRatingMappings();

        [OperationContract]
        RatingMappingData[] GetRatingMappings();

        #endregion

        #region Transition

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Transition UpdateTransition(Transition transition);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteTransition(int transitionId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Transition GetTransition(int transitionId);

        [OperationContract]
        Transition[] GetAllTransitions();

        #endregion
                
        #region HistoricalClassification

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        HistoricalClassification UpdateHistoricalClassification(HistoricalClassification historicalClassification);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteHistoricalClassification(int historicalClassificationId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        HistoricalClassification GetHistoricalClassification(int historicalClassificationId);

        [OperationContract]
        HistoricalClassification[] GetAllHistoricalClassifications();

        #endregion

        #region MacroEconomicHistorical

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MacroEconomicHistorical UpdateMacroEconomicHistorical(MacroEconomicHistorical macroEconomicHistorical);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMacroEconomicHistorical(int macroEconomicHistoricalId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MacroEconomicHistorical GetMacroEconomicHistorical(int macroEconomicHistoricalId);

        [OperationContract]
        MacroEconomicHistoricalData[] GetAllMacroEconomicHistoricals();

        #endregion

        #region NotchDifference

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        NotchDifference UpdateNotchDifference(NotchDifference notchDifference);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteNotchDifference(int notchDifferenceId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        NotchDifference GetNotchDifference(int notchDifferenceId);

        [OperationContract]
        NotchDifference[] GetAllNotchDifferences();

        #endregion

        #region SetUp

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        SetUp UpdateSetUp(SetUp setUp);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSetUp(int setUpId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SetUp GetSetUp(int setUpId);

        [OperationContract]
        SetUp[] GetAllSetUps();

        #endregion

        #region HistoricalSectorialPD

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        HistoricalSectorialPD UpdateHistoricalSectorialPD(HistoricalSectorialPD historicalClassification);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteHistoricalSectorialPD(int historicalClassificationId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        HistoricalSectorialPD GetHistoricalSectorialPD(int historicalClassificationId);

        [OperationContract]
        HistoricalSectorialPD[] GetAllHistoricalSectorialPDs();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        string[] GetDistinctYear();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        string[] GetDistinctPeriod();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ComputeHistoricalSectorialPD(int computationType, int curYear, int curPeriod, int prevYear, int prevPeriod);

        #endregion

        #region HistoricalSectorialLGD

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        HistoricalSectorialLGD UpdateHistoricalSectorialLGD(HistoricalSectorialLGD historicalClassification);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteHistoricalSectorialLGD(int historicalClassificationId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        HistoricalSectorialLGD GetHistoricalSectorialLGD(int historicalClassificationId);

        [OperationContract]
        HistoricalSectorialLGD[] GetAllHistoricalSectorialLGDs();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        string[] GetDistinctLYear();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        string[] GetDistinctLPeriod();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ComputeHistoricalSectorialLGD(int computationType, int curYear, int curPeriod, int prevYear, int prevPeriod);

        #endregion

        //#region ComputedForcastedPDLGD

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //ComputedForcastedPDLGD UpdateComputedForcastedPDLGD(ComputedForcastedPDLGD computedForcastedPDLGD);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //void DeleteComputedForcastedPDLGD(int computedPDId);

        //[OperationContract]
        //[FaultContract(typeof(NotFoundException))]
        //ComputedForcastedPDLGD GetComputedForcastedPDLGD(int computedPDId);

        //[OperationContract]
        //ComputedForcastedPDLGD[] GetAllComputedForcastedPDLGDs();

        //#endregion

        #region SectorialRegressedPD

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        SectorialRegressedPD UpdateSectorialRegressedPD(SectorialRegressedPD sectorialRegressedPD);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSectorialRegressedPD(int sectorialRegressedPDId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SectorialRegressedPD GetSectorialRegressedPD(int sectorialRegressedPDId);

        [OperationContract]
        SectorialRegressedPD[] GetAllSectorialRegressedPDs();

        #endregion

        #region SectorialRegressedLGD

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        SectorialRegressedLGD UpdateSectorialRegressedLGD(SectorialRegressedLGD sectorialRegressedLGD);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSectorialRegressedLGD(int sectorialRegressedLGDId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SectorialRegressedLGD GetSectorialRegressedLGD(int sectorialRegressedLGDId);

        [OperationContract]
        SectorialRegressedLGD[] GetAllSectorialRegressedLGDs();

        #endregion

        #region MacroEconomicVariable

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MacroEconomicVariable UpdateMacroEconomicVariable(MacroEconomicVariable macroEconomicVariable);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMacroEconomicVariable(int macroEconomicVariableId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MacroEconomicVariable GetMacroEconomicVariable(int macroEconomicVariableId);

        [OperationContract]
        MacroEconomicVariable[] GetAllMacroEconomicVariables();


        #endregion

        #region SectorVariableMapping

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        SectorVariableMapping UpdateSectorVariableMapping(SectorVariableMapping sectorVariableMapping);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSectorVariableMapping(int sectorVariableMappingId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SectorVariableMapping GetSectorVariableMapping(int sectorVariableMappingId);

        [OperationContract]
        SectorVariableMappingData[] GetAllSectorVariableMappings();


        #endregion

        #region PitFormular

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        PitFormular UpdatePitFormular(PitFormular pitFormular);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeletePitFormular(int pitFormularId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        PitFormular GetPitFormular(int pitFormularId);

        [OperationContract]
        PitFormular[] GetAllPitFormulars();

        #endregion

        #region PortfolioExposure

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        PortfolioExposure UpdatePortfolioExposure(PortfolioExposure portfolioExposure);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeletePortfolioExposure(int portfolioId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        PortfolioExposure GetPortfolioExposure(int portfolioId);

        [OperationContract]
        PortfolioExposure[] GetAllPortfolioExposures();

        [OperationContract]
        string GetAllPortfolioExposuresChart();

        #endregion

        #region SectorialExposure

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        SectorialExposure UpdateSectorialExposure(SectorialExposure sectorExposure);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSectorialExposure(int sectorialExposureId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SectorialExposure GetSectorialExposure(int sectorialExposureId);

        [OperationContract]
        SectorialExposure[] GetAllSectorialExposures();
        [OperationContract]
        string GetAllSectorialExposuresChart();


        #endregion

        #region PiTPD

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        PiTPD UpdatePiTPD(PiTPD pitFormular);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeletePiTPD(int pitPdId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        PiTPD GetPiTPD(int pitPdId);

        [OperationContract]
        PiTPD[] GetAllPiTPDs();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void RegressPD();

        #endregion

        #region EclCalculationModel

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        EclCalculationModel UpdateEclCalculationModel(EclCalculationModel eclCalculationModel);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteEclCalculationModel(int eclCalculationModelId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        EclCalculationModel GetEclCalculationModel(int eclCalculationModelId);

        [OperationContract]
        EclCalculationModel[] GetAllEclCalculationModels();

        #endregion

        #region LoanBucketDistribution

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LoanBucketDistribution UpdateLoanBucketDistribution(LoanBucketDistribution loanBucketDistribution);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLoanBucketDistribution(int portfolioId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanBucketDistribution GetLoanBucketDistribution(int portfolioId);

        [OperationContract]
        LoanBucketDistribution[] GetAllLoanBucketDistributions();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void PDDistribution();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void PastDueDayDistribution();

        [OperationContract]
        LoanBucketDistribution[] GetLoanAssessments(string bucket);

        #endregion

        #region MacroeconomicVDisplay

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MacroeconomicVDisplay UpdateMacroeconomicVDisplay(MacroeconomicVDisplay macroeconomicVDisplay);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMacroeconomicVDisplay(int macroeconomicVDisplayId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MacroeconomicVDisplay GetMacroeconomicVDisplay(int macroeconomicVDisplayId);

        [OperationContract]
        MacroeconomicVDisplay[] GetAllMacroeconomicVDisplays();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        string[] GetDistinctFHYear(string vType);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MacroeconomicVDisplay[] GetMacroeconomicVDisplayByYear(int yr);


        #endregion

        #region LifeTimePDClassification

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LifeTimePDClassification UpdateLifeTimePDClassification(LifeTimePDClassification notchDifference);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLifeTimePDClassification(int notchDifferenceId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LifeTimePDClassification GetLifeTimePDClassification(int notchDifferenceId);

        [OperationContract]
        LifeTimePDClassification[] GetAllLifeTimePDClassifications();

        #endregion

        #region SummaryReport

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        SummaryReport UpdateSummaryReport(SummaryReport summaryReport);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSummaryReport(int summaryReportId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SummaryReport GetSummaryReport(int summaryReportId);

        [OperationContract]
        SummaryReport[] GetAllSummaryReports();

        [OperationContract]
        string GetAllSummaryReportsChart();

        #endregion

        #region FairValuationModel

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        FairValuationModel UpdateFairValuationModel(FairValuationModel fairValuationModel);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteFairValuationModel(int fairValuationModelId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        FairValuationModel GetFairValuationModel(int fairValuationModelId);

        [OperationContract]
        FairValuationModel[] GetAllFairValuationModels();

        #endregion

        #region IfrsEquityUnqouted

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsEquityUnqouted UpdateIfrsEquityUnqouted(IfrsEquityUnqouted ifrsEquityUnqouted);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsEquityUnqouted(int ifrsEquityUnqoutedId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsEquityUnqouted GetIfrsEquityUnqouted(int ifrsEquityUnqoutedId);

        [OperationContract]
        IfrsEquityUnqouted[] GetAllIfrsEquityUnqouteds();

        #endregion

        #region IfrsStocksPrimaryData

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsStocksPrimaryData UpdateIfrsStocksPrimaryData(IfrsStocksPrimaryData ifrsStocksPrimaryData);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsStocksPrimaryData(int ifrsStocksPrimaryDataId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsStocksPrimaryData GetIfrsStocksPrimaryData(int ifrsStocksPrimaryDataId);

        [OperationContract]
        IfrsStocksPrimaryData[] GetAllIfrsStocksPrimaryDatas();

        #endregion

        #region IfrsStocksMapping

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsStocksMapping UpdateIfrsStocksMapping(IfrsStocksMapping ifrsStocksMapping);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsStocksMapping(int ifrsStocksMappingId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsStocksMapping GetIfrsStocksMapping(int ifrsStocksMappingId);

        [OperationContract]
        IfrsStocksMappingData[] GetAllIfrsStocksMappings();

        #endregion

        #region Reconciliation

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Reconciliation UpdateReconciliation(Reconciliation reconciliation);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteReconciliation(int reconciliationId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Reconciliation GetReconciliation(int reconciliationId);

        [OperationContract]
        Reconciliation[] GetAllReconciliations();

        #endregion

        #region ForecastedMacroeconimcsSensitivity

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ForecastedMacroeconimcsSensitivity UpdateForecastedMacroeconimcsSensitivity(ForecastedMacroeconimcsSensitivity forecastedMacroeconimcsSensitivity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteForecastedMacroeconimcsSensitivity(int forecastedMacroeconimcsSensitivityId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ForecastedMacroeconimcsSensitivity GetForecastedMacroeconimcsSensitivity(int forecastedMacroeconimcsSensitivityId);

        [OperationContract]
        ForecastedMacroeconimcsSensitivityData[] GetAllForecastedMacroeconimcsSensitivitys();

        [OperationContract]
        void InsertSensitivityData(string microeconomic, int year, int types, float values);

        [OperationContract]
        void ComputeSensitivity();


        #endregion

        #region BucketExposure

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        BucketExposure UpdateBucketExposure(BucketExposure bucketExposure);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteBucketExposure(int bucketExposureId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BucketExposure GetBucketExposure(int bucketExposureId);

        [OperationContract]
        BucketExposure[] GetAllBucketExposures();

        [OperationContract]
        string GetAllBucketExposuresChart();

        #endregion

        #region ForecastedMacroeconimcsScenario

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ForecastedMacroeconimcsScenario UpdateForecastedMacroeconimcsScenario(ForecastedMacroeconimcsScenario forecastedMacroeconimcsScenario);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteForecastedMacroeconimcsScenario(int forecastedMacroeconimcsScenarioId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ForecastedMacroeconimcsScenario GetForecastedMacroeconimcsScenario(int forecastedMacroeconimcsScenarioId);

        [OperationContract]
        ForecastedMacroeconimcsScenarioData[] GetAllForecastedMacroeconimcsScenarios();

        [OperationContract]
        void InsertScenarioData(string sector, string microeconomic, int year, int types, float values);

        [OperationContract]
        void ComputeScenario();

        #endregion

        #region LoanSpreadScenario

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LoanSpreadScenario UpdateLoanSpreadScenario(LoanSpreadScenario loanSpreadScenario);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLoanSpreadScenario(int loanSpreadScenarioId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanSpreadScenario GetLoanSpreadScenario(int loanSpreadScenarioId);

        [OperationContract]
        LoanSpreadScenario[] GetAllLoanSpreadScenarios();


        //[OperationContract]
        //LoanSpreadScenario[] GetLoanAssessments(string bucket);

        //[OperationContract]
        //LoanSpreadScenario[] GetAllUnderPerformingLoans();
        //[OperationContract]
        //LoanSpreadScenario[] GetAllNonPerformingLoans();

        #endregion

        #region LoanSpreadSensitivity

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LoanSpreadSensitivity UpdateLoanSpreadSensitivity(LoanSpreadSensitivity loanSpreadSensitivity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLoanSpreadSensitivity(int loanSpreadSensitivityId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanSpreadSensitivity GetLoanSpreadSensitivity(int loanSpreadSensitivityId);

        [OperationContract]
        LoanSpreadSensitivity[] GetAllLoanSpreadSensitivitys();


        //[OperationContract]
        //LoanSpreadSensitivity[] GetLoanAssessments(string bucket);

        //[OperationContract]
        //LoanSpreadSensitivity[] GetAllUnderPerformingLoans();
        //[OperationContract]
        //LoanSpreadSensitivity[] GetAllNonPerformingLoans();

        #endregion

        #region UnquotedEquityFairvalueResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        UnquotedEquityFairvalueResult UpdateUnquotedEquityFairvalueResult(UnquotedEquityFairvalueResult unquotedEquityFairvalueResult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteUnquotedEquityFairvalueResult(int unquotedEquityFairvalueResultId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        UnquotedEquityFairvalueResult GetUnquotedEquityFairvalueResult(int unquotedEquityFairvalueResultId);

        [OperationContract]
        UnquotedEquityFairvalueResult[] GetAllUnquotedEquityFairvalueResults();

        #endregion

        #region PiTPDComparism

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        PiTPDComparism UpdatePiTPDComparism(PiTPDComparism pitFormular);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeletePiTPDComparism(int pitPdId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        PiTPDComparism GetPiTPDComparism(int pitPdId);

        [OperationContract]
        PiTPDComparism[] GetAllPiTPDComparisms();


        #endregion

        #region MarkovMatrix

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MarkovMatrix UpdateMarkovMatrix(MarkovMatrix markovMatrix);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMarkovMatrix(int markovMatrixId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MarkovMatrix GetMarkovMatrix(int markovMatrixId);

        [OperationContract]
        MarkovMatrix[] GetAllMarkovMatrixs();

        [OperationContract]
        MarkovMatrixData[] GetMarkovMatrixs();

        #endregion

        #region CCFModelling

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CCFModelling UpdateCCFModelling(CCFModelling ccfModelling);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCCFModelling(int pitPdId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CCFModelling GetCCFModelling(int pitPdId);

        [OperationContract]
        CCFModelling[] GetAllCCFModellings();


        #endregion

        #region ECLComparism

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ECLComparism UpdateECLComparism(ECLComparism eclComparism);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteECLComparism(int eclComparismId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ECLComparism GetECLComparism(int eclComparismId);

        [OperationContract]
        ECLComparism[] GetAllECLComparisms();

        #endregion

        #region ForeignEADExchangeRate

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ForeignEADExchangeRate UpdateForeignEADExchangeRate(ForeignEADExchangeRate foreignEADexchangeRate);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteForeignEADExchangeRate(int foreignEADExchangeRateId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ForeignEADExchangeRate GetForeignEADExchangeRate(int foreignEADExchangeRateId);

        [OperationContract]
        ForeignEADExchangeRate[] GetAllForeignEADExchangeRates();


        #endregion


        //Begin Victor Segment


        #region EuroBondSpread

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        EuroBondSpread UpdateEuroBondSpread(EuroBondSpread euroBondSpread);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteEuroBondSpread(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        EuroBondSpread GetEuroBondSpread(int Id);

        [OperationContract]
        EuroBondSpread[] GetAllEuroBondSpreads();

        #endregion

        #region LcBgEclComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LcBgEclComputationResult UpdateLcBgEclComputationResult(LcBgEclComputationResult lcBgEclComputationResult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLcBgEclComputationResult(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LcBgEclComputationResult GetLcBgEclComputationResult(int Id);

        [OperationContract]
        LcBgEclComputationResult[] GetAllLcBgEclComputationResults();

        #endregion

        #region PlacementEclComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        PlacementEclComputationResult UpdatePlacementEclComputationResult(PlacementEclComputationResult placementEclComputationResult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeletePlacementEclComputationResult(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        PlacementEclComputationResult GetPlacementEclComputationResult(int Id);

        [OperationContract]
        PlacementEclComputationResult[] GetAllPlacementEclComputationResults();

        #endregion

        #region BondEclComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        BondEclComputationResult UpdateBondEclComputationResult(BondEclComputationResult bondEclComputationResult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteBondEclComputationResult(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondEclComputationResult GetBondEclComputationResult(int Id);

        [OperationContract]
        BondEclComputationResult[] GetAllBondEclComputationResults();

        #endregion

        #region EclComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        EclComputationResult UpdateEclComputationResult(EclComputationResult eclComputationResult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteEclComputationResult(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        EclComputationResult GetEclComputationResult(int Id);

        [OperationContract]
        EclComputationResult[] GetAllEclComputationResults();

        [OperationContract]
        EclComputationResult[] GetAllEclComputationResultsByStage(int stage);

        #endregion

        #region LgdComputationResultPlacement

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LgdComputationResultPlacement UpdateLgdComputationResultPlacement(LgdComputationResultPlacement lgdComputationResultPlacement);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLgdComputationResultPlacement(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LgdComputationResultPlacement GetLgdComputationResultPlacement(int Id);

        [OperationContract]
        LgdComputationResultPlacement[] GetAllLgdComputationResultPlacements();

        #endregion

        #region PlacementComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        PlacementComputationResult UpdatePlacementComputationResult(PlacementComputationResult placementComputationResult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeletePlacementComputationResult(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        PlacementComputationResult GetPlacementComputationResult(int Id);

        [OperationContract]
        PlacementComputationResult[] GetAllPlacementComputationResults();

        #endregion

        #region LgdComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LgdComputationResult UpdateLgdComputationResult(LgdComputationResult lgdComputationResult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLgdComputationResult(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LgdComputationResult GetLgdComputationResult(int Id);

        [OperationContract]
        LgdComputationResult[] GetAllLgdComputationResults();

        #endregion

        #region MarginalPDDistributionPlacement

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MarginalPDDistributionPlacement UpdateMarginalPDDistributionPlacement(MarginalPDDistributionPlacement marginalPDDistributionPlacement);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMarginalPDDistributionPlacement(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MarginalPDDistributionPlacement GetMarginalPDDistributionPlacement(int Id);

        [OperationContract]
        MarginalPDDistributionPlacement[] GetAllMarginalPDDistributionPlacements();

        #endregion

        #region MarginalPDDistributionPlacement

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        BondMarginalPDDistribution UpdateBondMarginalPDDistribution(BondMarginalPDDistribution bondMarginalPDDistribution);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteBondMarginalPDDistribution(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondMarginalPDDistribution GetBondMarginalPDDistribution(int Id);

        [OperationContract]
        BondMarginalPDDistribution[] GetAllBondMarginalPDDistributions();

        #endregion

        #region BondMarginalPDDistribution

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MarginalPDDistribution UpdateMarginalPDDistribution(MarginalPDDistribution marginalPDDistribution);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMarginalPDDistribution(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MarginalPDDistribution GetMarginalPDDistribution(int Id);

        [OperationContract]
        MarginalPDDistribution[] GetAllMarginalPDDistributions();

        #endregion

        #region LocalBondSpread

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LocalBondSpread UpdateLocalBondSpread(LocalBondSpread localBondSpread);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLocalBondSpread(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LocalBondSpread GetLocalBondSpread(int Id);

        [OperationContract]
        LocalBondSpread[] GetAllLocalBondSpreads();

        #endregion

        #region TBillEclComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        TBillEclComputationResult UpdateTBillEclComputationResult(TBillEclComputationResult tBillEclComputationResult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteTBillEclComputationResult(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        TBillEclComputationResult GetTBillEclComputationResult(int Id);

        [OperationContract]
        TBillEclComputationResult[] GetAllTBillEclComputationResults();

        #endregion

        //End Victor Segment

        #region ComputedForcastedPDLGD

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ComputedForcastedPDLGD UpdateComputedForcastedPDLGD(ComputedForcastedPDLGD computedForcastedPDLGD);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteComputedForcastedPDLGD(int computedPDId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ComputedForcastedPDLGD GetComputedForcastedPDLGD(int computedPDId);

        [OperationContract]
        ComputedForcastedPDLGD[] GetAllComputedForcastedPDLGDs();

        [OperationContract]
        ComputedForcastedPDLGD[] GetListComputedForcastedPDLGDs();

        #endregion

        #region ComputedForcastedPDLGDForeign

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ComputedForcastedPDLGDForeign UpdateComputedForcastedPDLGDForeign(ComputedForcastedPDLGDForeign computedForcastedPDLGD);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteComputedForcastedPDLGDForeign(int computedPDId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ComputedForcastedPDLGDForeign GetComputedForcastedPDLGDForeign(int computedPDId);

        [OperationContract]
        ComputedForcastedPDLGDForeign[] GetAllComputedForcastedPDLGDForeigns();

        [OperationContract]
        ComputedForcastedPDLGDForeign[] GetListComputedForcastedPDLGDForeigns();

        #endregion

        #region MacroEconomicsNPL

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MacroEconomicsNPL UpdateMacroEconomicsNPL(MacroEconomicsNPL macroEconomicsNPL);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMacroEconomicsNPL(int macroeconomicnplId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MacroEconomicsNPL GetMacroEconomicsNPL(int macroeconomicnplId);

        [OperationContract]
        MacroEconomicsNPL[] GetAllMacroEconomicsNPLs();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MacroEconomicsNPL[] GetMacroEconomicsNPLByScenario(string scenario);


        #endregion

        #region MonthlyDiscountFactor

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MonthlyDiscountFactor UpdateMonthlyDiscountFactor(MonthlyDiscountFactor monthlyDiscountFactor);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMonthlyDiscountFactor(int MonthlyDiscountFactor_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MonthlyDiscountFactor GetMonthlyDiscountFactor(int MonthlyDiscountFactor_Id);

        [OperationContract]
        MonthlyDiscountFactor[] GetAllMonthlyDiscountFactors();

        [OperationContract]
        MonthlyDiscountFactor[] GetMonthlyDiscountFactorByRefNo(string RefNo);

        #endregion

        #region MonthlyDiscountFactorBond

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MonthlyDiscountFactorBond UpdateMonthlyDiscountFactorBond(MonthlyDiscountFactorBond monthlyDiscountFactorBond);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMonthlyDiscountFactorBond(int MonthlyDiscountFactorBond_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MonthlyDiscountFactorBond GetMonthlyDiscountFactorBond(int MonthlyDiscountFactorBond_Id);

        [OperationContract]
        MonthlyDiscountFactorBond[] GetAllMonthlyDiscountFactorBonds();

        [OperationContract]
        MonthlyDiscountFactorBond[] GetMonthlyDiscountFactorBondByRefNo(string RefNo);

        #endregion

        #region MonthlyDiscountFactorPlacement

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MonthlyDiscountFactorPlacement UpdateMonthlyDiscountFactorPlacement(MonthlyDiscountFactorPlacement monthlyDiscountFactorPlacement);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMonthlyDiscountFactorPlacement(int MonthlyDiscountFactorPlacement_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MonthlyDiscountFactorPlacement GetMonthlyDiscountFactorPlacement(int MonthlyDiscountFactorPlacement_Id);

        [OperationContract]
        MonthlyDiscountFactorPlacement[] GetAllMonthlyDiscountFactorPlacements();

        [OperationContract]
        MonthlyDiscountFactorPlacement[] GetMonthlyDiscountFactorPlacementByRefNo(string RefNo);

        #endregion

        #region IfrsPdSeriesByRating

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsPdSeriesByRating UpdateIfrsPdSeriesByRating(IfrsPdSeriesByRating IfrsPdSeriesByRating);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsPdSeriesByRating(int IfrsPdSeriesByRatingId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsPdSeriesByRating GetIfrsPdSeriesBySno(int Sno);

        [OperationContract]
        IfrsPdSeriesByRating[] GetAllIfrsPdSeriesByRatings();

        [OperationContract]
        string[] GetAllRatings();

        [OperationContract]
        IfrsPdSeriesByRating[] GetIfrsPdSeriesByRating(string code);

        #endregion

        #region IfrsRetailPdSeries

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsRetailPdSeries UpdateIfrsRetailPdSeries(IfrsRetailPdSeries IfrsRetailPdSeries);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsRetailPdSeries(int PdSeriesId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsRetailPdSeries GetIfrsRetailPdSeriesById(int PdSeriesId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsRetailPdSeries[] GetAvailableIfrsRetailPdSeries(QueryOptions queryOptions);

        #endregion

        #region IfrsLgdScenarioByInstrument

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsLgdScenarioByInstrument UpdateIfrsLgdScenarioByInstrument(IfrsLgdScenarioByInstrument IfrsLgdScenarioByInstrument);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsLgdScenarioByInstrument(int InstrumentId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsLgdScenarioByInstrument GetIfrsLgdScenarioByInstrumentId(int InstrumentId);

        [OperationContract]
        IfrsLgdScenarioByInstrument[] GetAllIfrsLgdScenarioByInstruments();

        [OperationContract]
        string[] GetAllInstruments();

        [OperationContract]
        IfrsLgdScenarioByInstrument[] GetIfrsLgdScenarioByInstrument(string type);

        #endregion

        #region MacroVarRecoveryRates

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MacroVarRecoveryRates UpdateMacroVarRecoveryRates(MacroVarRecoveryRates MacroVarRecoveryRates);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMacroVarRecoveryRates(int RecoveryRatesId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MacroVarRecoveryRates GetMacroVarRecoveryRatesById(int RecoveryRatesId);

        [OperationContract]
        MacroVarRecoveryRates[] GetAllMacroVarRecoveryRates();

        #endregion

        #region IfrsCorporateEcl

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsCorporateEcl UpdateIfrsCorporateEcl(IfrsCorporateEcl IfrsCorporateEcl);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsCorporateEcl(int IfrsCorporateEclId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsCorporateEcl GetIfrsCorporateEclById(int IfrsCorporateEclId);

        [OperationContract]
        IfrsCorporateEcl[] GetAllIfrsCorporateEcls();

        [OperationContract]
        IfrsCorporateEcl[] GetIfrsCorporateEclByRefNo(string refNo);

        #endregion

        #region InvestmentOthersECL

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        InvestmentOthersECL UpdateInvestmentOthersECL(InvestmentOthersECL sectorMapping);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteInvestmentOthersECL(int ecl_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        InvestmentOthersECL GetInvestmentOthersECL(int ecl_Id);

        [OperationContract]
        InvestmentOthersECL[] GetAllInvestmentOthersECLs();

        [OperationContract]
        InvestmentOthersECL[] GetInvestmentOthersECLByRefNo(string RefNo);

        #endregion

        #region IfrsSectorCCF

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsSectorCCF UpdateIfrsSectorCCF(IfrsSectorCCF IfrsSectorCCF);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsSectorCCF(int InstrumentId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsSectorCCF GetIfrsSectorCCFById(int SectorId);

        [OperationContract]
        IfrsSectorCCF[] GetAllIfrsSectorCCFs(string Type);

        [OperationContract]
        Sector[] GetAllSectorsForCCF();

        #endregion

        #region ProbabilityWeighted

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ProbabilityWeighted UpdateProbabilityWeighted(ProbabilityWeighted probabilityWeighted);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteProbabilityWeighted(int ProbabilityWeighted_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ProbabilityWeighted GetProbabilityWeighted(int ProbabilityWeighted_Id);

        [OperationContract]
        ProbabilityWeighted[] GetAllProbabilityWeighteds();

        [OperationContract]
        ProbabilityWeighted[] GetProbabilityWeightedByInstrumentType(string InstrumentType);

        #endregion

        #region MacrovariableEstimate

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MacrovariableEstimate UpdateMacrovariableEstimate(MacrovariableEstimate macrovariableEstimate);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMacrovariableEstimate(int MacrovariableEstimate_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MacrovariableEstimate GetMacrovariableEstimate(int MacrovariableEstimate_Id);

        [OperationContract]
        MacrovariableEstimate[] GetAllMacrovariableEstimates();

        [OperationContract]
        MacrovariableEstimate[] GetMacrovariableEstimateByCategory(string Category);

        #endregion

        #region SectorMapping

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        SectorMapping UpdateSectorMapping(SectorMapping sectorMapping);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSectorMapping(int SectorMapping_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SectorMapping GetSectorMapping(int SectorMapping_Id);

        [OperationContract]
        SectorMapping[] GetAllSectorMappings();

        //[OperationContract]
        //SectorMapping[] GetSectorMappingBySource(string Source);

        #endregion

        #region Sector

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Sector UpdateSector(Sector sector);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSector(int sectorId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Sector GetSector(int sectorId);

        [OperationContract]
        Sector[] GetAllSectors();

        [OperationContract]
        Sector[] GetSectorBySource(string Source);

        #endregion

        #region SandPRating

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        SandPRating UpdateSandPRating(SandPRating sandPRating);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSandPRating(int SandPRating_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SandPRating GetSandPRating(int SandPRating_Id);

        [OperationContract]
        SandPRating[] GetAllSandPRatings();

        #endregion

        #region HistoricalDefaultedAccounts

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        HistoricalDefaultedAccounts UpdateHistoricalDefaultedAccount(HistoricalDefaultedAccounts historicalDefaultedAccounts);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteHistoricalDefaultedAccount(int DefaultedAccountId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        HistoricalDefaultedAccounts GetHistoricalDefaultedAccount(int DefaultedAccountId);

        [OperationContract]
        HistoricalDefaultedAccounts[] GetAllHistoricalDefaultedAccounts();

        #endregion

        #region OffBalancesheetECL

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        OffBalancesheetECL UpdateOffBalancesheetECL(OffBalancesheetECL offBalancesheetECL);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteOffBalancesheetECL(int obe_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        OffBalancesheetECL GetOffBalancesheetECL(int obe_Id);

        [OperationContract]
        OffBalancesheetECL[] GetAllOffBalancesheetECLs();

        [OperationContract]
        OffBalancesheetECL[] GetOffBalancesheetECLBySearch(string SearchParam);

        #endregion

        #region ImpairmentResultRetail

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ImpairmentResultRetail UpdateImpairmentResultRetail(ImpairmentResultRetail impairmentResultRetail);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteImpairmentResultRetail(int Impairment_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ImpairmentResultRetail GetImpairmentResultRetail(int Impairment_Id);

        [OperationContract]
        ImpairmentResultRetail[] GetAllImpairmentResultRetails();

        [OperationContract]
        ImpairmentResultRetail[] GetImpairmentResultRetailBySearch(string SearchParam);

        #endregion

        #region ImpairmentResultOBE

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ImpairmentResultOBE UpdateImpairmentResultOBE(ImpairmentResultOBE impairmentResultOBE);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteImpairmentResultOBE(int Impairment_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ImpairmentResultOBE GetImpairmentResultOBE(int Impairment_Id);

        [OperationContract]
        ImpairmentResultOBE[] GetAllImpairmentResultOBEs();

        [OperationContract]
        ImpairmentResultOBE[] GetImpairmentResultOBEBySearch(string SearchParam);

        #endregion

        #region ImpairmentCorporate

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ImpairmentCorporate UpdateImpairmentCorporate(ImpairmentCorporate impairmentCorporate);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteImpairmentCorporate(int Corporate_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ImpairmentCorporate GetImpairmentCorporate(int Corporate_Id);

        [OperationContract]
        ImpairmentCorporate[] GetAllImpairmentCorporates();

        #endregion

        #region ImpairmentInvestment

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ImpairmentInvestment UpdateImpairmentInvestment(ImpairmentInvestment impairmentInvestment);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteImpairmentInvestment(int Investment_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ImpairmentInvestment GetImpairmentInvestment(int Investment_Id);

        [OperationContract]
        ImpairmentInvestment[] GetAllImpairmentInvestments();

        #endregion

        #region IfrsFinalRetailOutput

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsFinalRetailOutput UpdateIfrsFinalRetailOutput(IfrsFinalRetailOutput IfrsFinalRetailOutput);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsFinalRetailOutput(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsFinalRetailOutput GetIfrsFinalRetailOutput(int Id);

        [OperationContract]
        IfrsFinalRetailOutput[] GetAllIfrsFinalRetailOutput();

        [OperationContract]
        IfrsFinalRetailOutput[] GetIfrsFinalRetailOutputByAccountNo(string accountNo);

        #endregion

        #region IfrsCustomerPD

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsCustomerPD UpdateIfrsCustomerPD(IfrsCustomerPD IfrsCustomerPD);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsCustomerPD(int CustomerPDId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsCustomerPD GetIfrsCustomerPD(int CustomerPDId);

        [OperationContract]
        IfrsCustomerPD[] GetAllIfrsCustomerPDs();

        [OperationContract]
        string[] GetAllCustomerRatings();

        [OperationContract]
        IfrsCustomerPD[] GetIfrsCustomerPDByRating(string rating);

        #endregion

        #region IfrsCorporatePdSeries

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsCorporatePdSeries UpdateIfrsCorporatePdSeries(IfrsCorporatePdSeries IfrsCorporatePdSeries);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsCorporatePdSeries(int PdSeriesId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsCorporatePdSeries GetIfrsCorporatePdSeriesById(int Sno);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsCorporatePdSeries[] GetAvailableIfrsCorporatePdSeries(QueryOptions queryOptions);

        [OperationContract]
        IfrsCorporatePdSeries[] GetAllIfrsCorporatePdSeries();

        //[OperationContract]
        //Stream GetExportIfrsCorporatePdSeries();

        #endregion

        #region ECLInputRetail

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ECLInputRetail UpdatEclInputRetail(ECLInputRetail eclInputRetail);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteEclInputRetail(int eclInputRetailId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ECLInputRetail GetEclInputRetail(int eclInputRetailId);

        [OperationContract]
        ECLInputRetail[] GetAllEclInputRetails();

        [OperationContract]
        ECLInputRetail[] GetAllEclInputRetailsByRefno(string refNo);
        #endregion

        #region StaffLoansComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        StaffLoansComputationResult UpdateStaffLoansComputationResult(StaffLoansComputationResult staffLoansComputationResult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteStaffLoansComputationResult(int StaffLoan_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        StaffLoansComputationResult GetStaffLoansComputationResult(int StaffLoan_Id);

        [OperationContract]
        StaffLoansComputationResult[] GetAllStaffLoansComputationResults();

        [OperationContract]
        StaffLoansComputationResult[] GetStaffLoansComputationResultBySearch(string SearchParam);

        #endregion

        #region CollateralInput

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CollateralInput UpdateCollateralInput(CollateralInput collateralInput);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCollateralInput(int Collateral_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CollateralInput GetCollateralInput(int Collateral_Id);

        [OperationContract]
        CollateralInput[] GetAllCollateralInputs();

        #endregion

        #region Assumption

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Assumption UpdateAssumption(Assumption assumption);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteAssumption(int InstrumentID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Assumption GetAssumption(int InstrumentID);

        [OperationContract]
        Assumption[] GetAllAssumptions();

        #endregion


        #region MonthlyObeEadSTRLB

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MonthlyObeEadSTRLB UpdateMonthlyObeEadSTRLB(MonthlyObeEadSTRLB monthlyobeeadstrlb);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMonthlyObeEadSTRLB(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MonthlyObeEadSTRLB GetMonthlyObeEadSTRLB(int ID);

        [OperationContract]
        MonthlyObeEadSTRLB[] GetAllMonthlyObeEadSTRLBs();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MonthlyObeEadSTRLB[] GetMonthlyObeEadSTRLBBySearch(string searchParam);

        [OperationContract]
        MonthlyObeEadSTRLB[] GetMonthlyObeEadSTRLBs(int defaultCount);

        #endregion


        #region BondsECLComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        BondsECLComputationResult UpdateBondsECLComputationResult(BondsECLComputationResult bondseclcomputationresult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteBondsECLComputationResult(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondsECLComputationResult GetBondsECLComputationResult(int ID);

        [OperationContract]
        BondsECLComputationResult[] GetAllBondsECLComputationResults();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondsECLComputationResult[] GetBondsECLComputationResultBySearch(string searchParam);

        [OperationContract]
        BondsECLComputationResult[] GetBondsECLComputationResults(int defaultCount);

        #endregion




        #region CollateralGrowthRate

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CollateralGrowthRate UpdateCollateralGrowthRate(CollateralGrowthRate collateralgrowthrate);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCollateralGrowthRate(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CollateralGrowthRate GetCollateralGrowthRate(int ID);

        [OperationContract]
        CollateralGrowthRate[] GetAllCollateralGrowthRates();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CollateralGrowthRate[] GetCollateralGrowthRateBySearch(string searchParam);

        [OperationContract]
        CollateralGrowthRate[] GetCollateralGrowthRates(int defaultCount);

        #endregion

        #region CummulativeDefaultAmt

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CummulativeDefaultAmt UpdateCummulativeDefaultAmt(CummulativeDefaultAmt cummulativedefaultamt);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCummulativeDefaultAmt(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CummulativeDefaultAmt GetCummulativeDefaultAmt(int ID);

        [OperationContract]
        CummulativeDefaultAmt[] GetAllCummulativeDefaultAmts();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CummulativeDefaultAmt[] GetCummulativeDefaultAmtBySearch(string searchParam);

        [OperationContract]
        CummulativeDefaultAmt[] GetCummulativeDefaultAmts(int defaultCount);

        #endregion

        #region CummulativeLifetimePd

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CummulativeLifetimePd UpdateCummulativeLifetimePd(CummulativeLifetimePd cummulativelifetimepd);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCummulativeLifetimePd(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CummulativeLifetimePd GetCummulativeLifetimePd(int ID);

        [OperationContract]
        CummulativeLifetimePd[] GetAllCummulativeLifetimePds();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CummulativeLifetimePd[] GetCummulativeLifetimePdBySearch(string searchParam);

        [OperationContract]
        CummulativeLifetimePd[] GetCummulativeLifetimePds(int defaultCount);

        #endregion

        #region CollateralRecAmtStaging

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CollateralRecAmtStaging UpdateCollateralRecAmtStaging(CollateralRecAmtStaging collateralrecamtstaging);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCollateralRecAmtStaging(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CollateralRecAmtStaging GetCollateralRecAmtStaging(int ID);

        [OperationContract]
        CollateralRecAmtStaging[] GetAllCollateralRecAmtStagings();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CollateralRecAmtStaging[] GetCollateralRecAmtStagingBySearch(string searchParam);

        [OperationContract]
        CollateralRecAmtStaging[] GetCollateralRecAmtStagings(int defaultCount);

        #endregion
  

        #region HistoricalDefaultFreq

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        HistoricalDefaultFreq UpdateHistoricalDefaultFreq(HistoricalDefaultFreq historicaldefaultfreq);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteHistoricalDefaultFreq(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        HistoricalDefaultFreq GetHistoricalDefaultFreq(int ID);

        [OperationContract]
        HistoricalDefaultFreq[] GetAllHistoricalDefaultFreqs();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        HistoricalDefaultFreq[] GetHistoricalDefaultFreqBySearch(string searchParam);

        [OperationContract]
        HistoricalDefaultFreq[] GetHistoricalDefaultFreqs(int defaultCount);

        #endregion

        #region CummulativePD

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CummulativePD UpdateCummulativePD(CummulativePD cummulativepd);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCummulativePD(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CummulativePD GetCummulativePD(int ID);

        [OperationContract]
        CummulativePD[] GetAllCummulativePDs();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CummulativePD[] GetCummulativePDBySearch(string searchParam);

        [OperationContract]
        CummulativePD[] GetCummulativePDs(int defaultCount);

        #endregion


        ///////////////////////////////////////////////////New Entries..

        #region ConsolidatedLoans

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ConsolidatedLoans UpdateConsolidatedLoans(ConsolidatedLoans consolidatedloans);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteConsolidatedLoans(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ConsolidatedLoans GetConsolidatedLoans(int ID);

        [OperationContract]
        ConsolidatedLoans[] GetAllConsolidatedLoanss();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ConsolidatedLoans[] GetConsolidatedLoansBySearch(string searchParam);

        [OperationContract]
        ConsolidatedLoans[] GetConsolidatedLoanss(int defaultCount);

        #endregion  

        ///////////////////////////////////////////////////New Entries..   



        #region InvestmentMarginalPd

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        InvestmentMarginalPd UpdateInvestmentMarginalPd(InvestmentMarginalPd investmentmarginalpd);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteInvestmentMarginalPd(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        InvestmentMarginalPd GetInvestmentMarginalPd(int ID);

        [OperationContract]
        InvestmentMarginalPd[] GetAllInvestmentMarginalPds();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        InvestmentMarginalPd[] GetInvestmentMarginalPdBySearch(string searchParam);

        [OperationContract]
        InvestmentMarginalPd[] GetInvestmentMarginalPds(int defaultCount);

        #endregion

        #region MarginalCCFPivotSTRLB

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MarginalCCFPivotSTRLB UpdateMarginalCCFPivotSTRLB(MarginalCCFPivotSTRLB marginalccfpivotstrlb);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMarginalCCFPivotSTRLB(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MarginalCCFPivotSTRLB GetMarginalCCFPivotSTRLB(int ID);

        [OperationContract]
        MarginalCCFPivotSTRLB[] GetAllMarginalCCFPivotSTRLBs();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MarginalCCFPivotSTRLB[] GetMarginalCCFPivotSTRLBBySearch(string searchParam);

        [OperationContract]
        MarginalCCFPivotSTRLB[] GetMarginalCCFPivotSTRLBs(int defaultCount);

        #endregion  

        #region CcfAnalysisOverDraftSTRLB

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CcfAnalysisOverDraftSTRLB UpdateCcfAnalysisOverDraftSTRLB(CcfAnalysisOverDraftSTRLB ccfanalysisoverdraftstrlb);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCcfAnalysisOverDraftSTRLB(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CcfAnalysisOverDraftSTRLB GetCcfAnalysisOverDraftSTRLB(int ID);

        [OperationContract]
        CcfAnalysisOverDraftSTRLB[] GetAllCcfAnalysisOverDraftSTRLBs();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CcfAnalysisOverDraftSTRLB[] GetCcfAnalysisOverDraftSTRLBBySearch(string searchParam);

        [OperationContract]
        CcfAnalysisOverDraftSTRLB[] GetCcfAnalysisOverDraftSTRLBs(int defaultCount);

        #endregion



        #region LoanECLResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LoanECLResult UpdateLoanECLResult(LoanECLResult loaneclresult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLoanECLResult(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanECLResult GetLoanECLResult(int ID);

        [OperationContract]
        LoanECLResult[] GetAllLoanECLResults();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanECLResult[] GetLoanECLResultBySearch(string searchParam);

        [OperationContract]
        LoanECLResult[] GetLoanECLResults(int defaultCount);

        #endregion

        #region ObeECLResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ObeECLResult UpdateObeECLResult(ObeECLResult obeeclresult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteObeECLResult(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ObeECLResult GetObeECLResult(int ID);

        [OperationContract]
        ObeECLResult[] GetAllObeECLResults();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ObeECLResult[] GetObeECLResultBySearch(string searchParam);

        [OperationContract]
        ObeECLResult[] GetObeECLResults(int defaultCount);

        #endregion

        #region BondsECLResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        BondsECLResult UpdateBondsECLResult(BondsECLResult bondseclresult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteBondsECLResult(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondsECLResult GetBondsECLResult(int ID);

        [OperationContract]
        BondsECLResult[] GetAllBondsECLResults();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondsECLResult[] GetBondsECLResultBySearch(string searchParam);

        [OperationContract]
        BondsECLResult[] GetBondsECLResults(int defaultCount);

        #endregion

        #region OdECLResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        OdECLResult UpdateOdECLResult(OdECLResult loaneclresult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteOdECLResult(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        OdECLResult GetOdECLResult(int ID);

        [OperationContract]
        OdECLResult[] GetAllOdECLResults();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        OdECLResult[] GetOdECLResultBySearch(string searchParam);

        [OperationContract]
        OdECLResult[] GetOdECLResults(int defaultCount);

        #endregion


        #region SPCumulativePD

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        SPCumulativePD UpdateSPCumulativePD(SPCumulativePD sPCumulativePD);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSPCumulativePD(int SPCumulative_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SPCumulativePD GetSPCumulativePD(int SPCumulative_Id);

        [OperationContract]
        SPCumulativePD[] GetAllSPCumulativePDs();

        #endregion

        #region LoanCommitmentComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LoanCommitmentComputationResult UpdateLoanCommitmentComputationResult(LoanCommitmentComputationResult loanCommitmentComputationResult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLoanCommitmentComputationResult(int LoanCommitmentComputationResult_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanCommitmentComputationResult GetLoanCommitmentComputationResult(int LoanCommitmentComputationResult_Id);

        [OperationContract]
        LoanCommitmentComputationResult[] GetAllLoanCommitmentComputationResults();

        #endregion

        #region LgdInputFactor

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LgdInputFactor UpdateLgdInputFactor(LgdInputFactor lgdInputFactor);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLgdInputFactor(int LgdInputFactorId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LgdInputFactor GetLgdInputFactor(int LgdInputFactorId);

        [OperationContract]
        LgdInputFactor[] GetAllLgdInputFactors();

        #endregion

        #region RegressionOutput

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        RegressionOutput UpdateRegressionOutput(RegressionOutput regressionOutput);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteRegressionOutput(int RegressionOutputId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        RegressionOutput GetRegressionOutput(int RegressionOutputId);

        [OperationContract]
        RegressionOutput[] GetAllRegressionOutputs();

        #endregion

        #region MacroeconomicsVariableScenario

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MacroeconomicsVariableScenario UpdateMacroeconomicsVariableScenario(MacroeconomicsVariableScenario macroeconomicsVariableScenario);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMacroeconomicsVariableScenario(int MacroeconomicsId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MacroeconomicsVariableScenario GetMacroeconomicsVariableScenario(int MacroeconomicsId);

        [OperationContract]
        MacroeconomicsVariableScenario[] GetAllMacroeconomicsVariableScenarios();

        [OperationContract]
        MacroeconomicsVariableScenario[] GetMacroeconomicsVariableScenariosByFlag(int flag);

        #endregion




        ///////////////////////////////////////////////////New Entries..  
        ///////////////////////////////////////////////////New Entries.. 

        #region ScbDataInfo

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbDataInfo UpdateScbDataInfo(ScbDataInfo scbdatainfo);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbDataInfo(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbDataInfo GetScbDataInfo(int ID);

        [OperationContract]
        ScbDataInfo[] GetAllScbDataInfos();

        [OperationContract]
        double getScbDataInfoBalance();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbDataInfo[] GetScbDataInfoBySearch(string searchParam);

        [OperationContract]
        ScbDataInfo[] GetScbDataInfos(int defaultCount);

        [OperationContract]
        string[] GetScbOptionsByFilter(string filterParam);

        [OperationContract]
        void updateFilteredScbDataInfo(string colname, string colType, string colnewval);

        [OperationContract]
        ScbDataInfo[] ExportScbDataInfo(int defaultCount, string path);
        #endregion



        #region CRLastCreditDate

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CRLastCreditDate UpdateCRLastCreditDate(CRLastCreditDate crlastcreditdate);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCRLastCreditDate(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CRLastCreditDate GetCRLastCreditDate(int ID);

        [OperationContract]
        CRLastCreditDate[] GetAllCRLastCreditDates();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CRLastCreditDate[] GetCRLastCreditDateBySearch(string searchParam);

        [OperationContract]
        CRLastCreditDate[] GetCRLastCreditDates(int defaultCount);

        #endregion  

        #region ScbCreditSanction

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbCreditSanction UpdateScbCreditSanction(ScbCreditSanction scbcreditsanction);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbCreditSanction(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbCreditSanction GetScbCreditSanction(int ID);

        [OperationContract]
        ScbCreditSanction[] GetAllScbCreditSanctions();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbCreditSanction[] GetScbCreditSanctionBySearch(string searchParam);

        [OperationContract]
        ScbCreditSanction[] GetScbCreditSanctions(int defaultCount);

        #endregion  

        #region CreditCollateralMgt

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CreditCollateralMgt UpdateCreditCollateralMgt(CreditCollateralMgt creditcollateralmgt);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCreditCollateralMgt(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CreditCollateralMgt GetCreditCollateralMgt(int ID);

        [OperationContract]
        CreditCollateralMgt[] GetAllCreditCollateralMgts();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        CreditCollateralMgt[] GetCreditCollateralMgtBySearch(string searchParam);

        [OperationContract]
        CreditCollateralMgt[] GetCreditCollateralMgts(int defaultCount);

        #endregion  

        #region ScbCustomerInfo

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbCustomerInfo UpdateScbCustomerInfo(ScbCustomerInfo scbcustomerinfo);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbCustomerInfo(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbCustomerInfo GetScbCustomerInfo(int ID);

        [OperationContract]
        ScbCustomerInfo[] GetAllScbCustomerInfos();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbCustomerInfo[] GetScbCustomerInfoBySearch(string searchParam);

        [OperationContract]
        ScbCustomerInfo[] GetScbCustomerInfos(int defaultCount);

        #endregion


        //new services.......................

        #region ScbCollateralMgt

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbCollateralMgt UpdateScbCollateralMgt(ScbCollateralMgt scbcollateralmgt);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbCollateralMgt(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbCollateralMgt GetScbCollateralMgt(int ID);

        [OperationContract]
        ScbCollateralMgt[] GetAllScbCollateralMgts();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbCollateralMgt[] GetScbCollateralMgtBySearch(string searchParam);

        [OperationContract]
        ScbCollateralMgt[] GetScbCollateralMgts(int defaultCount);

        #endregion  

        #region ScbBankClassification

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbBankClassification UpdateScbBankClassification(ScbBankClassification scbbankclassification);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbBankClassification(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbBankClassification GetScbBankClassification(int ID);

        [OperationContract]
        ScbBankClassification[] GetAllScbBankClassifications();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbBankClassification[] GetScbBankClassificationBySearch(string searchParam);

        [OperationContract]
        ScbBankClassification[] GetScbBankClassifications(int defaultCount);

        #endregion  


        //...//

        #region ScbProduct

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbProduct UpdateScbProduct(ScbProduct scbproduct);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbProduct(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbProduct GetScbProduct(int ID);

        [OperationContract]
        ScbProduct[] GetAllScbProducts();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbProduct[] GetScbProductBySearch(string searchParam);

        [OperationContract]
        ScbProduct[] GetScbProducts(int defaultCount);

        #endregion  

        #region ScbException

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbException UpdateScbException(ScbException crlastcreditdate);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbException(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbException GetScbException(int ID);

        [OperationContract]
        ScbException[] GetAllScbExceptions();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbException[] GetScbExceptionBySearch(string searchParam);

        [OperationContract]
        ScbException[] GetScbExceptions(int defaultCount);

        [OperationContract]
        string[] GetDistinctScbExpMessages();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbException[] getExceptionMessageByFilter(string filterparam);

        [OperationContract]
        ScbException[] RevertExceptionById(string ID);

        [OperationContract]
        ScbException[] RevertAllExceptionObjs();

        #endregion  


        #region ScbGLBalance

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbGLBalance UpdateScbGLBalance(ScbGLBalance scbglbalance);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbGLBalance(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbGLBalance GetScbGLBalance(int ID);

        [OperationContract]
        ScbGLBalance[] GetAllScbGLBalances();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbGLBalance[] GetScbGLBalanceBySearch(string searchParam);

        [OperationContract]
        ScbGLBalance[] GetScbGLBalances(int defaultCount);

        #endregion  


        ///////////////////////////////////////////////////New Entries.. 
        ///////////////////////////////////////////////////New Entries.. 

        #region ScbDataTBValidated

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbDataTBValidated UpdateScbDataTBValidated(ScbDataTBValidated scbdatatbvalidated);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbDataTBValidated(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbDataTBValidated GetScbDataTBValidated(int ID);

        [OperationContract]
        ScbDataTBValidated[] GetAllScbDataTBValidateds();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbDataTBValidated[] GetScbDataTBValidatedBySearch(string searchParam);

        [OperationContract]
        double getScbDataTBValidatedBalance();

        [OperationContract]
        ScbDataTBValidated[] GetScbDataTBValidateds(int defaultCount);

        [OperationContract]
        string[] GetScbDataTBOptionsByFilter(string filterParam);

        //[OperationContract]
        //void updateFilteredScbDataTBValidated(string colname, string colType, string colnewval);

        [OperationContract]
        ScbDataTBValidated[] GetScbDataTBValidatedsByRange(double minValue, double maxValue);

        [OperationContract]
        ScbDataTBValidated[] ExportScbDataTBValidated(int defaultCount, string path);

        #endregion


        ///////////////////////////////////////////////////New Entries.. 
        ///////////////////////////////////////////////////New Entries.. 

        #region PfBalanceValidation

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        PfBalanceValidation UpdatePfBalanceValidation(PfBalanceValidation scbglbalance);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeletePfBalanceValidation(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        PfBalanceValidation GetPfBalanceValidation(int ID);

        [OperationContract]
        PfBalanceValidation[] GetAllPfBalanceValidations();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        PfBalanceValidation[] GetPfBalanceValidationBySearch(string searchParam);

        [OperationContract]
        string[] GetDistinctScbPfBalances();

        [OperationContract]
        string[] GetDistinctScbGLCodes();

        [OperationContract]
        PfBalanceValidation[] GetPfBalanceValidations(int defaultCount);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        PfBalanceValidation[] GetPfBalanceValidationList(string code, string name);


        #endregion  

        #region SCBThrownOutPSFAcc

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        SCBThrownOutPSFAcc UpdateSCBThrownOutPSFAcc(SCBThrownOutPSFAcc scbglbalance);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteSCBThrownOutPSFAcc(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SCBThrownOutPSFAcc GetSCBThrownOutPSFAcc(int ID);

        [OperationContract]
        SCBThrownOutPSFAcc[] GetAllSCBThrownOutPSFAccs();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        SCBThrownOutPSFAcc[] GetSCBThrownOutPSFAccBySearch(string searchParam);

        [OperationContract]
        SCBThrownOutPSFAcc[] GetSCBThrownOutPSFAccs(int defaultCount);

        #endregion  

        #region ScbLimitDef

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbLimitDef UpdateScbLimitDef(ScbLimitDef crlastcreditdate);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbLimitDef(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbLimitDef GetScbLimitDef(int ID);

        [OperationContract]
        ScbLimitDef[] GetAllScbLimitDefs();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbLimitDef[] GetScbLimitDefBySearch(string searchParam);

        [OperationContract]
        ScbLimitDef[] GetScbLimitDefs(int defaultCount);

        #endregion  

        #region ScbBusinessSegment

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ScbBusinessSegment UpdateScbBusinessSegment(ScbBusinessSegment scbglbalance);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteScbBusinessSegment(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbBusinessSegment GetScbBusinessSegment(int ID);

        [OperationContract]
        ScbBusinessSegment[] GetAllScbBusinessSegments();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ScbBusinessSegment[] GetScbBusinessSegmentBySearch(string searchParam);

        [OperationContract]
        ScbBusinessSegment[] GetScbBusinessSegments(int defaultCount);

        #endregion  

    }
}
