using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IPfBalanceValidationRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PfBalanceValidationRepository : DataRepositoryBase<PfBalanceValidation>, IPfBalanceValidationRepository
    {
        protected override PfBalanceValidation AddEntity(IFRSContext entityContext, PfBalanceValidation entity)
        {
            return entityContext.Set<PfBalanceValidation>().Add(entity);
        }

        protected override PfBalanceValidation UpdateEntity(IFRSContext entityContext, PfBalanceValidation entity)
        {
            return (from e in entityContext.Set<PfBalanceValidation>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<PfBalanceValidation> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<PfBalanceValidation>()
                   select e;
        }

        protected override PfBalanceValidation GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<PfBalanceValidation>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<PfBalanceValidation> GetPfBalanceValidationBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<PfBalanceValidation>()
                             where e.Glcode == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<PfBalanceValidation> GetPfBalanceValidations(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<PfBalanceValidation>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


        public IEnumerable<PfBalanceValidation> GetPfBalanceValidationList(string code, string name){
            using (IFRSContext entityContext = new IFRSContext()) {

                if (String.IsNullOrEmpty(code)) {

                    var query = entityContext.Set<PfBalanceValidation>().Where(e => e.Productcode == name);
                    return query.ToArray();

                } else if (String.IsNullOrEmpty(name)) {

                    var query = entityContext.Set<PfBalanceValidation>().Where(e => e.Glcode == code);
                    return query.ToArray();

                } else {

                    var query = entityContext.Set<PfBalanceValidation>().Where(e => e.Productcode == name && e.Glcode == code);
                    return query.ToArray();
                }


            }
        }

    }
}