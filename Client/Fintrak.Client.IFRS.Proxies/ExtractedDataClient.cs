using System;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Client.IFRS.Contracts;
using Fintrak.Client.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;
using Fintrak.Shared.Common.ServiceModel;

namespace Fintrak.Client.IFRS.Proxies
{
    [Export(typeof(IExtractedDataService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ExtratedDataClient : UserClientBase<IExtractedDataService>, IExtractedDataService
    {
        public void RegisterModule()
        {
            Channel.RegisterModule();
        }



        #region IFRSBonds

        public IFRSBonds UpdateIFRSBonds(IFRSBonds IFRSBonds)
        {
            return Channel.UpdateIFRSBonds(IFRSBonds);
        }

        public void DeleteIFRSBonds(int bondId)
        {
            Channel.DeleteIFRSBonds(bondId);
        }

        public IFRSBonds GetIFRSBonds(int bondId)
        {
            return Channel.GetIFRSBonds(bondId);
        }

        public IFRSBonds[] GetAllIFRSBonds()
        {
            return Channel.GetAllIFRSBonds();
        }

        public IFRSBonds[] GetBondsByClassification(string classification)
        {
            return Channel.GetBondsByClassification(classification);
        }

        public IFRSBonds[] GetbondsByMaturityDate(DateTime matureDate)
        {
            return Channel.GetbondsByMaturityDate(matureDate);
        }

       public  void UpdatebondsByMaturityDate(DateTime matureDate, decimal cmprice)
        {
             Channel.UpdatebondsByMaturityDate(matureDate, cmprice);
        }
        
        
        #endregion

        #region IFRSTbills

        public IFRSTbills UpdateIFRSTbills(IFRSTbills IFRSTbills)
        {
            return Channel.UpdateIFRSTbills(IFRSTbills);
        }

        public void DeleteIFRSTbills(int tbillId)
        {
            Channel.DeleteIFRSTbills(tbillId);
        }

        public IFRSTbills GetIFRSTbills(int tbillId)
        {
            return Channel.GetIFRSTbills(tbillId);
        }

        public IFRSTbills[] GetAllIFRSTbills()
        {
            return Channel.GetAllIFRSTbills();
        }

        public IFRSTbills[] GetTbillsByClassification(string classification, int type)
        {
            return Channel.GetTbillsByClassification(classification, type);
        }

        public IFRSTbills[] GetTbillsByMaturityDate(DateTime matureDate, int type)
        {
            return Channel.GetTbillsByMaturityDate(matureDate, type);
        }

        public void UpdateTbillsByMaturityDate(DateTime matureDate, decimal cmprice)
        {
            Channel.UpdateTbillsByMaturityDate(matureDate, cmprice);
        }

        public IFRSTbills[] GetListByType(int Type)
        {
            return Channel.GetListByType(Type);
        }

        #endregion

        #region LoanPry

        public LoanPry UpdateLoanPry(LoanPry loanPryMoratorium)
        {
            return Channel.UpdateLoanPry(loanPryMoratorium);
        }

        public void DeleteLoanPry(int pryId)
        {
            Channel.DeleteLoanPry(pryId);
        }

        public LoanPry GetLoanPry(int pryId)
        {
            return Channel.GetLoanPry(pryId);
        }

        public LoanPry[] GetAllLoanPry()
        {
            return Channel.GetAllLoanPry();
        }

        public LoanPry[] GetLoanPryByScheduleType(string schType)
        {
            return Channel.GetLoanPryByScheduleType(schType);
        }
        public LoanPry[] GetPryLoanBySearch(string searchParam)
        {
            return Channel.GetPryLoanBySearch(searchParam);
        }

        public LoanPry[] GetPryLoans(int defaultCount)
        {
            return Channel.GetPryLoans(defaultCount);
        }


        #endregion


        /**************************************************************************************************/



        #region OdLgdComputationResult

        public OdLgdComputationResult UpdateOdLgdComputationResult(OdLgdComputationResult odlgdcomputationresult) {
            return Channel.UpdateOdLgdComputationResult(odlgdcomputationresult);
        }

        public void DeleteOdLgdComputationResult(int Id) {
            Channel.DeleteOdLgdComputationResult(Id);
        }

        public OdLgdComputationResult GetOdLgdComputationResult(int Id) {
            return Channel.GetOdLgdComputationResult(Id);
        }

        public OdLgdComputationResult[] GetAllOdLgdComputationResult() {
            return Channel.GetAllOdLgdComputationResult();
        }

        public OdLgdComputationResult[] GetOdLgdComputationResultBySearch(string searchParam) {
            return Channel.GetOdLgdComputationResultBySearch(searchParam);
        }

        public OdLgdComputationResult[] GetOdLgdComputationResults(int defaultCount) {
            return Channel.GetOdLgdComputationResults(defaultCount);
        }

        #endregion



        /**************************************************************************************************/



        #region LoansECLComputationResult

        public LoansECLComputationResult UpdateLoansECLComputationResult(LoansECLComputationResult loanseclcomputationresult) {
            return Channel.UpdateLoansECLComputationResult(loanseclcomputationresult);
        }

        public void DeleteLoansECLComputationResult(int Id) {
            Channel.DeleteLoansECLComputationResult(Id);
        }

        public LoansECLComputationResult GetLoansECLComputationResult(int Id) {
            return Channel.GetLoansECLComputationResult(Id);
        }

        public LoansECLComputationResult[] GetAllLoansECLComputationResult() {
            return Channel.GetAllLoansECLComputationResult();
        }

        public LoansECLComputationResult[] GetLoansECLComputationResultBySearch(string searchParam) {
            return Channel.GetLoansECLComputationResultBySearch(searchParam);
        }

        public LoansECLComputationResult[] GetLoansECLComputationResults(int defaultCount) {
            return Channel.GetLoansECLComputationResults(defaultCount);
        }

        #endregion

        #region MarginalPddSTRLB

        public MarginalPddSTRLB UpdateMarginalPddSTRLB(MarginalPddSTRLB marginalpddstrlb) {
            return Channel.UpdateMarginalPddSTRLB(marginalpddstrlb);
        }

        public void DeleteMarginalPddSTRLB(int Id) {
            Channel.DeleteMarginalPddSTRLB(Id);
        }

        public MarginalPddSTRLB GetMarginalPddSTRLB(int Id) {
            return Channel.GetMarginalPddSTRLB(Id);
        }

        public MarginalPddSTRLB[] GetAllMarginalPddSTRLB() {
            return Channel.GetAllMarginalPddSTRLB();
        }

        public MarginalPddSTRLB[] GetMarginalPddSTRLBBySearch(string searchParam) {
            return Channel.GetMarginalPddSTRLBBySearch(searchParam);
        }

        public MarginalPddSTRLB[] GetMarginalPddSTRLBs(int defaultCount) {
            return Channel.GetMarginalPddSTRLBs(defaultCount);
        }

        #endregion

        #region ODEclComputationResult

        public ODEclComputationResult UpdateODEclComputationResult(ODEclComputationResult odeclcomputationresult) {
            return Channel.UpdateODEclComputationResult(odeclcomputationresult);
        }

        public void DeleteODEclComputationResult(int Id) {
            Channel.DeleteODEclComputationResult(Id);
        }

        public ODEclComputationResult GetODEclComputationResult(int Id) {
            return Channel.GetODEclComputationResult(Id);
        }

        public ODEclComputationResult[] GetAllODEclComputationResult() {
            return Channel.GetAllODEclComputationResult();
        }

        public ODEclComputationResult[] GetODEclComputationResultBySearch(string searchParam) {
            return Channel.GetODEclComputationResultBySearch(searchParam);
        }

        public ODEclComputationResult[] GetODEclComputationResults(int defaultCount) {
            return Channel.GetODEclComputationResults(defaultCount);
        }

        #endregion

        #region MarginalPdObeDistr

        public MarginalPdObeDistr UpdateMarginalPdObeDistr(MarginalPdObeDistr marginalpdobedistr) {
            return Channel.UpdateMarginalPdObeDistr(marginalpdobedistr);
        }

        public void DeleteMarginalPdObeDistr(int Id) {
            Channel.DeleteMarginalPdObeDistr(Id);
        }

        public MarginalPdObeDistr GetMarginalPdObeDistr(int Id) {
            return Channel.GetMarginalPdObeDistr(Id);
        }

        public MarginalPdObeDistr[] GetAllMarginalPdObeDistr() {
            return Channel.GetAllMarginalPdObeDistr();
        }

        public MarginalPdObeDistr[] GetMarginalPdObeDistrBySearch(string searchParam) {
            return Channel.GetMarginalPdObeDistrBySearch(searchParam);
        }

        public MarginalPdObeDistr[] GetMarginalPdObeDistrs(int defaultCount) {
            return Channel.GetMarginalPdObeDistrs(defaultCount);
        }

        #endregion

        #region LGDComptResult

        public LGDComptResult UpdateLGDComptResult(LGDComptResult lgdcomptresult) {
            return Channel.UpdateLGDComptResult(lgdcomptresult);
        }

        public void DeleteLGDComptResult(int Id) {
            Channel.DeleteLGDComptResult(Id);
        }

        public LGDComptResult GetLGDComptResult(int Id) {
            return Channel.GetLGDComptResult(Id);
        }

        public LGDComptResult[] GetAllLGDComptResult() {
            return Channel.GetAllLGDComptResult();
        }

        public LGDComptResult[] GetLGDComptResultBySearch(string searchParam) {
            return Channel.GetLGDComptResultBySearch(searchParam);
        }

        public LGDComptResult[] GetLGDComptResults(int defaultCount) {
            return Channel.GetLGDComptResults(defaultCount);
        }

        #endregion

        #region ObeLGDComptResult

        public ObeLGDComptResult UpdateObeLGDComptResult(ObeLGDComptResult obelgdcomptresult) {
            return Channel.UpdateObeLGDComptResult(obelgdcomptresult);
        }

        public void DeleteObeLGDComptResult(int Id) {
            Channel.DeleteObeLGDComptResult(Id);
        }

        public ObeLGDComptResult GetObeLGDComptResult(int Id) {
            return Channel.GetObeLGDComptResult(Id);
        }

        public ObeLGDComptResult[] GetAllObeLGDComptResult() {
            return Channel.GetAllObeLGDComptResult();
        }

        public ObeLGDComptResult[] GetObeLGDComptResultBySearch(string searchParam) {
            return Channel.GetObeLGDComptResultBySearch(searchParam);
        }

        public ObeLGDComptResult[] GetObeLGDComptResults(int defaultCount) {
            return Channel.GetObeLGDComptResults(defaultCount);
        }

        #endregion


        /**************************************************************************************************/



        #region RawLoanDetails

        public RawLoanDetails UpdateRawLoanDetails(RawLoanDetails loanDetails)
        {
            return Channel.UpdateRawLoanDetails(loanDetails);
        }

        public void DeleteRawLoanDetails(int loanDetailld)
        {
            Channel.DeleteRawLoanDetails(loanDetailld);
        }

        public RawLoanDetails GetRawLoanDetails(int loanDetailld)
        {
            return Channel.GetRawLoanDetails(loanDetailld);
        }

        public RawLoanDetails[] GetAllRawLoanDetails()
        {
            return Channel.GetAllRawLoanDetails();
        }

        public RawLoanDetails[] GetAllLoanDetailsBySearch(string searchParam)
        {
            return Channel.GetAllLoanDetailsBySearch(searchParam);
        }

        public void UpdateLoanClassNotch(string refNo, string rating, int stage, string notes)
        {
            Channel.UpdateLoanClassNotch(refNo, rating, stage, notes);
        }

        public void DeleteLoanDetailsNotch(string refNo)
        {
            Channel.DeleteLoanDetailsNotch(refNo);
        }

        public CollateralRecov[] ComputeRecovAmt(string refNo, string collateralType, double collateralValue)
        {
            return Channel.ComputeRecovAmt(refNo, collateralType, collateralValue);
        }

        public RawLoanDetails[] GetAllLoanDetails(int defaultCount)
        {
            return Channel.GetAllLoanDetails(defaultCount);
        }

        #endregion

        #region IntegralFee

        public IntegralFee UpdateIntegralFee(IntegralFee integralFee)
        {
            return Channel.UpdateIntegralFee(integralFee);
        }

        public void DeleteIntegralFee(int integralFeeId)
        {
            Channel.DeleteIntegralFee(integralFeeId);
        }

        public IntegralFee GetIntegralFee(int integralFeeId)
        {
            return Channel.GetIntegralFee(integralFeeId);
        }

        public IntegralFee[] GetAllIntegralFee()
        {
            return Channel.GetAllIntegralFee();
        }

        #endregion

        #region IfrsCustomer

        public IfrsCustomer UpdateIfrsCustomer(IfrsCustomer ifrsCustomer)
        {
            return Channel.UpdateIfrsCustomer(ifrsCustomer);
        }

        public void DeleteIfrsCustomer(int customerId)
        {
            Channel.DeleteIfrsCustomer(customerId);
        }

        public IfrsCustomer GetIfrsCustomer(int customerId)
        {
            return Channel.GetIfrsCustomer(customerId);
        }

        public IfrsCustomer[] GetAllIfrsCustomer()
        {
            return Channel.GetAllIfrsCustomer();
        }

        public IfrsCustomer[] GetIfrsCustomerByRating(string rating)
        {
            return Channel.GetIfrsCustomerByRating(rating);
        }

        public IfrsCustomer[] GetCustomerInfoBySearch(string searchParam)
        {
            return Channel.GetCustomerInfoBySearch(searchParam);
        }

        public IfrsCustomer[] GetCustomers(int defaultCount)
        {
            return Channel.GetCustomers(defaultCount);
        }

        #endregion

        #region IfrsCustomerAccount

        public IfrsCustomerAccount UpdateIfrsCustomerAccount(IfrsCustomerAccount ifrsCustomerAccount)
        {
            return Channel.UpdateIfrsCustomerAccount(ifrsCustomerAccount);
        }

        public void DeleteIfrsCustomerAccount(int custAccountId)
        {
            Channel.DeleteIfrsCustomerAccount(custAccountId);
        }

        public IfrsCustomerAccount GetIfrsCustomerAccount(int custAccountId)
        {
            return Channel.GetIfrsCustomerAccount(custAccountId);
        }

        public IfrsCustomerAccount[] GetAllIfrsCustomerAccount()
        {
            return Channel.GetAllIfrsCustomerAccount();
        }
        public string[] GetDistinctSector()
        {
            return Channel.GetDistinctSector();
        }

        #endregion

        #region UnMappedProduct

        public UnMappedProduct[] GetAllUnMappedProducts()
        {
            return Channel.GetAllUnMappedProducts();
        }



        #endregion

        #region LoanPryMoratorium

        public LoanPryMoratorium UpdateLoanPryMoratorium(LoanPryMoratorium loanPryMoratorium)
        {
            return Channel.UpdateLoanPryMoratorium(loanPryMoratorium);
        }

        public void DeleteLoanPryMoratorium(int loanPryMoratoriumId)
        {
            Channel.DeleteLoanPryMoratorium(loanPryMoratoriumId);
        }

        public LoanPryMoratorium GetLoanPryMoratorium(int loanPryMoratoriumId)
        {
            return Channel.GetLoanPryMoratorium(loanPryMoratoriumId);
        }

        public LoanPryMoratorium[] GetAllLoanPryMoratorium()
        {
            return Channel.GetAllLoanPryMoratorium();
        }

       

        #endregion
        
        #region Borrowings

        public Borrowings UpdateBorrowings(Borrowings borrowing)
        {
            return Channel.UpdateBorrowings(borrowing);
        }

        public void DeleteBorrowings(int borrowingId)
        {
            Channel.DeleteBorrowings(borrowingId);
        }

        public Borrowings GetBorrowings(int borrowingId)
        {
            return Channel.GetBorrowings(borrowingId);
        }

        public Borrowings[] GetAllBorrowings()
        {
            return Channel.GetAllBorrowings();
        }
        
        #endregion

        #region OffBalanceSheetExposure

        public OffBalanceSheetExposure UpdateOffBalanceSheetExposure(OffBalanceSheetExposure offBalanceSheetExposure)
        {
            return Channel.UpdateOffBalanceSheetExposure(offBalanceSheetExposure);
        }

        public void DeleteOffBalanceSheetExposure(int obeId)
        {
            Channel.DeleteOffBalanceSheetExposure(obeId);
        }

        public OffBalanceSheetExposure GetOffBalanceSheetExposure(int obeId)
        {
            return Channel.GetOffBalanceSheetExposure(obeId);
        }

        public OffBalanceSheetExposure[] GetAllOffBalanceSheetExposure()
        {
            return Channel.GetAllOffBalanceSheetExposure();
        }

        public OffBalanceSheetExposure[] GetOffBalanceSheetExposureByPortfolio(string portfolio)
        {
            return Channel.GetOffBalanceSheetExposureByPortfolio(portfolio);
        }

        #endregion

        #region Placement

        public Placement UpdatePlacement(Placement placement)
        {
            return Channel.UpdatePlacement(placement);
        }

        public void DeletePlacement(int Placement_Id)
        {
            Channel.DeletePlacement(Placement_Id);
        }

        public Placement GetPlacement(int Placement_Id)
        {
            return Channel.GetPlacement(Placement_Id);
        }

        public Placement[] GetAllPlacements()
        {
            return Channel.GetAllPlacements();
        }

        //public Placement[] GetPlacementByRefNo(string RefNo)
        //{
        //    return Channel.GetPlacementByRefNo(RefNo);
        //}


        #endregion

        #region LoanInterestRate

        public LoanInterestRate UpdateLoanInterestRate(LoanInterestRate loanInterestRate)
        {
            return Channel.UpdateLoanInterestRate(loanInterestRate);
        }

        public void DeleteLoanInterestRate(int LoanInterestRate_Id)
        {
            Channel.DeleteLoanInterestRate(LoanInterestRate_Id);
        }

        public LoanInterestRate GetLoanInterestRate(int LoanInterestRate_Id)
        {
            return Channel.GetLoanInterestRate(LoanInterestRate_Id);
        }

        public LoanInterestRate[] GetAllLoanInterestRates()
        {
            return Channel.GetAllLoanInterestRates();
        }

        //public LoanInterestRate[] GetLoanInterestRateByRefNo(string RefNo)
        //{
        //    return Channel.GetLoanInterestRateByRefNo(RefNo);
        //}


        #endregion

        #region DepositRepaymentSchedule

        public DepositRepaymentSchedule UpdateDepositRepaymentSchedule(DepositRepaymentSchedule depositRepaymentSchedule)
        {
            return Channel.UpdateDepositRepaymentSchedule(depositRepaymentSchedule);
        }

        public void DeleteDepositRepaymentSchedule(int depositRepayId)
        {
            Channel.DeleteDepositRepaymentSchedule(depositRepayId);
        }

        public DepositRepaymentSchedule GetDepositRepaymentSchedule(int depositRepayId)
        {
            return Channel.GetDepositRepaymentSchedule(depositRepayId);
        }

        public DepositRepaymentSchedule[] GetAllDepositRepaymentSchedule()
        {
            return Channel.GetAllDepositRepaymentSchedule();
        }

        public DepositRepaymentSchedule[] GetVarianceData()
        {
            return Channel.GetVarianceData();
        }

        #endregion

        #region LiabilityRepaymentSchedule

        public LiabilityRepaymentSchedule UpdateLiabilityRepaymentSchedule(LiabilityRepaymentSchedule liabilityRepaymentSchedule)
        {
            return Channel.UpdateLiabilityRepaymentSchedule(liabilityRepaymentSchedule);
        }

        public void DeleteLiabilityRepaymentSchedule(int liabilityRepayId)
        {
            Channel.DeleteLiabilityRepaymentSchedule(liabilityRepayId);
        }

        public LiabilityRepaymentSchedule GetLiabilityRepaymentSchedule(int liabilityRepayId)
        {
            return Channel.GetLiabilityRepaymentSchedule(liabilityRepayId);
        }

        public LiabilityRepaymentSchedule[] GetAllLiabilityRepaymentSchedule()
        {
            return Channel.GetAllLiabilityRepaymentSchedule();
        }

        #endregion

        #region LoanCommitment

        public LoanCommitment UpdateLoanCommitment(LoanCommitment loanCommitment)
        {
            return Channel.UpdateLoanCommitment(loanCommitment);
        }

        public void DeleteLoanCommitment(int LoanCommitmentId)
        {
            Channel.DeleteLoanCommitment(LoanCommitmentId);
        }

        public LoanCommitment GetLoanCommitment(int LoanCommitmentId)
        {
            return Channel.GetLoanCommitment(LoanCommitmentId);
        }

        public LoanCommitment[] GetAllLoanCommitments()
        {
            return Channel.GetAllLoanCommitments();
        }

        //public LoanCommitment[] GetLoanCommitmentByRefNo(string RefNo)
        //{
        //    return Channel.GetLoanCommitmentByRefNo(RefNo);
        //}


        #endregion

        #region InputDetail

        public InputDetail UpdateInputDetail(InputDetail inputDetail)
        {
            return Channel.UpdateInputDetail(inputDetail);
        }

        public void DeleteInputDetail(int InputDetailId)
        {
            Channel.DeleteInputDetail(InputDetailId);
        }

        public InputDetail GetInputDetail(int InputDetailId)
        {
            return Channel.GetInputDetail(InputDetailId);
        }

        public InputDetail[] GetAllInputDetails()
        {
            return Channel.GetAllInputDetails();
        }

        public EclWeightedAvg[] GetAllEclWeightedAvgs()
        {
            return Channel.GetAllEclWeightedAvgs();
        }

        public int InsertByRefno(string refNo)
        {
            return Channel.InsertByRefno(refNo);
        }

        public void ComputeEcl()
        {
            Channel.ComputeEcl();
        }

        #endregion

        #region NseIndex

        public NseIndex UpdateNseIndex(NseIndex nseIndex)
        {
            return Channel.UpdateNseIndex(nseIndex);
        }

        public void DeleteNseIndex(int NseIndexId)
        {
            Channel.DeleteNseIndex(NseIndexId);
        }

        public NseIndex GetNseIndex(int NseIndexId)
        {
            return Channel.GetNseIndex(NseIndexId);
        }

        public NseIndex[] GetAllNseIndexs()
        {
            return Channel.GetAllNseIndexs();
        }

        public ProbabilityWeight[] GetAllProbabilityWeights()
        {
            return Channel.GetAllProbabilityWeights();
        }

        public void ComputeProbabilityWeight(double lOC)
        {
            Channel.ComputeProbabilityWeight(lOC);
        }

        #endregion
    }
}
