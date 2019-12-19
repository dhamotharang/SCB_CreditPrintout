using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Fintrak.Shared.Common.Contracts;
using Fintrak.Shared.Common.Exceptions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;
using Fintrak.Presentation.WebClient.Models;

namespace Fintrak.Business.IFRS.Contracts
{
    [ServiceContract]
    public interface IExtractedDataService : IServiceContract
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void RegisterModule();
     
        #region IFRSBonds

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IFRSBonds UpdateIFRSBonds(IFRSBonds IFRSBonds);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIFRSBonds(int bondId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IFRSBonds GetIFRSBonds(int bondId);

        [OperationContract]
        IFRSBonds[] GetAllIFRSBonds();

        [OperationContract]
        IFRSBonds[] GetBondsByClassification(string classification);

        [OperationContract]
        IFRSBonds[] GetbondsByMaturityDate(DateTime matureDate);

        [OperationContract]
        void UpdatebondsByMaturityDate(DateTime matureDate, decimal cmprice);
    

        #endregion

        #region IFRSTbills

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IFRSTbills UpdateIFRSTbills(IFRSTbills IFRSTbills);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIFRSTbills(int tbillId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IFRSTbills GetIFRSTbills(int tbillId);

        [OperationContract]
        IFRSTbills[] GetAllIFRSTbills();

        [OperationContract]
        IFRSTbills[] GetTbillsByClassification(string classification, int type);
        [OperationContract]
        IFRSTbills[] GetTbillsByMaturityDate(DateTime matureDate, int type);

        [OperationContract]
        void UpdateTbillsByMaturityDate(DateTime matureDate, decimal cmprice);

        [OperationContract]
        IFRSTbills[] GetListByType(int Type);

        #endregion        

        #region LoanPry

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LoanPry UpdateLoanPry(LoanPry loanPry);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLoanPry(int pryId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanPry GetLoanPry(int pryId);

        [OperationContract]
        LoanPry[] GetAllLoanPry();

        [OperationContract]
        LoanPry[] GetLoanPryByScheduleType(string schType);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanPry[] GetPryLoanBySearch(string searchParam);

        [OperationContract]
        LoanPry[] GetPryLoans(int defaultCount);



        #endregion

        #region RawRawLoanDetails

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        RawLoanDetails UpdateRawLoanDetails(RawLoanDetails loanDetails);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteRawLoanDetails(int loanDetailId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        RawLoanDetails GetRawLoanDetails(int loanDetailId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        RawLoanDetails[] GetAllRawLoanDetails();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        RawLoanDetails[] GetAllLoanDetailsBySearch(string searchParam);

        [OperationContract]
        void UpdateLoanClassNotch(string refNo, string rating, int stage, string notes);

        [OperationContract]
        void DeleteLoanDetailsNotch(string refNo);

        [OperationContract]
        CollateralRecov[] ComputeRecovAmt(string refNo, string collateralType, double collateralValue);

        [OperationContract]
        RawLoanDetails[] GetAllLoanDetails(int defaultCount);

        #endregion

        #region IntegralFee

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IntegralFee UpdateIntegralFee(IntegralFee integralFee);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIntegralFee(int integralFeeId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IntegralFee GetIntegralFee(int integralFeeId);

        [OperationContract]
        IntegralFee[] GetAllIntegralFee();

        #endregion

        #region IfrsCustomer

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsCustomer UpdateIfrsCustomer(IfrsCustomer ifrsCustomer);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsCustomer(int customerId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsCustomer GetIfrsCustomer(int customerId);

        [OperationContract]
        IfrsCustomer[] GetAllIfrsCustomer();

        [OperationContract]
        IfrsCustomer[] GetIfrsCustomerByRating(string rating);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsCustomer[] GetCustomerInfoBySearch(string searchParam);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsCustomer[] GetCustomers(int defaultCount);
        #endregion


        /**************************************************************************/

        #region OdLgdComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        OdLgdComputationResult UpdateOdLgdComputationResult(OdLgdComputationResult odlgdcomputationresult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteOdLgdComputationResult(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        OdLgdComputationResult GetOdLgdComputationResult(int ID);

        [OperationContract]
        OdLgdComputationResult[] GetAllOdLgdComputationResult();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        OdLgdComputationResult[] GetOdLgdComputationResultBySearch(string searchParam);

        [OperationContract]
        OdLgdComputationResult[] GetOdLgdComputationResults(int defaultCount);

        #endregion

        /**************************************************************************/



        #region LoansECLComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LoansECLComputationResult UpdateLoansECLComputationResult(LoansECLComputationResult loanseclcomputationresult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLoansECLComputationResult(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoansECLComputationResult GetLoansECLComputationResult(int ID);

        [OperationContract]
        LoansECLComputationResult[] GetAllLoansECLComputationResult();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoansECLComputationResult[] GetLoansECLComputationResultBySearch(string searchParam);

        [OperationContract]
        LoansECLComputationResult[] GetLoansECLComputationResults(int defaultCount);

        #endregion

        #region MarginalPddSTRLB

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MarginalPddSTRLB UpdateMarginalPddSTRLB(MarginalPddSTRLB marginalpddstrlb);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMarginalPddSTRLB(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MarginalPddSTRLB GetMarginalPddSTRLB(int ID);

        [OperationContract]
        MarginalPddSTRLB[] GetAllMarginalPddSTRLB();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MarginalPddSTRLB[] GetMarginalPddSTRLBBySearch(string searchParam);

        [OperationContract]
        MarginalPddSTRLB[] GetMarginalPddSTRLBs(int defaultCount);

        #endregion

        #region ODEclComputationResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ODEclComputationResult UpdateODEclComputationResult(ODEclComputationResult odeclcomputationresult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteODEclComputationResult(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ODEclComputationResult GetODEclComputationResult(int ID);

        [OperationContract]
        ODEclComputationResult[] GetAllODEclComputationResult();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ODEclComputationResult[] GetODEclComputationResultBySearch(string searchParam);

        [OperationContract]
        ODEclComputationResult[] GetODEclComputationResults(int defaultCount);

        #endregion

        #region MarginalPdObeDistr

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        MarginalPdObeDistr UpdateMarginalPdObeDistr(MarginalPdObeDistr marginalpdobedistr);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMarginalPdObeDistr(int ID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MarginalPdObeDistr GetMarginalPdObeDistr(int ID);

        [OperationContract]
        MarginalPdObeDistr[] GetAllMarginalPdObeDistr();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        MarginalPdObeDistr[] GetMarginalPdObeDistrBySearch(string searchParam);

        [OperationContract]
        MarginalPdObeDistr[] GetMarginalPdObeDistrs(int defaultCount);

        #endregion

        #region LGDComptResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LGDComptResult UpdateLGDComptResult(LGDComptResult lgdcomptresult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLGDComptResult(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LGDComptResult GetLGDComptResult(int Id);

        [OperationContract]
        LGDComptResult[] GetAllLGDComptResult();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LGDComptResult[] GetLGDComptResultBySearch(string searchParam);

        [OperationContract]
        LGDComptResult[] GetLGDComptResults(int defaultCount);

        #endregion

        #region ObeLGDComptResult

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ObeLGDComptResult UpdateObeLGDComptResult(ObeLGDComptResult obelgdcomptresult);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteObeLGDComptResult(int Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ObeLGDComptResult GetObeLGDComptResult(int Id);

        [OperationContract]
        ObeLGDComptResult[] GetAllObeLGDComptResult();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        ObeLGDComptResult[] GetObeLGDComptResultBySearch(string searchParam);

        [OperationContract]
        ObeLGDComptResult[] GetObeLGDComptResults(int defaultCount);

        #endregion



        /**************************************************************************/


        #region IfrsCustomerAccount

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IfrsCustomerAccount UpdateIfrsCustomerAccount(IfrsCustomerAccount ifrsCustomerAccount);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteIfrsCustomerAccount(int custAccountId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IfrsCustomerAccount GetIfrsCustomerAccount(int custAccountId);

        [OperationContract]
        IfrsCustomerAccount[] GetAllIfrsCustomerAccount();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        string[] GetDistinctSector();

        #endregion

        #region UnMappedProducts

        [OperationContract]
        UnMappedProduct[] GetAllUnMappedProducts();

        #endregion

        #region LoanPryMoratorium

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LoanPryMoratorium UpdateLoanPryMoratorium(LoanPryMoratorium loanPryMoratorium);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLoanPryMoratorium(int loanPryMoratoriumId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanPryMoratorium GetLoanPryMoratorium(int loanPryMoratoriumId);

        [OperationContract]
        LoanPryMoratorium[] GetAllLoanPryMoratorium();

        #endregion

        #region Borrowings

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Borrowings UpdateBorrowings(Borrowings borrowings);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteBorrowings(int borrowingId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Borrowings GetBorrowings(int borrowingId);

        [OperationContract]
        Borrowings[] GetAllBorrowings();

        
        #endregion

        #region OffBalanceSheetExposure

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        OffBalanceSheetExposure UpdateOffBalanceSheetExposure(OffBalanceSheetExposure offBalanceSheetExposure);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteOffBalanceSheetExposure(int obeId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        OffBalanceSheetExposure GetOffBalanceSheetExposure(int obeId);

        [OperationContract]
        OffBalanceSheetExposure[] GetAllOffBalanceSheetExposure();

        [OperationContract]
        OffBalanceSheetExposure[] GetOffBalanceSheetExposureByPortfolio(string portfolio);

        //[OperationContract]
        //OffBalanceSheetExposure[] GetTbillsByMaturityDate(DateTime matureDate);

        //[OperationContract]
        //void UpdateTbillsByMaturityDate(DateTime matureDate, decimal cmprice);

        #endregion

        #region Placement

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Placement UpdatePlacement(Placement placement);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeletePlacement(int Placement_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        Placement GetPlacement(int Placement_Id);

        [OperationContract]
        Placement[] GetAllPlacements();

        //[OperationContract]
        //Placement[] GetPlacementByRefNo(string RefNo);

        #endregion

        #region LoanInterestRate

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LoanInterestRate UpdateLoanInterestRate(LoanInterestRate loanInterestRate);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLoanInterestRate(int LoanInterestRate_Id);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanInterestRate GetLoanInterestRate(int LoanInterestRate_Id);

        [OperationContract]
        LoanInterestRate[] GetAllLoanInterestRates();

        //[OperationContract]
        //LoanInterestRate[] GetLoanInterestRateByRefNo(string RefNo);

        #endregion

        #region LoanCommitment

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LoanCommitment UpdateLoanCommitment(LoanCommitment loanCommitment);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLoanCommitment(int LoanCommitmentId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanCommitment GetLoanCommitment(int LoanCommitmentId);

        [OperationContract]
        LoanCommitment[] GetAllLoanCommitments();

        //[OperationContract]
        //LoanCommitment[] GetLoanCommitmentByRefNo(string RefNo);

        #endregion

        //#region IFRSBonds

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //IFRSBonds UpdateIFRSBonds(IFRSBonds IFRSBonds);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //void DeleteIFRSBonds(int bondId);

        //[OperationContract]
        //[FaultContract(typeof(NotFoundException))]
        //IFRSBonds GetIFRSBonds(int bondId);

        //[OperationContract]
        //IFRSBonds[] GetAllIFRSBonds();

        //[OperationContract]
        //IFRSBonds[] GetBondsByClassification(string classification);

        //[OperationContract]
        //IFRSBonds[] GetbondsByMaturityDate(DateTime matureDate);

        //[OperationContract]
        //void UpdatebondsByMaturityDate(DateTime matureDate, decimal cmprice);


        //#endregion


        #region DepositRepaymentSchedule

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DepositRepaymentSchedule UpdateDepositRepaymentSchedule(DepositRepaymentSchedule depositRepaymentSchedule);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteDepositRepaymentSchedule(int depositRepayId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        DepositRepaymentSchedule GetDepositRepaymentSchedule(int depositRepayId);

        [OperationContract]
        DepositRepaymentSchedule[] GetAllDepositRepaymentSchedule();

        [OperationContract]
        DepositRepaymentSchedule[] GetVarianceData();

        #endregion

        #region LiabilityRepaymentSchedule

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        LiabilityRepaymentSchedule UpdateLiabilityRepaymentSchedule(LiabilityRepaymentSchedule liabilityRepaymentSchedule);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteLiabilityRepaymentSchedule(int liabilityRepayId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LiabilityRepaymentSchedule GetLiabilityRepaymentSchedule(int liabilityRepayId);

        [OperationContract]
        LiabilityRepaymentSchedule[] GetAllLiabilityRepaymentSchedule();

        #endregion

        #region InputDetail

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        InputDetail UpdateInputDetail(InputDetail inputDetail);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteInputDetail(int InputDetailId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        InputDetail GetInputDetail(int InputDetailId);

        [OperationContract]
        InputDetail[] GetAllInputDetails();

        [OperationContract]
        EclWeightedAvg[] GetAllEclWeightedAvgs();

        [OperationContract]
        int InsertByRefno(string refNo);

        [OperationContract]
        void ComputeEcl();

        #endregion

        #region NseIndex

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        NseIndex UpdateNseIndex(NseIndex inputDetail);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteNseIndex(int NseIndexId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        NseIndex GetNseIndex(int NseIndexId);

        [OperationContract]
        NseIndex[] GetAllNseIndexs();

        [OperationContract]
        ProbabilityWeight[] GetAllProbabilityWeights();

        [OperationContract]
        void ComputeProbabilityWeight(double lOC);

        #endregion


    }
}
