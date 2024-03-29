﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Fintrak.Shared.Common.Contracts;
using Fintrak.Shared.Common.Exceptions;
using Fintrak.Client.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;

namespace Fintrak.Client.IFRS.Contracts
{
    [ServiceContract]
    public interface IIFRSDataViewService : IServiceContract
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void RegisterModule();
     
        #region BondComputationResult

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondComputation[] GetBondComputationResultDistinctRefNo();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondComputation[] GetBondComputationResultbyRefNo(string refNo);

        [OperationContract]
        BondComputation[] GetAllBondComputations();

        [OperationContract]
        BondComputation[] GetRefNoBondComputation();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        string[] GetDistinctRefNo();

        #endregion

        #region BondPeriodicSchedule

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondPeriodicSchedule[] GetBondPeriodicScheduleDistinctRefNo();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondPeriodicSchedule[] GetBondPeriodicSchedulebyRefNo(string refNo);

        [OperationContract]
        BondPeriodicSchedule[] GetAllBondPeriodicSchedules();

        #endregion

        #region BondComputationResultZero

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        IEnumerable<string> GetBondComputationResultZeroDistinctRefNo();
        //[FaultContract(typeof(NotFoundException))]
        //BondComputationResultZero[] GetBondComputationResultZeroDistinctRefNo();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BondComputationResultZero[] GetBondComputationResultZerobyRefNo(string refNo);

        [OperationContract]
        BondComputationResultZero[] GetBondComputationResultZeros();

        [OperationContract]
        BondComputationResultZero[] GetRefNoBondComputationResultZero();

        #endregion

        #region LoanPeriodicSchedule

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanPeriodicSchedule[] GetLoanPeriodicScheduleDistinctRefNo();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanPeriodicSchedule[] GetLoanPeriodicSchedulebyRefNo(string refNo);

        [OperationContract]
        LoanPeriodicSchedule[] GetAllLoanPeriodicSchedules();


        [OperationContract]
        LoanPeriodicSchedule[] GetRefNoLoanPeriodicSchedule();


        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void DeleteLoanPeriodicSchedulebyRefNo(string refNo);

        #endregion

        #region LoanSchedule

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanSchedule[] GetLoanScheduleDistinctRefNo();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        LoanSchedule[] GetLoanSchedulebyRefNo(string refNo);

        [OperationContract]
        LoanSchedule[] GetAllLoanSchedules();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        string[] GetLoanPeriodicRefNo();

        [OperationContract]
        LoanScheduleData[] GetScheduleRange(string refNo, DateTime rangeDate);

        #endregion

        #region LoansImpairmentResult

        [OperationContract]
        LoansImpairmentResult[] GetAllLoansImpairmentResults();

        #endregion

        #region TreasuryBills

        [OperationContract]
       
        TBillsComputationResult[] GetAllTBillsComputationResults();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        TBillsComputationResult[] GetTBillsByClassification(string classification);
        #endregion

        #region EquityStocks

        [OperationContract]
        EquityStockComputationResult[] GetAllEquityStocks();

        [OperationContract]
        EquityStockComputationResult[] GetEquityStockByClassification(string classification);

        #endregion
        
        #region BondConsolidatedData

        [OperationContract]
        BondConsolidatedData[] GetAllBondConsolidatedData();

        #endregion

        #region LoanConsolidatedData

        [OperationContract]
        LoanConsolidatedData[] GetAllLoanConsolidatedData();

        #endregion

        #region LoanConsolidatedDataFSDH

        [OperationContract]
        LoanConsolidatedDataFSDH[] GetAllLoanConsolidatedDataFSDH();

        #endregion

        #region TbillConsolidatedData

        [OperationContract]
        TbillConsolidatedData[] GetAllTbillConsolidatedData();

        #endregion

        #region BondConsolidatedData

        [OperationContract]
        BondConsolidatedDataOthers[] GetAllBondConsolidatedDataOthers();

        #endregion


        #region BorrowingPeriodicSchedule

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BorrowingPeriodicSchedule[] GetBorrowingPeriodicScheduleDistinctRefNo();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BorrowingPeriodicSchedule[] GetBorrowingPeriodicSchedulebyRefNo(string refNo);

        [OperationContract]
        BorrowingPeriodicSchedule[] GetAllBorrowingPeriodicSchedules();

        [OperationContract]
        BorrowingPeriodicSchedule[] GetRefNoBorrowingPeriodicSchedule();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        void DeleteBorrowingPeriodicSchedulebyRefNo(string refNo);

        [OperationContract]
        //[FaultContract(typeof(NotFoundException))]
        string[] GetBorrowingPeriodicRefNo();

        #endregion

        #region BorrowingSchedule

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BorrowingSchedule[] GetBorrowingScheduleDistinctRefNo();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        BorrowingSchedule[] GetBorrowingSchedulebyRefNo(string refNo);

        [OperationContract]
        BorrowingSchedule[] GetAllBorrowingSchedules();



        #endregion
       
    }
}
