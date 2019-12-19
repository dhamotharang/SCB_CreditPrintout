using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Dynamic;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;
using Fintrak.Shared.Common.Services;
using Fintrak.Shared.Common.Services.QueryService;
//using NPOI.HSSF.UserModel;
using System.IO;
using System.Web;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IIfrsCorporatePdSeriesRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class IfrsCorporatePdSeriesRepository : DataRepositoryBase<IfrsCorporatePdSeries>, IIfrsCorporatePdSeriesRepository
    {
        protected override IfrsCorporatePdSeries AddEntity(IFRSContext entityContext, IfrsCorporatePdSeries entity)
        {
            return entityContext.Set<IfrsCorporatePdSeries>().Add(entity);
        }

        protected override IfrsCorporatePdSeries UpdateEntity(IFRSContext entityContext, IfrsCorporatePdSeries entity)
        {
            return (from e in entityContext.Set<IfrsCorporatePdSeries>()
                    where e.Sno == entity.Sno
                    select e).FirstOrDefault();
        }
        protected override IEnumerable<IfrsCorporatePdSeries> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<IfrsCorporatePdSeries>().Take(100)
                   select e;
        }

        protected override IfrsCorporatePdSeries GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<IfrsCorporatePdSeries>()
                         where e.Sno == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
        public IEnumerable<IfrsCorporatePdSeries> GetPaginatedEntities(QueryOptions queryOptions)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = from a in entityContext.IfrsCorporatePdSeriesSet
                            select a;

                query = (queryOptions.FilterFieldType == "string")
                    ? query.Where(queryOptions.FilterField + ".contains(@0)", queryOptions.FilterOption)
                    : query.Where(queryOptions.FilterField + " = " + queryOptions.FilterOption);

                var queryArray = query.OrderBy(queryOptions.Sort)
                            .Skip(
                               QueryOptionsCalculator.CalculateStart(queryOptions)
                           ).Take(queryOptions.PageSize)
                           .ToFullyLoaded();

                return queryArray;
            }
        }
        //public Stream GetForExport()
        //{
        //    var output = new ExcelService();
        //    using (IFRSContext entityContext = new IFRSContext())
        //    {
        //        var query = from e in entityContext.Set<IfrsCorporatePdSeries>()
        //                    select e;
        //        query = query.OrderBy(a => a.Sno);

        //        var workbo2ok = output.ExportUsingOxml<IfrsCorporatePdSeries>(query);

        //        var workbook = new HSSFWorkbook();

        //        //Create new Excel Sheet
        //        var sheet = workbook.CreateSheet("sheet 1");

        //        //Create a header row
        //        var headerRow = sheet.CreateRow(0);

        //        int i = 0;
        //        foreach (var prop in query.FirstOrDefault().GetType().GetProperties())
        //        {
        //            //(Optional) set the width of the columns
        //            sheet.SetColumnWidth(i, 20 * 256);


        //            headerRow.CreateCell(i).SetCellValue(prop.Name);

        //            i++;
        //        }

        //        //(Optional) freeze the header row so it is not scrolled
        //        sheet.CreateFreezePane(1, 1, 1, 1);

        //        int rowNumber = 1;
        //        int sheetNumber = 1;
        //        int workbookNumber = 1;


        //        string filename = null;
        //        string path = null;
        //        //Populate the sheet with values from the grid data

        //        //var currentSheet = sheet;
        //        foreach (var objArticles in query)
        //        {
        //            if (rowNumber % 65535 == 0)
        //            {
        //                if ((rowNumber / 65535) % 2 == 0)
        //                {
        //                    filename = string.Concat("data", workbookNumber++, ".xlsx");
        //                    path = HttpContext.Current.Server.MapPath("~");
        //                    if (System.IO.File.Exists(path))
        //                        System.IO.File.Delete(path);

        //                    //xfile = new FileStream(Path.Combine(path, filename), FileMode.Create, System.IO.FileAccess.Write);
        //                    using (FileStream xfile = new FileStream(Path.Combine(path, filename), FileMode.Create, System.IO.FileAccess.Write))
        //                    {
        //                        workbook.Write(xfile);
        //                    }
                            
        //                    //xfile.Close();
        //                    //workbook = null;
        //                    //xfile = null;
        //                    workbook = null;
        //                    workbook = new HSSFWorkbook();
        //                    sheetNumber = 0;
        //                }
        //                sheet = workbook.CreateSheet(string.Concat("sheet ", ++sheetNumber));
        //                headerRow = sheet.CreateRow(0);
        //                i = 0;
        //                foreach (var prop in objArticles.GetType().GetProperties())
        //                {
        //                    //(Optional) set the width of the columns
        //                    sheet.SetColumnWidth(i, 20 * 256);


        //                    headerRow.CreateCell(i).SetCellValue(prop.Name);

        //                    i++;
        //                }
        //            }

        //            //(Optional) freeze the header row so it is not scrolled
        //            sheet.CreateFreezePane(1, 1, 1, 1);

        //            var sheetRow = rowNumber / 65535 < 1 ? rowNumber++ % 65535 : rowNumber++ % 65535 + 1;
        //            //Create a new Row
        //            var row = sheet.CreateRow(sheetRow);

        //            //Set the Values for Cells
        //            i = 0;
        //            foreach (var prop in objArticles.GetType().GetProperties())
        //            {
        //                var value = ((prop.GetValue(objArticles, null) == null) == true) ? "" : prop.GetValue(objArticles, null).ToString();
        //                row.CreateCell(i).SetCellValue(value);
        //                i++;
        //            }

        //        }

        //        //Write the Workbook to a memory stream
        //        //MemoryStream output2 = new MemoryStream();
        //        //workbook.Write(output2);

        //        filename = string.Concat("data", workbookNumber, ".xls");
        //        path = HttpContext.Current.Server.MapPath("~");
        //        if (System.IO.File.Exists(path))
        //            System.IO.File.Delete(path);

        //        using (FileStream xfile = new FileStream(Path.Combine(path, filename), FileMode.Create, System.IO.FileAccess.Write))
        //        {
        //            workbook.Write(xfile);
        //        }

        //        return new FileStream(Path.Combine(path, filename), FileMode.Create, System.IO.FileAccess.Write);
        //    }
        //}

        public UInt64 GetTotalRecordsCount(string tableName, string columnName, string searchParamS, Double? searchParamN)
        {
            return 0;
        }
       
    }
}